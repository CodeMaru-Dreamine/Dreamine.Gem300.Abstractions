# Public API Inventory

Assembly: `Dreamine.Gem300.Abstractions`

This inventory is generated from the compiled Release assembly. It is an audit artifact, not an additional compatibility promise.

Exported types: **38**

## Types

### `public interface Dreamine.Gem300.Abstractions.Interfaces.ICarrierManager`

- `Dreamine.Gem300.Abstractions.Model.CarrierSnapshot GetCarrier(System.String carrierId)`
- `Dreamine.Gem300.Abstractions.Model.LoadPortSnapshot GetLoadPort(System.String portId)`
- `System.Void AcceptId(System.String carrierId)`
- `System.Void AcceptSlotMap(System.String carrierId)`
- `System.Void BeginAccess(System.String carrierId)`
- `System.Void BeginLoad(System.String portId)`
- `System.Void BeginUnload(System.String portId)`
- `System.Void Bind(System.String portId, System.String carrierId, System.Int32 capacity)`
- `System.Void CancelReservation(System.String portId)`
- `System.Void ChangeAccessMode(System.String portId, Dreamine.Gem300.Abstractions.States.LoadPortAccessMode accessMode)`
- `System.Void CompleteAccess(System.String carrierId)`
- `System.Void CompleteLoad(System.String portId)`
- `System.Void CompleteUnload(System.String portId)`
- `System.Void PrepareUnload(System.String carrierId)`
- `System.Void RegisterLoadPort(System.String portId, Dreamine.Gem300.Abstractions.States.LoadPortAccessMode accessMode)`
- `System.Void RejectId(System.String carrierId)`
- `System.Void RejectSlotMap(System.String carrierId)`
- `System.Void Reserve(System.String portId)`
- `System.Void SetInService(System.String portId)`
- `System.Void SetOutOfService(System.String portId)`
- `System.Void StopAccess(System.String carrierId)`
- `System.Void WaitForIdDecision(System.String carrierId)`
- `System.Void WaitForSlotMapDecision(System.String carrierId, System.Collections.Generic.IEnumerable<Dreamine.Gem300.Abstractions.States.CarrierSlotState> slotMap)`

### `public interface Dreamine.Gem300.Abstractions.Interfaces.IControlJobManager`

- `Dreamine.Gem300.Abstractions.Model.ControlJobSnapshot Get(System.String id)`
- `System.Void Abort(System.String id)`
- `System.Void Advance(System.String id)`
- `System.Void Complete(System.String id)`
- `System.Void Create(Dreamine.Gem300.Abstractions.Model.ControlJobDefinition definition)`
- `System.Void Delete(System.String id)`
- `System.Void Pause(System.String id)`
- `System.Void Ready(System.String id)`
- `System.Void Resume(System.String id)`
- `System.Void Select(System.String id)`
- `System.Void Start(System.String id)`

### `public interface Dreamine.Gem300.Abstractions.Interfaces.IGem300EventJournal`

- `Dreamine.Gem300.Abstractions.Model.Gem300DomainEvent Record(Dreamine.Gem300.Abstractions.States.Gem300EventKind kind, System.String aggregateId)`
- `System.Collections.Generic.IReadOnlyList<Dreamine.Gem300.Abstractions.Model.Gem300DomainEvent> GetSnapshot()`

### `public interface Dreamine.Gem300.Abstractions.Interfaces.IGem300ObjectService`

