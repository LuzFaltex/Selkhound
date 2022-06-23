# Contribution to Selkhound

You can contribute to Selkhound with issues and PRs. Simply filing issues for problems you encounter is a great way to contribute. Contributing implementations is greatly appreciated.

## Reporting Issues

We always welcome bug reports, API proposals and overall feedback. Here are a few tips on how you can make reporting your issue as effective as possible.

### Identify Where to Report

The Selkhound is distributed across multiple repositories in the [Selkhound organization](https://github.com/Selkhound/). Depending on the feedback you might want to file the issue on a different repo. Here are a few common repos:

* [selkhound/selkhound](https://github.com/Selkhound/Selkhound/) Selkhound runtime, API, supporting server libraries.
* [selkhound/selkhound-client](https://github.com/Selkhound/Selkhound-Client) Front-end user application.

### Finding Existing Issues

Before filing a new issue, please search our [open issues](https://github.com/Selkhound/Selkhound/issues) to check if it already exists.

If you do find an existing issue, please include your own feedback in the discussion. Do consider upvoting (👍 reaction) the original post, as this helps us prioritize popular issues in our backlog.

### Writing a Good API Proposal

Please review our [API review process](https://github.com/LuzFaltex/Contribution/blob/main/docs/api-review-process.md) documents for guidelines on how to submit an API review. When ready to submit a proposal, please use the [API Suggestion issue template](#).

### Writing a Good Bug Report

Good bug reports make it easier for maintainers to verify and root cause the underlying problem. The better a bug report, the faster the problem will be resolved. Ideally, a bug report should contain the following information:

* A high-level description of the problem.
* A _minimal reproduction_, i.e. the smallest size of code/configuration required to reproduce the wrong behavior.
* A description of the _expected behavior_, contrasted with the _actual behavior_ observed.
* Information on the environment: OS/distro, CPU arch, SDK version, etc.
* Additional information, e.g. is it a regression from previous versions? are there any known workarounds?

When ready to submit a bug report, please use the [Bug Report issue template](#).

#### Why are Minimal Reproductions Important?

A reproduction lets maintainers verify the presence of a bug, and diagnose the issue using a debugger. A _minimal_ reproduction is the smallest possible console application demonstrating that bug. Minimal reproductions are generally preferable since they:

1. Focus debugging efforts on a simple code snippet,
2. Ensure that the problem is not caused by unrelated dependencies/configuration,
3. Avoid the need to share production codebases.

#### Are Minimal Reproductions Required?

In certain cases, creating a minimal reproduction might not be practical (e.g. due to nondeterministic factors, external dependencies). In such cases you would be asked to provide as much information as possible, for example by sharing a memory dump of the failing application. If maintainers are unable to root cause the problem, they might still close the issue as not actionable. While not required, minimal reproductions are strongly encouraged and will significantly improve the chances of your issue being prioritized and fixed by the maintainers.

#### How to Create a Minimal Reproduction

The best way to create a minimal reproduction is gradually removing code and dependencies from a reproducing app, until the problem no longer occurs. A good minimal reproduction:

* Excludes all unnecessary types, methods, code blocks, source files, nuget dependencies and project configurations.
* Contains documentation or code comments illustrating expected vs actual behavior.
* If possible, avoids performing any unneeded IO or system calls. For example, can the ASP.NET based reproduction be converted to a plain old console app?

## Contributing Changes

Project maintainers will merge changes that improve the product significantly and broadly align with the [Selkhound Roadmap](https://github.com/orgs/Selkhound/projects/3/views/1).

Maintainers will not merge changes that have narrowly-defined benefits, due to compatibility risk. The .NET Core codebase is used by several Microsoft products (for example, ASP.NET Core, .NET Framework 4.x, Windows Universal Apps) to enable execution of managed code. Other companies are building products on top of .NET, too. We may revert changes if they are found to be breaking.

Contributions must also satisfy the other published guidelines defined in this document.

### DOs and DON'Ts

Please do:

* **DO** follow our [coding style](https://github.com/LuzFaltex/Contribution/blob/main/docs/coding-style.md) (C# code-specific)
* **DO** give priority to the current style of the project or file you're changing even if it diverges from the general guidelines.
* **DO** include tests when adding new features. When fixing bugs, start with
  adding a test that highlights how the current behavior is broken.
* **DO** keep the discussions focused. When a new or related topic comes up
  it's often better to create new issue than to side track the discussion.
* **DO** blog and tweet (or whatever) about your contributions, frequently!

Please do not:

* **DON'T** make PRs for style changes.
* **DON'T** surprise us with big pull requests. Instead, file an issue and start
  a discussion so we can agree on a direction before you invest a large amount
  of time.
* **DON'T** commit code that you didn't write. If you find code that you think is a good fit to add to .NET Core, file an issue and start a discussion before proceeding.
* **DON'T** submit PRs that alter licensing related files or headers. If you believe there's a problem with them, file an issue and we'll be happy to discuss it.
* **DON'T** add API additions without filing an issue and discussing with us first. See the [API Review Process](https://github.com/LuzFaltex/Contribution/blob/main/docs/api-review-process.md).

### Breaking Changes

LuzFaltex follows DotNet Foundation guides except where otherwise noted. Contributions must maintain [API signature](https://github.com/dotnet/runtime/blob/main/docs/coding-guidelines/breaking-changes.md#bucket-1-public-contract) and behavioral compatibility. Contributions that include [breaking changes](https://github.com/dotnet/runtime/blob/main/docs/coding-guidelines/breaking-changes.md) may be rejected or delayed for a major version update. Please file an issue to discuss your idea or change if you believe that it may affect code compatibility.

### Suggested Workflow

We use and recommend the following workflow:

1. Create an issue for your work.
    - Reuse an existing issue on the topic, if there is one.
    - Get agreement from the team and the community that your proposed change is a good one.
    - If your change adds a new API, follow the [API Review Process](https://github.com/LuzFaltex/Contribution/blob/main/docs/api-review-process.md).
    - Clearly state that you are going to take on implementing it, if that's the case. You can request that the issue be assigned to you. Note: The issue filer and the implementer don't have to be the same person.
2. Create a personal fork of the repository on GitHub (if you don't already have one).
3. In your fork, create a branch off of main (`git checkout -b mybranch`).
    - Name the branch so that it clearly communicates your intentions, such as issue-123 or githubhandle-issue.
    - Branches are useful since they isolate your changes from incoming changes from upstream. They also enable you to create multiple PRs from the same fork.
4. Make and commit your changes to your branch.
    - Each commit should include a short but descriptive change message.
5. Add new tests corresponding to your change, if applicable.
6. Build the repository with your changes.
    - Make sure that the builds are clean.
    - Make sure that the tests are all passing, including your new tests.
7. Create a pull request (PR) against the dotnet/runtime repository's **main** branch unless an alternative was specified.
    - State in the description what issue or improvement your change is addressing.
    - Check if all the Continuous Integration checks are passing.
8. Wait for feedback or approval of your changes from the [area owners](docs/area-owners.md).
9. When area owners have signed off, and all checks are green, your PR will be merged.
    - The next official build will automatically include your change.
    - You can delete the branch you used for making the change.

### Up for Grabs

The team marks the most straightforward issues as [up for grabs](https://github.com/Selkhound/Selkhound/labels/up-for-grabs). This set of issues is the place to start if you are interested in contributing but new to the codebase.

### Contributor License Agreement

You must sign a LuzFaltex Contribution License Agreement (CLA)https://cla.dotnetfoundation.org before your PR will be merged. This is a one-time requirement for projects in the .NET Foundation. You can read more about [Contribution License Agreements (CLA)](http://en.wikipedia.org/wiki/Contributor_License_Agreement) on Wikipedia.

The agreement: [contribution-license-agreement-distributable.pdf](https://github.com/LuzFaltex/Contribution/blob/main/docs/contribution-license-agreement-distributable.pdf)

You don't have to do this up-front. You can simply clone, fork, and submit your pull-request as usual. When your pull-request is created, it is classified by a CLA bot. If the change is trivial (for example, you just fixed a typo), then the PR is labelled with `cla-not-required`. Otherwise it's classified as `cla-required`. Once you signed a CLA, the current and all future pull-requests will be labelled as `cla-signed`.

### File Headers

The following file header is the used for .NET Core. Please use it for new files.

```
//
// {fileName}
//
// Author:
//      {author}
//
// ISC License
//
// Copyright (c) {year} {LuzFaltex}
//
// This program is free software: you can redistribute it and\/or modify
// it under the terms of the GNU Affero General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.
//
// You should have received a copy of the GNU Affero General Public License
// along with this program.  If not, see <https:\/\/www.gnu.org\/licenses\/>.
//
```

### PR - CI Process

The continuous integration (CI) system will automatically perform the required builds and run tests (including the ones you are expected to run) for PRs. Builds and test runs must be clean.

If the CI build fails for any reason, the PR issue will be updated with a link that can be used to determine the cause of the failure.

### PR Feedback

LuzFaltex team and community members will provide feedback on your change. Community feedback is highly valued. You will often see the absence of team feedback if the community has already provided good review feedback.

One or more LuzFaltex team members will review every PR prior to merge. They will often reply with "LGTM, modulo comments". That means that the PR will be merged once the feedback is resolved. "LGTM" == "looks good to me".

There are lots of thoughts and [approaches](https://github.com/antlr/antlr4-cpp/blob/master/CONTRIBUTING.md#emoji) for how to efficiently discuss changes. It is best to be clear and explicit with your feedback. Please be patient with people who might not understand the finer details about your approach to feedback.

#### Copying Files from Other Projects

LuzFaltex projects may use some files from other projects, typically where a binary distribution does not exist or would be inconvenient.

The following rules must be followed for PRs that include files from another project:

- The license of the file is [permissive](https://en.wikipedia.org/wiki/Permissive_free_software_licence).
- The license of the file is left intact.
- The contribution is correctly attributed in the [3rd party notices](./THIRD-PARTY-NOTICES.TXT) file in the repository, as needed.

#### Porting Files from Other Projects

There are many good algorithms implemented in other languages that would benefit LuzFaltex projects. The rules for porting a Java file to C#, for example, are the same as would be used for copying the same file, as described above.

[Clean-room](https://en.wikipedia.org/wiki/Clean_room_design) implementations of existing algorithms that are not permissively licensed will generally not be accepted. If you want to create or nominate such an implementation, please create an issue to discuss the idea.
