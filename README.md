# GitHub Issue Creator

Create github issues from a simple markdown file.

## What is this?

`main.csx` is a [dotnet script](https://github.com/filipw/dotnet-script) that parses a markdown file _(such as [example_github.issues.md](./example_github_issues.md))_, extracts User Stories _(aka. tickets, issues, work items...)_ from it, and uses the [GitHub API](https://docs.github.com/en/rest) to create new GitHub Issues for each User Story.

Issues are created in the same order as they appear in the markdown file.