- `System.Boolean Remove(Dreamine.Gem300.Abstractions.Model.Gem300ObjectKey key)`
- `System.Boolean TryGetAttribute(Dreamine.Gem300.Abstractions.Model.Gem300ObjectKey key, System.String name, out Dreamine.Secs.Abstractions.Model.SecsItem value)`
- `System.Boolean TrySetAttribute(Dreamine.Gem300.Abstractions.Model.Gem300ObjectKey key, System.String name, Dreamine.Secs.Abstractions.Model.SecsItem value)`
- `System.Collections.Generic.IReadOnlyDictionary<System.String, Dreamine.Secs.Abstractions.Model.SecsItem> GetAttributes(Dreamine.Gem300.Abstractions.Model.Gem300ObjectKey key)`
- `System.Threading.Tasks.ValueTask<Dreamine.Gem.Abstractions.Model.GemCommandResult> ExecuteActionAsync(Dreamine.Gem300.Abstractions.Model.Gem300ObjectKey key, System.String actionName, System.Collections.Generic.IReadOnlyDictionary<System.String, Dreamine.Secs.Abstractions.Model.SecsItem> parameters, System.TimeSpan timeout, System.Threading.CancellationToken cancellationToken)`
- `System.Void Register(Dreamine.Gem300.Abstractions.Model.Gem300ObjectKey key, System.Collections.Generic.IEnumerable<Dreamine.Gem300.Abstractions.Model.Gem300AttributeDefinition> attributes)`
- `System.Void RegisterAction(Dreamine.Gem300.Abstractions.Model.Gem300ObjectKey key, System.String actionName, System.Func<System.Collections.Generic.IReadOnlyDictionary<System.String, Dreamine.Secs.Abstractions.Model.SecsItem>, System.Threading.CancellationToken, System.Threading.Tasks.ValueTask<Dreamine.Gem.Abstractions.Model.GemCommandResult>> handler)`

### `public interface Dreamine.Gem300.Abstractions.Interfaces.IGem300Runtime`

- `Dreamine.Gem.Abstractions.Interfaces.IGemRuntime GemRuntime { get; }`
- `Dreamine.Gem300.Abstractions.Interfaces.ICarrierManager Carriers { get; }`
- `Dreamine.Gem300.Abstractions.Interfaces.IControlJobManager ControlJobs { get; }`
- `Dreamine.Gem300.Abstractions.Interfaces.IGem300EventJournal Events { get; }`
- `Dreamine.Gem300.Abstractions.Interfaces.IGem300ObjectService Objects { get; }`
- `Dreamine.Gem300.Abstractions.Interfaces.IProcessJobManager ProcessJobs { get; }`
- `Dreamine.Gem300.Abstractions.Interfaces.ISubstrateTracker Substrates { get; }`

### `public interface Dreamine.Gem300.Abstractions.Interfaces.IProcessJobManager`

- `Dreamine.Gem300.Abstractions.Model.ProcessJobSnapshot Get(System.String id)`
- `System.Void Abort(System.String id)`
- `System.Void Allocate(System.String id)`
- `System.Void Complete(System.String id)`
- `System.Void CompleteSetup(System.String id)`
- `System.Void ConfirmAborted(System.String id)`
- `System.Void ConfirmPaused(System.String id)`
- `System.Void ConfirmStopped(System.String id)`
- `System.Void Create(Dreamine.Gem300.Abstractions.Model.ProcessJobDefinition definition)`
- `System.Void Delete(System.String id)`
- `System.Void Pause(System.String id)`
- `System.Void Resume(System.String id)`
- `System.Void Start(System.String id)`
- `System.Void Stop(System.String id)`

### `public interface Dreamine.Gem300.Abstractions.Interfaces.ISubstrateTracker`

- `Dreamine.Gem300.Abstractions.Model.SubstrateSnapshot Get(System.String substrateId)`
- `Dreamine.Gem300.Abstractions.States.MaterialLocationState GetLocationState(System.String locationId)`
- `System.Boolean TryGet(System.String substrateId, out Dreamine.Gem300.Abstractions.Model.SubstrateSnapshot substrate)`
- `System.Void BeginProcessing(System.String substrateId)`
- `System.Void CompleteProcessing(System.String substrateId, Dreamine.Gem300.Abstractions.States.SubstrateProcessingState result)`
- `System.Void ConfirmId(System.String substrateId)`
- `System.Void MarkLost(System.String substrateId)`
- `System.Void Move(System.String substrateId, System.String locationId)`
- `System.Void Register(System.String substrateId, System.String sourceLocation, System.String destinationLocation, System.Boolean idConfirmed)`
- `System.Void RejectId(System.String substrateId)`
- `System.Void Remove(System.String substrateId)`

