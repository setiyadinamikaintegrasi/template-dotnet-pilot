# Template .NET Pilot Architecture

## Boundary

This consumer contains an SDK-style .NET 8 class library at
`src/Domain/TemplateDotnetPilot.csproj` and a separate xUnit test project at
`tests/TemplateDotnetPilot.Tests/`. Test source remains grouped under
`tests/unit`, `tests/integration`, and `tests/e2e`.

## Data flow

```text
test input → TicketPriorityClassifier → Priority result → xUnit assertion
```

There is no network, filesystem, database, queue, clock, or external provider
in the application path.

## CI flow

```text
detect dotnet
  ├─ quality: format → lint → build → unit tests
  ├─ test: integration → E2E → XPlat Cobertura → weighted 80% gate
  └─ build: Release output → build-dotnet artifact
```

Security, documentation, metadata, and provenance workflows remain inherited
from the template. This repository does not alter their permissions, action
pins, or thresholds.
