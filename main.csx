#!/bin/env dotnet-script

using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;

var GITHUB_PAT = File.ReadAllText("github_pat").Trim();
var GITHUB_API_URL = "https://api.github.com/repos/askingalot/NashDotNet-Feb11-2021/issues";
var GITHUB_WAIT_WHEN_FORBIDDEN_SECONDS = 60;
var MARKDOWN_FILE = "example_github_issues.md";

record GitHubissue(string title, string body);


async Task Main()
{
    var content = File.ReadAllText(MARKDOWN_FILE);
    var unparsedIssues = content.Split("---").Skip(1);
    foreach (var unparsedIssue in unparsedIssues)
    {
        var titleStart = unparsedIssue.IndexOf("## ") + 3;
        var titleEnd = unparsedIssue.IndexOf(Environment.NewLine, titleStart);

        var title = unparsedIssue.Substring(titleStart, titleEnd - titleStart);
        var body = unparsedIssue.Substring(titleEnd + 1);

        await PostToGithub(new GitHubissue(title, body));
    }
}


async Task PostToGithub(GitHubissue issue)
{
    Console.Write($"Creating Issue: '{issue.title}'... ");

    var client = GetClient();
    using var response = await client.PostAsync(
        GITHUB_API_URL, JsonContent.Create(issue));

    if (response.StatusCode == HttpStatusCode.Created)
    {
        Console.WriteLine("Done");
    }
    else if (response.StatusCode == HttpStatusCode.Forbidden)
    {
        Console.Write($"Too many requests. Github is mad. Will retry in {GITHUB_WAIT_WHEN_FORBIDDEN_SECONDS} seconds...");
        await DelayWithNotification(GITHUB_WAIT_WHEN_FORBIDDEN_SECONDS);
        await PostToGithub(issue);
        return;
    }
    else
    {
        var errorMessage = await response.Content.ReadAsStringAsync();
        Console.WriteLine(errorMessage);
    }
}


async Task DelayWithNotification(int seconds)
{
    var cursorPos = Console.CursorLeft;
    for (var s = seconds; s >= 0; s--)
    {
        Console.Write($" {s}    ");
        if (s > 0)
        {
            await Task.Delay(1_000);
            Console.CursorLeft = cursorPos;
        }
    }
    Console.WriteLine();
}


HttpClient _client = null;
HttpClient GetClient()
{
    if (_client != null)
    {
        return _client;
    }

    _client = new HttpClient();
    _client.DefaultRequestHeaders.Add("Connection", "close");
    _client.DefaultRequestHeaders.Add("User-Agent", "GitHub-Issue-Creator");
    _client.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
    _client.DefaultRequestHeaders.Add("Authorization", $"token {GITHUB_PAT}");
    return _client;
}


await Main();
