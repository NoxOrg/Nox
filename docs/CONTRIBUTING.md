# Contributing to Nox.Generator

We welcome pull requests for new features, application enhancements, bug fixes and documentation. We strongly encourage you to take some time to familiarise yourself with the project and its stated objectives. This will ultimately assist you in putting your proposed contribution in the appropriate context.

Here are some useful links to information that will aid in your understanding of the Nox.Generator project:

- Documentation for this project can be found [here](/docs).
- Technical documentatation for Nox.Generator can be found [here](https://noxorg.dev/).

## Choosing an issue

All contributions should address an [open issue](https://github.com/NoxOrg/Nox.Generator/issues) in the [Nox.Generator](https://github.com/NoxOrg/Nox.Generator) repo.

### Bugs versus enhancements

Issues are typically labeled with [Enhancement](https://github.com/NoxOrg/Nox.Generator/issues?q=is%3Aopen+is%3Aissue+label%3AEnhancement) or [Bug](https://github.com/NoxOrg/Nox.Generator/issues?q=is%3Aopen+is%3Aissue+label%3ABug).

- Bugs are places where Nox.Generator is doing something that it was not designed to.
- Enhancements are suggestions to improve Nox.Generator by changing existing or adding new functionality.

### Create an issue

If there is no existing issue tracking the change you want to make, then [create one](https://github.com/NoxOrg/Nox.Generator/issues/new/choose)! PRs that don't get merged are often those that are created without any prior discussion with the team. An issue is the best place to have that discussion, ideally before the PR is submitted.

### Fixing typos

An issue is not required for simple non-code changes like fixing a typo in documentation. In fact, these changes can often be submitted as a PR directly from the browser, avoiding the need to fork and clone.

## Workflow

The typical workflow for contributing to Nox.Generator is outlined below. This is not a set-in-stone process, but rather guidelines to help ensure a quality PR that we can merge efficiently.

1. Start by [setting up your development environment](./docs/README_github_full.md#Prerequisites) so that you can build and test the code. Don't forget to [create a fork](https://github.com/NoxOrg/Nox.Generator#creating-a-project) for your work.
2. Make sure all tests are passing. (This is typically done by running `test` at a command prompt.)
3. Choose an issue (see above), understand it, and **comment on the issue** indicating what you intend to do to fix it. **This communication with the team is very important and often helps avoid throwing away lots of work caused by taking the wrong approach.**
4. Create and check out a [branch](https://docs.github.com/en/github/collaborating-with-issues-and-pull-requests/creating-and-deleting-branches-within-your-repository) in your local clone. You will use this branch to prepare your PR.
5. Make appropriate code and test changes. Follow the patterns and code style that you see in the existing code. Make sure to add tests that fail without the change and then pass with the change.
6. Consider other scenarios where your change may have an impact and add more testing. We always prefer having too many tests to having not enough of them.
7. When you are done with changes, make sure _all_ existing tests are still passing. (Again, typically by running `test` at a command prompt.)
8. Commit changes to your branch and push the branch to your GitHub fork.
9. Go to the main [Nox.Generator repo](https://github.com/NoxOrg/Nox.Generator/pulls) and you should see a yellow box suggesting you create a PR from your fork. Do this, or [create the PR by some other mechanism](https://docs.github.com/en/github/collaborating-with-issues-and-pull-requests/about-pull-requests).
10. Wait for the feedback from the team and for the continuous integration (C.I.) checks to pass.
11. Add and push new commits to your branch to address any issues.

The PR will be merged by a member of the Nox.Generator Team once the C.I. checks have passed and the code has been approved.

[version-shield]: https://img.shields.io/nuget/v/Nox.Generator.svg?style=for-the-badge

[version-url]: https://www.nuget.org/packages/Nox.Generator

[build-shield]: https://img.shields.io/github/actions/workflow/status/NoxOrg/Nox.Generator/?branch=main&event=push&label=Build&style=for-the-badge

[build-url]: https://github.com/NoxOrg/Nox.Generator/actions/workflows/?query=branch%3Amain

[contributors-shield]: https://img.shields.io/github/contributors/NoxOrg/Nox.Generator.svg?style=for-the-badge

[contributors-url]: https://github.com/NoxOrg/Nox.Generator/graphs/contributors

[forks-shield]: https://img.shields.io/github/forks/NoxOrg/Nox.Generator.svg?style=for-the-badge

[forks-url]: https://github.com/NoxOrg/Nox.Generator/network/members

[stars-shield]: https://img.shields.io/github/stars/NoxOrg/Nox.Generator.svg?style=for-the-badge

[stars-url]: https://github.com/NoxOrg/Nox.Generator/stargazers

[issues-shield]: https://img.shields.io/github/issues/NoxOrg/Nox.Generator.svg?style=for-the-badge

[issues-url]: https://github.com/NoxOrg/Nox.Generator/issues