### `public sealed class Dreamine.Gem300.Abstractions.Model.CarrierArrivalPlan`

- `CarrierArrivalPlan(System.String portId, System.String carrierId, System.Collections.Generic.IEnumerable<Dreamine.Gem300.Abstractions.States.CarrierSlotState> slotMap, System.Collections.Generic.IEnumerable<Dreamine.Gem300.Abstractions.Model.SubstrateArrivalPlan> substrates)`
- `CarrierArrivalPlan(System.String portId, System.String carrierId, System.Collections.Generic.IEnumerable<Dreamine.Gem300.Abstractions.States.CarrierSlotState> slotMap, System.Collections.Generic.IEnumerable<Dreamine.Gem300.Abstractions.Model.SubstrateArrivalPlan> substrates, System.Collections.Generic.IEnumerable<Dreamine.Gem300.Abstractions.Model.CarrierSubstrateSlotAssignment> slotAssignments)`
- `System.Boolean HasExplicitSlotAssignments { get; }`
- `System.Collections.Generic.IReadOnlyList<Dreamine.Gem300.Abstractions.Model.CarrierSubstrateSlotAssignment> SlotAssignments { get; }`
- `System.Collections.Generic.IReadOnlyList<Dreamine.Gem300.Abstractions.Model.SubstrateArrivalPlan> Substrates { get; }`
- `System.Collections.Generic.IReadOnlyList<Dreamine.Gem300.Abstractions.States.CarrierSlotState> SlotMap { get; }`
- `System.String CarrierId { get; }`
- `System.String PortId { get; }`

### `public sealed class Dreamine.Gem300.Abstractions.Model.CarrierSnapshot`

- `CarrierSnapshot(System.String id, System.String portId, Dreamine.Gem300.Abstractions.States.CarrierIdStatus idStatus, Dreamine.Gem300.Abstractions.States.CarrierSlotMapStatus slotMapStatus, Dreamine.Gem300.Abstractions.States.CarrierAccessingStatus accessingStatus, System.Collections.Generic.IEnumerable<Dreamine.Gem300.Abstractions.States.CarrierSlotState> slotMap)`
- `Dreamine.Gem300.Abstractions.States.CarrierAccessingStatus AccessingStatus { get; }`
- `Dreamine.Gem300.Abstractions.States.CarrierIdStatus IdStatus { get; }`
- `Dreamine.Gem300.Abstractions.States.CarrierSlotMapStatus SlotMapStatus { get; }`
- `System.Collections.Generic.IReadOnlyList<Dreamine.Gem300.Abstractions.States.CarrierSlotState> SlotMap { get; }`
- `System.String Id { get; }`
- `System.String PortId { get; }`

### `public sealed class Dreamine.Gem300.Abstractions.Model.CarrierSubstrateSlotAssignment`

- `CarrierSubstrateSlotAssignment(System.Int32 slotIndex, System.String substrateId)`
- `System.Int32 SlotIndex { get; }`
- `System.String SubstrateId { get; }`

### `public sealed class Dreamine.Gem300.Abstractions.Model.ControlJobDefinition`

- `ControlJobDefinition(System.String id, System.Collections.Generic.IEnumerable<System.String> processJobIds, System.Boolean manualStart)`
- `System.Boolean ManualStart { get; }`
- `System.Collections.Generic.IReadOnlyList<System.String> ProcessJobIds { get; }`
- `System.String Id { get; }`

### `public sealed class Dreamine.Gem300.Abstractions.Model.ControlJobSnapshot`

- `ControlJobSnapshot(Dreamine.Gem300.Abstractions.Model.ControlJobDefinition definition, Dreamine.Gem300.Abstractions.States.ControlJobState state, System.Int32 currentProcessJobIndex)`
- `Dreamine.Gem300.Abstractions.Model.ControlJobDefinition Definition { get; }`
- `Dreamine.Gem300.Abstractions.States.ControlJobState State { get; }`
- `System.Int32 CurrentProcessJobIndex { get; }`

