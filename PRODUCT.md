# Template .NET Pilot Product

**Status:** Hosted validation pilot

## Product vision

Provide auditable evidence that a fresh .NET 8/xUnit consumer can adopt the
template-ai-native quality, security, build, artifact, and provenance controls
without framework or infrastructure dependencies.

## Users

- Template maintainers evaluating .NET adoption readiness.
- Consumer engineers deciding whether the generic .NET baseline is usable.
- Security and platform reviewers checking inherited controls.

## Business value

Reduce adoption risk by detecting .NET-specific workflow gaps before a real
service depends on the template.

## Scope

- Deterministic ticket-priority domain logic in a .NET class library.
- A separate xUnit test project that exercises the library through unit,
  integration, and E2E categories.
- Unit, integration, E2E, coverage, quality, build, and hosted security checks.
- Build artifact and post-merge provenance evidence.

## Out of scope

- Production service behavior, HTTP, persistence, authentication, deployment,
  AI providers, profile activation, and operational readiness.

## Success metrics

- Every applicable .NET PR job executes and passes.
- Overall line coverage is at least 80%.
- A .NET build artifact and post-merge attestation are produced.
- No inherited security control is weakened.
