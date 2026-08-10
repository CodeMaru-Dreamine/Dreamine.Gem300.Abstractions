# Public API review

Review date: 2026-08-10. Baseline: 1.0.0 source. See [PUBLIC_API.md](PUBLIC_API.md).

## Result

- Reference direction is `Gem300.Abstractions -> Gem.Abstractions + Secs.Abstractions`; no concrete GEM300/GEM/HSMS type or cycle is present.
- Definitions snapshot enumerable input and expose read-only collections.
- Async object action/workflow boundaries accept cancellation; synchronous state-machine operations are deliberately in-process and immediate.
- No public signature or binary surface changed.

## Next-version proposals

| Classification | Proposal | Reason |
|---|---|---|
| Source- and binary-breaking | Add an explicit `Aborted` control-job state | Abort currently terminates at `Completed`; extending the enum changes exhaustive consumer logic. |
| Source- and binary-breaking | Model Process Job ownership in a shared repository contract | Independent managers cannot prevent all removed-object references without a cross-module ownership boundary. |
| Non-breaking candidate | Add idempotency keys to workflow commands | Retry behavior is currently operation/state specific rather than a protocol-wide contract. |

These are domain contracts, not standard wire mappings. No ACK value, service error number, or unavailable normative rule is inferred by the API.