### `public sealed class Dreamine.Gem300.Abstractions.Model.Gem300AttributeDefinition`

- `Dreamine.Secs.Abstractions.Model.SecsItem InitialValue { get; }`
- `Gem300AttributeDefinition(System.String name, Dreamine.Secs.Abstractions.Model.SecsItem initialValue, System.Boolean writable)`
- `System.Boolean Writable { get; }`
- `System.String Name { get; }`

### `public sealed class Dreamine.Gem300.Abstractions.Model.Gem300DomainEvent`

- `Dreamine.Gem300.Abstractions.States.Gem300EventKind Kind { get; }`
- `Gem300DomainEvent(System.Guid journalId, System.Int64 sequence, Dreamine.Gem300.Abstractions.States.Gem300EventKind kind, System.String aggregateType, System.String aggregateId, System.DateTimeOffset occurredAt)`
- `Gem300DomainEvent(System.Int64 sequence, Dreamine.Gem300.Abstractions.States.Gem300EventKind kind, System.String aggregateId, System.DateTimeOffset occurredAt)`
- `System.DateTimeOffset OccurredAt { get; }`
- `System.Guid JournalId { get; }`
- `System.Int64 Sequence { get; }`
- `System.String AggregateId { get; }`
- `System.String AggregateType { get; }`

### `public sealed class Dreamine.Gem300.Abstractions.Model.Gem300EventJournalHealth`

- `Gem300EventJournalHealth(System.Guid journalId, System.Int32 capacity, System.Int32 retainedCount, System.Int64 totalRecorded, System.Int64 droppedCount, System.Nullable<System.Int64> firstRetainedSequence, System.Nullable<System.Int64> lastRetainedSequence)`
- `System.Guid JournalId { get; }`
- `System.Int32 Capacity { get; }`
- `System.Int32 RetainedCount { get; }`
- `System.Int64 DroppedCount { get; }`
- `System.Int64 TotalRecorded { get; }`
- `System.Nullable<System.Int64> FirstRetainedSequence { get; }`
- `System.Nullable<System.Int64> LastRetainedSequence { get; }`

### `public sealed class Dreamine.Gem300.Abstractions.Model.Gem300EventPublisherHealth`

- `Gem300EventPublisherHealth(System.Int64 failureCount, System.String lastError, System.Nullable<System.DateTimeOffset> lastFailureAt)`
- `System.Int64 FailureCount { get; }`
- `System.Nullable<System.DateTimeOffset> LastFailureAt { get; }`
- `System.String LastError { get; }`

### `public sealed class Dreamine.Gem300.Abstractions.Model.Gem300ObjectKey`

- `Gem300ObjectKey(System.String objectType, System.String objectId)`
- `System.Boolean Equals(Dreamine.Gem300.Abstractions.Model.Gem300ObjectKey other)`
- `System.Boolean Equals(System.Object obj)`
- `System.Int32 GetHashCode()`
- `System.String ObjectId { get; }`
- `System.String ObjectType { get; }`

### `public sealed class Dreamine.Gem300.Abstractions.Model.LoadPortSnapshot`

- `Dreamine.Gem300.Abstractions.States.CarrierAssociationState AssociationState { get; }`
- `Dreamine.Gem300.Abstractions.States.LoadPortAccessMode AccessMode { get; }`
- `Dreamine.Gem300.Abstractions.States.LoadPortReservationState ReservationState { get; }`
- `Dreamine.Gem300.Abstractions.States.LoadPortTransferState TransferState { get; }`
- `LoadPortSnapshot(System.String id, Dreamine.Gem300.Abstractions.States.LoadPortTransferState transfer, Dreamine.Gem300.Abstractions.States.LoadPortAccessMode access, Dreamine.Gem300.Abstractions.States.LoadPortReservationState reservation, Dreamine.Gem300.Abstractions.States.CarrierAssociationState association, System.String carrierId)`
- `System.String CarrierId { get; }`
- `System.String Id { get; }`

