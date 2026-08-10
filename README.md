<!-- template-ai-native:project-identity:generated -->
<!-- template-ai-native:project-identity:start -->
# Template .NET Pilot

![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)

**Status:** Hosted template validation pilot

Hosted .NET 8 and xUnit validation for the `template-ai-native` consumer
pipeline.

**Stack:** `dotnet`
<!-- template-ai-native:project-identity:end -->

## Purpose

This repository is a small, deterministic consumer used to validate the
template's .NET quality, test, coverage, build, security, artifact, and
provenance contracts on GitHub-hosted runners.

It is not a production service and has no HTTP server, database, cloud
resource, deployment target, AI provider, or committed credential.

## Local workflow

```sh
dotnet restore
make ci
make docs-check
```

The template mapper runs unit tests with `Category=Unit`, integration tests
with `Category=Integration`, E2E tests with `Category=E2E`, and the XPlat
Cobertura collector with an overall 80% line-coverage gate.

## Reusing the template

For a new consumer repository, use the template flow and replace the
placeholders with the actual repository coordinates:

```sh
git clone https://github.com/YOUR-ORG/YOUR-REPO.git
cd YOUR-REPO
```

## Domain behavior

`TicketPriorityClassifier` converts severity, customer impact, and security
incident status into priorities `P1` through `P4`. The tests cover validation,
normalization, category-specific journeys, and the complete deterministic
classification flow.

## Pilot boundary

The hosted result is evidence for this .NET 8/xUnit consumer contract only. It
does not certify ASP.NET Core, deployment, production readiness, or other
frameworks.

The optional Graphify codebase-memory guidance remains available at
[`docs/ai/graphify.md`](docs/ai/graphify.md); this pilot does not activate it.
