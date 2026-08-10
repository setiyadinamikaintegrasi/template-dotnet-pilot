# Template .NET Pilot Design

**Status:** Approved 2026-08-10

## Problem

Local mapper contracts do not prove that the inherited .NET workflow succeeds
on GitHub-hosted runners with a real SDK project, categorized tests, XPlat
coverage output, and a Release artifact.

## Decision

Implement a framework-free .NET 8 class library containing a
`TicketPriorityClassifier`, plus a separate xUnit test project. The classifier accepts
severity, customer impact, and a security-incident flag and returns `P1`,
`P2`, `P3`, or `P4`.

## Business rules

1. A security incident or critical severity returns `P1`.
2. High severity or business-wide impact returns `P2`.
3. Medium severity or multiple-user impact returns `P3`.
4. All other supported combinations return `P4`.
5. Blank and unsupported values fail with `ArgumentException`.
6. The public boundary accepts case-insensitive values, surrounding whitespace,
   and hyphenated enum words.

## Quality contract

- Unit tests use `Category=Unit`.
- Integration tests use `Category=Integration`.
- E2E tests use `Category=E2E`.
- XPlat Cobertura coverage must meet the template's overall 80% line threshold.
- `dotnet build -c Release` must produce a packageable `bin/Release/` output.

## Acceptance criteria

- The repository is created from the published template, not copied selectively.
- `scripts/detect-stack.sh` reports `dotnet`.
- The solution contains separate production and test projects so coverage can
  instrument the referenced production assembly.
- Local `make ci` and `make docs-check` pass before the consumer PR.
- Hosted .NET quality, categorized tests, coverage, and build jobs pass.
- Blocking security and governance checks pass without policy weakening.
- The post-merge main run produces a build artifact and provenance attestation.

## Non-goals

ASP.NET Core, HTTP, authentication, databases, deployment, cloud resources, AI
providers, profile activation, and production readiness are not evaluated.