### `public sealed class Dreamine.Gem300.Abstractions.Model.ProcessJobDefinition`

- `ProcessJobDefinition(System.String id, System.String recipeId, System.Collections.Generic.IEnumerable<System.String> materialIds, System.Boolean manualStart)`
- `System.Boolean ManualStart { get; }`
- `System.Collections.Generic.IReadOnlyList<System.String> MaterialIds { get; }`
- `System.String Id { get; }`
- `System.String RecipeId { get; }`

### `public sealed class Dreamine.Gem300.Abstractions.Model.ProcessJobSnapshot`

- `Dreamine.Gem.Abstractions.Model.GemProcessProgram ProcessProgram { get; }`
- `Dreamine.Gem300.Abstractions.Model.ProcessJobDefinition Definition { get; }`
- `Dreamine.Gem300.Abstractions.States.ProcessJobState State { get; }`
- `ProcessJobSnapshot(Dreamine.Gem300.Abstractions.Model.ProcessJobDefinition definition, Dreamine.Gem300.Abstractions.States.ProcessJobState state)`
- `ProcessJobSnapshot(Dreamine.Gem300.Abstractions.Model.ProcessJobDefinition definition, Dreamine.Gem300.Abstractions.States.ProcessJobState state, Dreamine.Gem.Abstractions.Model.GemProcessProgram processProgram)`

### `public sealed class Dreamine.Gem300.Abstractions.Model.SubstrateArrivalPlan`

- `SubstrateArrivalPlan(System.String substrateId, System.String sourceLocation, System.String destinationLocation)`
- `System.String DestinationLocation { get; }`
- `System.String SourceLocation { get; }`
- `System.String SubstrateId { get; }`

### `public sealed class Dreamine.Gem300.Abstractions.Model.SubstrateLocationHistory`

- `SubstrateLocationHistory(System.String locationId, System.DateTimeOffset timeIn, System.Nullable<System.DateTimeOffset> timeOut)`
- `System.DateTimeOffset TimeIn { get; }`
- `System.Nullable<System.DateTimeOffset> TimeOut { get; }`
- `System.String LocationId { get; }`

### `public sealed class Dreamine.Gem300.Abstractions.Model.SubstrateSnapshot`

- `Dreamine.Gem300.Abstractions.States.SubstrateIdStatus IdStatus { get; }`
- `Dreamine.Gem300.Abstractions.States.SubstrateProcessingState ProcessingState { get; }`
- `Dreamine.Gem300.Abstractions.States.SubstrateTransportState TransportState { get; }`
- `SubstrateSnapshot(System.String id, System.String source, System.String destination, System.String currentLocation, Dreamine.Gem300.Abstractions.States.SubstrateTransportState transport, Dreamine.Gem300.Abstractions.States.SubstrateProcessingState processing, Dreamine.Gem300.Abstractions.States.SubstrateIdStatus idStatus, System.Collections.Generic.IEnumerable<Dreamine.Gem300.Abstractions.Model.SubstrateLocationHistory> history)`
- `System.Collections.Generic.IReadOnlyList<Dreamine.Gem300.Abstractions.Model.SubstrateLocationHistory> History { get; }`
- `System.String CurrentLocation { get; }`
- `System.String Destination { get; }`
- `System.String Id { get; }`
- `System.String Source { get; }`

### `public enum Dreamine.Gem300.Abstractions.States.CarrierAccessingStatus`

- `const Dreamine.Gem300.Abstractions.States.CarrierAccessingStatus CarrierComplete = 2`
- `const Dreamine.Gem300.Abstractions.States.CarrierAccessingStatus CarrierStopped = 3`
- `const Dreamine.Gem300.Abstractions.States.CarrierAccessingStatus InAccess = 1`
- `const Dreamine.Gem300.Abstractions.States.CarrierAccessingStatus NotAccessed = 0`

