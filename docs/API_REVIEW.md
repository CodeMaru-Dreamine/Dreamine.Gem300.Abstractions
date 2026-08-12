# Public API review

Review date: 2026-08-12. Baseline: 1.0.0 source. The generated surface is in
[PUBLIC_API.md](PUBLIC_API.md).

## Result

- Reference direction remains `Gem300.Abstractions -> Gem.Abstractions + Secs.Abstractions`; no concrete GEM300, GEM, or HSMS implementation type is exposed.
- Existing interfaces and existing public constructors remain present. No interface member was removed or changed.
- New public models and members are additive. Their names describe process-local domain behavior and do not imply `.1` wire services.
- Collection-bearing definitions and snapshots copy input and expose read-only views.

## Additive surface

| Surface | Compatibility | Purpose |
|---|---|---|
| `Gem300EventJournalHealth` and `Gem300EventPublisherHealth` | Additive | Expose journal identity/retention/drop state and non-throwing publisher failure state |
| `Gem300DomainEvent(Guid, ..., aggregateType, ...)`, `JournalId`, and `AggregateType` | Additive; legacy constructor retained | Disambiguate aggregate and journal identity without treating sequence as globally unique |
| `ProcessJobSnapshot(..., GemProcessProgram)` and `ProcessProgram` | Additive; legacy constructor retained | Preserve the Process Program accepted under the requested Recipe ID |
| `CarrierSubstrateSlotAssignment` | Additive | Represent an explicit application-level slot/substrate association |
| Five-argument `CarrierArrivalPlan`, `HasExplicitSlotAssignments`, and `SlotAssignments` | Additive; four-argument constructor retained | Prevent ordering or location text from being inferred as a slot mapping |

## Behavior tightening

- Undefined `Gem300EventKind` and `CarrierSlotState` numeric values are rejected.
- Explicit slot assignments must cover every planned substrate and occupied slot exactly once.
- The legacy four-argument arrival-plan constructor remains source and binary compatible, but it does not invent assignments; the concrete safe workflow rejects a non-empty plan without explicit assignments before mutation.
- Domain events with full identity reject an empty journal ID or missing aggregate identity.

These validation changes can expose previously accepted invalid input. They are
intentional correctness tightening, not a new wire contract.

## Deferred breaking candidates

| Classification | Proposal | Reason |
|---|---|---|
| Source- and binary-breaking | Add an explicit aborted terminal state for Control Jobs | The current base-revision model maps abort to `Completed`; changing the enum would alter exhaustive consumer logic |
| Source- and binary-breaking | Add journal health/query members to `IGem300EventJournal` | Concrete members exist, but changing the interface would break third-party implementations |

E39.1, E40.1, E87.1, E90.1, and E94.1 wire contracts remain
`BLOCKED_STANDARD`. E116/E116.1 contracts also remain `BLOCKED_STANDARD`.
External and field verification remain `NOT_RUN`.
