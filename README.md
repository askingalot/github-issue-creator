# Nashville .Net User Group

## _Feb 11, 2021_

---

## Who am I?

### Andy Collins 

* Senior Web Dev Instructor at Nashville Software School
  * http://nashvillesoftwareschool.com/
* Co-host of the _**Reference Counting Podcast**_
  * w/ Taylor Hutchison [@taylorhutchison](https://twitter.com/taylorhutchison)
  * https://www.refcountpodcast.com
  * [@refcountpodcast](https://twitter.com/RefCountPodcast)
* Twitter / LinkedIn
  * [@askingalot](https://twitter.com/askingalot)
  * https://www.linkedin.com/in/andy-collins/

---

## What are we doing?

[Mob Programming](https://en.wikipedia.org/wiki/Mob_programming) is essentially pair programming with more than two people. An entire team works together on the same code.

A larger group provides a diversity of ideas, as well as, an opportunity for people to simultaneously research different topics and approaches to the current problem.

**So grab your torches and pitchforks. Tonight, we're forming a mob!**

---

## Ok, So what will we build?

Well, there are a couple of options we'll look at shortly, but the general idea is to build a simple - but _useful_ - tool in C#. Not an application for others, but the kind of thing we might build for ourselves.

We'll be using [dotnet-script](https://github.com/filipw/dotnet-script) for this project. It allows us to run C# scripts (`*.csx` files). A C# script is a _"light-weight"_ way to run C# code without building a full application.

> **NOTE:** There are a handful of tools you can use to run `csx` files. You can read more about them here: https://itnext.io/hitchhikers-guide-to-the-c-scripting-13e45f753af9

---

## Option 1 - GitHub Issue Maker

A tool that creates _issues_ in a GitHub repo.

GitHub issues are a nice way to keep track of project work, but it's painful to create them manually. An easier approach would be to write issues in a markdown (`*.md`) file and push them to Github. 

This tool should read a markdown file to get the list of issues and use the [GitHub API](https://docs.github.com/en/rest) to create them in GitHub.

Here's an example of the markdown file for testing: [example_github_issues.md](./example_github_issues.md)

---

## Option 2 - .NET Foundation Project Collector

A tool to capture and save the list of .NET open source projects that are supported by the .NET Foundation.

The .NET Foundation website's [Project Page](https://dotnetfoundation.org/projects) has a list of all the projects they support, but they don't have an easy way to download a dataset that contains information about the projects. 

This tool should download the project data from the website and produce a `*.csv` file that contains the data for each project.

---

## How's this going to work?

In the classic _Driver/Navigator_ style of pair (mob) programming, I will be the driver and you all with be the navigators. It's your job to direct me as we go along. This means having ideas for what to do next, as well as, researching APIs, libraries, tools, etc... that we may need as we go.

Since there's a "mob" of us, we'll have to come to a consensus before we make a move. But that's all part of the fun.

Speak up. Don't be shy. There are no dumb questions or ideas. But if you aren't comfortable saying something in front of the group, feel free to use the chat and we'll try to keep an eye on it.