### `public enum Dreamine.Gem300.Abstractions.States.CarrierAssociationState`

- `const Dreamine.Gem300.Abstractions.States.CarrierAssociationState Associated = 1`
- `const Dreamine.Gem300.Abstractions.States.CarrierAssociationState NotAssociated = 0`

### `public enum Dreamine.Gem300.Abstractions.States.CarrierIdStatus`

- `const Dreamine.Gem300.Abstractions.States.CarrierIdStatus IdNotRead = 0`
- `const Dreamine.Gem300.Abstractions.States.CarrierIdStatus VerificationFailed = 3`
- `const Dreamine.Gem300.Abstractions.States.CarrierIdStatus VerificationOk = 2`
- `const Dreamine.Gem300.Abstractions.States.CarrierIdStatus WaitingForHost = 1`

### `public enum Dreamine.Gem300.Abstractions.States.CarrierSlotMapStatus`

- `const Dreamine.Gem300.Abstractions.States.CarrierSlotMapStatus SlotMapNotRead = 0`
- `const Dreamine.Gem300.Abstractions.States.CarrierSlotMapStatus VerificationFailed = 3`
- `const Dreamine.Gem300.Abstractions.States.CarrierSlotMapStatus VerificationOk = 2`
- `const Dreamine.Gem300.Abstractions.States.CarrierSlotMapStatus WaitingForHost = 1`

### `public enum Dreamine.Gem300.Abstractions.States.CarrierSlotState`

- `const Dreamine.Gem300.Abstractions.States.CarrierSlotState CorrectlyOccupied = 3`
- `const Dreamine.Gem300.Abstractions.States.CarrierSlotState CrossSlotted = 5`
- `const Dreamine.Gem300.Abstractions.States.CarrierSlotState DoubleSlotted = 4`
- `const Dreamine.Gem300.Abstractions.States.CarrierSlotState Empty = 1`
- `const Dreamine.Gem300.Abstractions.States.CarrierSlotState NotEmpty = 2`
- `const Dreamine.Gem300.Abstractions.States.CarrierSlotState Undefined = 0`

### `public enum Dreamine.Gem300.Abstractions.States.ControlJobState`

- `const Dreamine.Gem300.Abstractions.States.ControlJobState Completed = 5`
- `const Dreamine.Gem300.Abstractions.States.ControlJobState Executing = 3`
- `const Dreamine.Gem300.Abstractions.States.ControlJobState Paused = 4`
- `const Dreamine.Gem300.Abstractions.States.ControlJobState Queued = 0`
- `const Dreamine.Gem300.Abstractions.States.ControlJobState Selected = 1`
- `const Dreamine.Gem300.Abstractions.States.ControlJobState WaitingForStart = 2`

### `public enum Dreamine.Gem300.Abstractions.States.Gem300EventKind`

- `const Dreamine.Gem300.Abstractions.States.Gem300EventKind CarrierChanged = 2`
- `const Dreamine.Gem300.Abstractions.States.Gem300EventKind ControlJobChanged = 5`
- `const Dreamine.Gem300.Abstractions.States.Gem300EventKind LoadPortChanged = 1`
- `const Dreamine.Gem300.Abstractions.States.Gem300EventKind ObjectChanged = 0`
- `const Dreamine.Gem300.Abstractions.States.Gem300EventKind ProcessJobChanged = 4`
- `const Dreamine.Gem300.Abstractions.States.Gem300EventKind SubstrateChanged = 3`

### `public enum Dreamine.Gem300.Abstractions.States.LoadPortAccessMode`

- `const Dreamine.Gem300.Abstractions.States.LoadPortAccessMode Automatic = 1`
- `const Dreamine.Gem300.Abstractions.States.LoadPortAccessMode Manual = 0`

### `public enum Dreamine.Gem300.Abstractions.States.LoadPortReservationState`

