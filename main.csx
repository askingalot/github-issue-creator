#!/bin/env dotnet-script

using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;

/* 
1. Parse Markdown file to get issues in a collection
2. Write issues to console
3. Loop through and post to API
4. ???
5. Prophet
*/

record GitHubissue(string title, string body);

async Task Main()
{
    var filename = "example_github_issues.md";
    var content = File.ReadAllText(filename);

    var unparsedIssues = content.Split("---").Skip(1).ToArray();

    var parsedIssues = new List<GitHubissue>();
    foreach (var unparsedIssue in unparsedIssues)
    {
        var titleStart = unparsedIssue.IndexOf("## ");
        var titleEnd = unparsedIssue.IndexOf(Environment.NewLine, titleStart);
        var title = unparsedIssue.Substring(titleStart + 3, titleEnd - (titleStart + 3));
        var body = unparsedIssue.Substring(titleEnd + 1);

        parsedIssues.Add(new GitHubissue(title, body));
    }

    foreach (var issue in parsedIssues)
    {
        await PostToGithub(issue);
    }
}

async Task PostToGithub(GitHubissue issue)
{
    await Task.Delay(1_000);

    var token = File.ReadAllText("github_pat");

    var url = "https://api.github.com/repos/askingalot/NashDotNet-Feb11-2021/issues";
    var client = new HttpClient();
    client.DefaultRequestHeaders.Add("User-Agent", "Andy");
    client.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
    client.DefaultRequestHeaders.Add("Authorization", $"token {token}");

    var content = System.Net.Http.Json.JsonContent.Create(issue);
    var response = await client.PostAsync(url, content);
    if (response.StatusCode == System.Net.HttpStatusCode.Created)
    {
        Console.WriteLine("Issue Created!");
    }
    else
    {
        Console.WriteLine("You are a bad programmer! " +
            response.StatusCode + " " +
            (await response.Content.ReadAsStringAsync()));
    }
}

await Main();