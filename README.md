# Dreamine.Gem300.Abstractions

[![CI](https://github.com/CodeMaru-Dreamine/Dreamine.Gem300.Abstractions/actions/workflows/ci.yml/badge.svg)](https://github.com/CodeMaru-Dreamine/Dreamine.Gem300.Abstractions/actions/workflows/ci.yml)
[![Quality Gate](https://sonarcloud.io/api/project_badges/measure?project=CodeMaru-Dreamine_Dreamine.Gem300.Abstractions&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=CodeMaru-Dreamine_Dreamine.Gem300.Abstractions) [![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=CodeMaru-Dreamine_Dreamine.Gem300.Abstractions&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=CodeMaru-Dreamine_Dreamine.Gem300.Abstractions) [![Coverage](https://sonarcloud.io/api/project_badges/measure?project=CodeMaru-Dreamine_Dreamine.Gem300.Abstractions&metric=coverage)](https://sonarcloud.io/summary/new_code?id=CodeMaru-Dreamine_Dreamine.Gem300.Abstractions)

Provider-neutral contracts, immutable models, and state enumerations for the
GEM300 in-memory domain boundary.

[➡️ 한국어 문서 보기](https://github.com/CodeMaru-Dreamine/Dreamine.Gem300.Abstractions/blob/main/README_KO.md)

## Install

```powershell
dotnet add package Dreamine.Gem300.Abstractions
```

Choose this package for process-local GEM300 contracts without a concrete runtime. Applications that need carrier, substrate, Process Job, and Control Job managers should start with [`Dreamine.Gem300`](https://www.nuget.org/packages/Dreamine.Gem300).

## Scope and evidence

| Capability | Status | Evidence boundary |
|---|---|---|
| GEM300 domain contracts and models | `PASS` | Focused model, validation, and assembly-boundary tests |
| E39.1/E40.1/E87.1/E90.1/E94.1 standard wire contracts | `BLOCKED_STANDARD` | The required mapping originals were not available locally |
| E116/E116.1 Equipment Performance contracts | `BLOCKED_STANDARD` | Neither normative original was available; no placeholder API is published |
| External interoperability and field evidence | `NOT_RUN` | No independent counterpart or equipment evidence was executed |

`PASS` is limited to the declared process-local domain boundary. It does not
mean current-revision conformance, certification, a SECS-II mapping, or vendor
interoperability.

## Included contracts

- Object, carrier/load-port, substrate, Process Job, Control Job, and event-journal boundaries
- Immutable definitions and snapshots with copied collection inputs
- Application-declared carrier slot/substrate assignments; these are integration metadata, not wire models
- Process-local event identity and bounded-retention/publisher health models
- A retained Process Program snapshot model for verifying recipe identity at Process Job creation

The package references only `Dreamine.Gem.Abstractions` and
`Dreamine.Secs.Abstractions`. It contains no concrete GEM/GEM300 provider,
transport, message number, ACK value, or service-error value.

Existing interfaces and constructors remain available. The hardening surface
is additive, while invalid enum values and inconsistent explicit slot plans are
rejected earlier. See [API review](https://github.com/CodeMaru-Dreamine/Dreamine.Gem300.Abstractions/blob/main/docs/API_REVIEW.md) and the generated
[public API inventory](https://github.com/CodeMaru-Dreamine/Dreamine.Gem300.Abstractions/blob/main/docs/PUBLIC_API.md).

## License

MIT.