- `const Dreamine.Gem300.Abstractions.States.LoadPortReservationState NotReserved = 0`
- `const Dreamine.Gem300.Abstractions.States.LoadPortReservationState Reserved = 1`

### `public enum Dreamine.Gem300.Abstractions.States.LoadPortTransferState`

- `const Dreamine.Gem300.Abstractions.States.LoadPortTransferState OutOfService = 0`
- `const Dreamine.Gem300.Abstractions.States.LoadPortTransferState ReadyToLoad = 2`
- `const Dreamine.Gem300.Abstractions.States.LoadPortTransferState ReadyToUnload = 3`
- `const Dreamine.Gem300.Abstractions.States.LoadPortTransferState TransferBlocked = 1`

### `public enum Dreamine.Gem300.Abstractions.States.MaterialLocationState`

- `const Dreamine.Gem300.Abstractions.States.MaterialLocationState Occupied = 1`
- `const Dreamine.Gem300.Abstractions.States.MaterialLocationState Unoccupied = 0`

### `public enum Dreamine.Gem300.Abstractions.States.ProcessJobState`

- `const Dreamine.Gem300.Abstractions.States.ProcessJobState Aborted = 10`
- `const Dreamine.Gem300.Abstractions.States.ProcessJobState Aborting = 7`
- `const Dreamine.Gem300.Abstractions.States.ProcessJobState Paused = 5`
- `const Dreamine.Gem300.Abstractions.States.ProcessJobState Pausing = 4`
- `const Dreamine.Gem300.Abstractions.States.ProcessJobState ProcessComplete = 8`
- `const Dreamine.Gem300.Abstractions.States.ProcessJobState Processing = 3`
- `const Dreamine.Gem300.Abstractions.States.ProcessJobState Queued = 0`
- `const Dreamine.Gem300.Abstractions.States.ProcessJobState SettingUp = 1`
- `const Dreamine.Gem300.Abstractions.States.ProcessJobState Stopped = 9`
- `const Dreamine.Gem300.Abstractions.States.ProcessJobState Stopping = 6`
- `const Dreamine.Gem300.Abstractions.States.ProcessJobState WaitingForStart = 2`

### `public enum Dreamine.Gem300.Abstractions.States.SubstrateIdStatus`

- `const Dreamine.Gem300.Abstractions.States.SubstrateIdStatus ConfirmationFailed = 3`
- `const Dreamine.Gem300.Abstractions.States.SubstrateIdStatus Confirmed = 2`
- `const Dreamine.Gem300.Abstractions.States.SubstrateIdStatus NotConfirmed = 0`
- `const Dreamine.Gem300.Abstractions.States.SubstrateIdStatus WaitingForHost = 1`

### `public enum Dreamine.Gem300.Abstractions.States.SubstrateProcessingState`

- `const Dreamine.Gem300.Abstractions.States.SubstrateProcessingState Aborted = 3`
- `const Dreamine.Gem300.Abstractions.States.SubstrateProcessingState InProcess = 1`
- `const Dreamine.Gem300.Abstractions.States.SubstrateProcessingState Lost = 5`
- `const Dreamine.Gem300.Abstractions.States.SubstrateProcessingState NeedsProcessing = 0`
- `const Dreamine.Gem300.Abstractions.States.SubstrateProcessingState Processed = 2`
- `const Dreamine.Gem300.Abstractions.States.SubstrateProcessingState Rejected = 4`
- `const Dreamine.Gem300.Abstractions.States.SubstrateProcessingState Skipped = 7`
- `const Dreamine.Gem300.Abstractions.States.SubstrateProcessingState Stopped = 6`

### `public enum Dreamine.Gem300.Abstractions.States.SubstrateTransportState`

- `const Dreamine.Gem300.Abstractions.States.SubstrateTransportState AtDestination = 2`
- `const Dreamine.Gem300.Abstractions.States.SubstrateTransportState AtSource = 0`
- `const Dreamine.Gem300.Abstractions.States.SubstrateTransportState AtWork = 1`
