using System.Collections.ObjectModel;
using Dreamine.Gem300.Abstractions.States;
using Dreamine.Secs.Abstractions.Model;

namespace Dreamine.Gem300.Abstractions.Model;

/// <summary>\if KO E39 객체 유형과 객체 ID로 구성된 강타입 키입니다. \endif \if EN Represents a strongly typed E39 object-type/object-ID key. \endif</summary>
public sealed class Gem300ObjectKey : IEquatable<Gem300ObjectKey>
{
    /// <summary>\if KO 객체 키를 만듭니다. \endif \if EN Creates an object key. \endif</summary>
    public Gem300ObjectKey(string objectType, string objectId)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(objectType); ArgumentException.ThrowIfNullOrWhiteSpace(objectId);
        if (objectType.Contains('>') || objectType.Contains(':') || objectId.Contains('>') || objectId.Contains(':')) throw new ArgumentException("Object keys cannot contain '>' or ':'.");
        ObjectType = objectType; ObjectId = objectId;
    }
    /// <summary>\if KO 객체 유형입니다. \endif \if EN Gets the object type. \endif</summary>
    public string ObjectType { get; }
    /// <summary>\if KO 객체 ID입니다. \endif \if EN Gets the object ID. \endif</summary>
    public string ObjectId { get; }
    /// <inheritdoc />
    public bool Equals(Gem300ObjectKey? other) => other is not null && StringComparer.Ordinal.Equals(ObjectType, other.ObjectType) && StringComparer.Ordinal.Equals(ObjectId, other.ObjectId);
    /// <inheritdoc />
    public override bool Equals(object? obj) => Equals(obj as Gem300ObjectKey);
    /// <inheritdoc />
    public override int GetHashCode() => HashCode.Combine(StringComparer.Ordinal.GetHashCode(ObjectType), StringComparer.Ordinal.GetHashCode(ObjectId));
}

/// <summary>\if KO E39 공개 속성 정의입니다. \endif \if EN Represents an E39 public-attribute definition. \endif</summary>
public sealed class Gem300AttributeDefinition
{
    /// <summary>\if KO 속성 정의를 만듭니다. \endif \if EN Creates an attribute definition. \endif</summary>
    public Gem300AttributeDefinition(string name, SecsItem initialValue, bool writable)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name); ArgumentNullException.ThrowIfNull(initialValue); Name = name; InitialValue = initialValue; Writable = writable;
    }
    /// <summary>\if KO 속성 이름입니다. \endif \if EN Gets the attribute name. \endif</summary>
    public string Name { get; }
    /// <summary>\if KO 초기값입니다. \endif \if EN Gets the initial value. \endif</summary>
    public SecsItem InitialValue { get; }
    /// <summary>\if KO 쓰기 가능 여부입니다. \endif \if EN Gets whether the attribute is writable. \endif</summary>
    public bool Writable { get; }
}

/// <summary>\if KO GEM300 Aggregate 변경의 불변 자체 도메인 이벤트입니다. \endif \if EN Represents an immutable application-domain event for a GEM300 aggregate change. \endif</summary>
public sealed class Gem300DomainEvent
{
    /// <summary>\if KO 도메인 이벤트를 만듭니다. \endif \if EN Creates a domain event. \endif</summary>
    public Gem300DomainEvent(long sequence, Gem300EventKind kind, string aggregateId, DateTimeOffset occurredAt)
        : this(Guid.NewGuid(), sequence, kind, kind.ToString(), aggregateId, occurredAt) { }
    /// <summary>\if KO 저널 및 Aggregate 유형을 포함하는 도메인 이벤트를 만듭니다. \endif \if EN Creates a domain event with journal and aggregate-type identity. \endif</summary>
    public Gem300DomainEvent(Guid journalId, long sequence, Gem300EventKind kind, string aggregateType, string aggregateId, DateTimeOffset occurredAt)
    {
        if (journalId == Guid.Empty) throw new ArgumentException("Journal ID cannot be empty.", nameof(journalId));
        if (sequence <= 0) throw new ArgumentOutOfRangeException(nameof(sequence));
        if (!Enum.IsDefined(kind)) throw new ArgumentOutOfRangeException(nameof(kind));
        ArgumentException.ThrowIfNullOrWhiteSpace(aggregateType); ArgumentException.ThrowIfNullOrWhiteSpace(aggregateId);
        JournalId = journalId; Sequence = sequence; Kind = kind; AggregateType = aggregateType; AggregateId = aggregateId; OccurredAt = occurredAt;
    }
    /// <summary>\if KO 이 이벤트를 생성한 프로세스 내 저널의 고유 ID입니다. \endif \if EN Gets the unique ID of the process-local journal that produced this event. \endif</summary>
    public Guid JournalId { get; }
    /// <summary>\if KO 프로세스 내 단조 증가 순서입니다. \endif \if EN Gets the process-local monotonic sequence. \endif</summary>
    public long Sequence { get; }
    /// <summary>\if KO 이벤트 종류입니다. \endif \if EN Gets the event kind. \endif</summary>
    public Gem300EventKind Kind { get; }
    /// <summary>\if KO Aggregate 유형입니다. \endif \if EN Gets the aggregate type. \endif</summary>
    public string AggregateType { get; }
    /// <summary>\if KO Aggregate 식별자입니다. \endif \if EN Gets the aggregate identifier. \endif</summary>
    public string AggregateId { get; }
    /// <summary>\if KO 발생 시각입니다. \endif \if EN Gets the occurrence time. \endif</summary>
    public DateTimeOffset OccurredAt { get; }
}

/// <summary>\if KO 기판 위치 체류 이력의 불변 항목입니다. \endif \if EN Represents an immutable substrate location-history entry. \endif</summary>
public sealed class SubstrateLocationHistory
{
    /// <summary>\if KO 위치 이력 항목을 만듭니다. \endif \if EN Creates a location-history entry. \endif</summary>
    public SubstrateLocationHistory(string locationId, DateTimeOffset timeIn, DateTimeOffset? timeOut)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(locationId); if (timeOut < timeIn) throw new ArgumentOutOfRangeException(nameof(timeOut)); LocationId = locationId; TimeIn = timeIn; TimeOut = timeOut;
    }
    /// <summary>\if KO 위치 식별자입니다. \endif \if EN Gets the location identifier. \endif</summary>
    public string LocationId { get; }
    /// <summary>\if KO 진입 시각입니다. \endif \if EN Gets the entry time. \endif</summary>
    public DateTimeOffset TimeIn { get; }
    /// <summary>\if KO 퇴장 시각이며 현재 위치이면 null입니다. \endif \if EN Gets the exit time, or null for the current location. \endif</summary>
    public DateTimeOffset? TimeOut { get; }
}

/// <summary>\if KO 로드 포트 상태의 불변 스냅샷입니다. \endif \if EN Represents an immutable load-port snapshot. \endif</summary>
public sealed class LoadPortSnapshot
{
    /// <summary>\if KO 로드 포트 스냅샷을 만듭니다. \endif \if EN Creates a load-port snapshot. \endif</summary>
    public LoadPortSnapshot(string id, LoadPortTransferState transfer, LoadPortAccessMode access, LoadPortReservationState reservation, CarrierAssociationState association, string? carrierId)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        if (association == CarrierAssociationState.Associated && string.IsNullOrWhiteSpace(carrierId) || association == CarrierAssociationState.NotAssociated && carrierId is not null) throw new ArgumentException("Carrier ID must match association state.", nameof(carrierId));
        Id = id; TransferState = transfer; AccessMode = access; ReservationState = reservation; AssociationState = association; CarrierId = carrierId;
    }
    /// <summary>\if KO 포트 ID입니다. \endif \if EN Gets the port ID. \endif</summary>
    public string Id { get; }
    /// <summary>\if KO 전송 상태입니다. \endif \if EN Gets the transfer state. \endif</summary>
    public LoadPortTransferState TransferState { get; }
    /// <summary>\if KO 접근 모드입니다. \endif \if EN Gets the access mode. \endif</summary>
    public LoadPortAccessMode AccessMode { get; }
    /// <summary>\if KO 예약 상태입니다. \endif \if EN Gets the reservation state. \endif</summary>
    public LoadPortReservationState ReservationState { get; }
    /// <summary>\if KO 연계 상태입니다. \endif \if EN Gets the association state. \endif</summary>
    public CarrierAssociationState AssociationState { get; }
    /// <summary>\if KO 연계 Carrier ID입니다. \endif \if EN Gets the associated carrier ID. \endif</summary>
    public string? CarrierId { get; }
}

/// <summary>\if KO 캐리어 병렬 상태의 불변 스냅샷입니다. \endif \if EN Represents an immutable snapshot of orthogonal carrier states. \endif</summary>
public sealed class CarrierSnapshot
{
    private readonly ReadOnlyCollection<CarrierSlotState> _slotMap;
    /// <summary>\if KO 캐리어 스냅샷을 만듭니다. \endif \if EN Creates a carrier snapshot. \endif</summary>
    public CarrierSnapshot(string id, string portId, CarrierIdStatus idStatus, CarrierSlotMapStatus slotMapStatus, CarrierAccessingStatus accessingStatus, IEnumerable<CarrierSlotState> slotMap)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id); ArgumentException.ThrowIfNullOrWhiteSpace(portId); ArgumentNullException.ThrowIfNull(slotMap); var values = slotMap.ToArray(); if (values.Length == 0) throw new ArgumentException("Slot map cannot be empty.", nameof(slotMap));
        Id = id; PortId = portId; IdStatus = idStatus; SlotMapStatus = slotMapStatus; AccessingStatus = accessingStatus; _slotMap = Array.AsReadOnly(values);
    }
    /// <summary>\if KO Carrier ID입니다. \endif \if EN Gets the carrier ID. \endif</summary>
    public string Id { get; }
    /// <summary>\if KO 연계 포트 ID입니다. \endif \if EN Gets the associated port ID. \endif</summary>
    public string PortId { get; }
    /// <summary>\if KO ID 검증 상태입니다. \endif \if EN Gets the ID status. \endif</summary>
    public CarrierIdStatus IdStatus { get; }
    /// <summary>\if KO 슬롯 맵 검증 상태입니다. \endif \if EN Gets the slot-map status. \endif</summary>
    public CarrierSlotMapStatus SlotMapStatus { get; }
    /// <summary>\if KO 접근 상태입니다. \endif \if EN Gets the accessing status. \endif</summary>
    public CarrierAccessingStatus AccessingStatus { get; }
    /// <summary>\if KO 슬롯 맵입니다. \endif \if EN Gets the slot map. \endif</summary>
    public IReadOnlyList<CarrierSlotState> SlotMap => _slotMap;
}

/// <summary>\if KO 기판 병렬 상태와 위치 이력의 불변 스냅샷입니다. \endif \if EN Represents an immutable substrate state and location-history snapshot. \endif</summary>
public sealed class SubstrateSnapshot
{
    private readonly ReadOnlyCollection<SubstrateLocationHistory> _history;
    /// <summary>\if KO 기판 스냅샷을 만듭니다. \endif \if EN Creates a substrate snapshot. \endif</summary>
    public SubstrateSnapshot(string id, string source, string destination, string currentLocation, SubstrateTransportState transport, SubstrateProcessingState processing, SubstrateIdStatus idStatus, IEnumerable<SubstrateLocationHistory> history)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id); ArgumentException.ThrowIfNullOrWhiteSpace(source); ArgumentException.ThrowIfNullOrWhiteSpace(destination); ArgumentException.ThrowIfNullOrWhiteSpace(currentLocation); ArgumentNullException.ThrowIfNull(history); var values = history.ToArray(); if (values.Length == 0 || values.Any(static value => value is null)) throw new ArgumentException("Location history cannot be empty or contain null.", nameof(history));
        Id = id; Source = source; Destination = destination; CurrentLocation = currentLocation; TransportState = transport; ProcessingState = processing; IdStatus = idStatus; _history = Array.AsReadOnly(values);
    }
    /// <summary>\if KO Substrate ID입니다. \endif \if EN Gets the substrate ID. \endif</summary>
    public string Id { get; }
    /// <summary>\if KO 원점 위치입니다. \endif \if EN Gets the source location. \endif</summary>
    public string Source { get; }
    /// <summary>\if KO 목적 위치입니다. \endif \if EN Gets the destination location. \endif</summary>
    public string Destination { get; }
    /// <summary>\if KO 현재 위치입니다. \endif \if EN Gets the current location. \endif</summary>
    public string CurrentLocation { get; }
    /// <summary>\if KO 운송 상태입니다. \endif \if EN Gets the transport state. \endif</summary>
    public SubstrateTransportState TransportState { get; }
    /// <summary>\if KO 처리 상태입니다. \endif \if EN Gets the processing state. \endif</summary>
    public SubstrateProcessingState ProcessingState { get; }
    /// <summary>\if KO ID 확인 상태입니다. \endif \if EN Gets the ID status. \endif</summary>
    public SubstrateIdStatus IdStatus { get; }
    /// <summary>\if KO 위치 이력입니다. \endif \if EN Gets the location history. \endif</summary>
    public IReadOnlyList<SubstrateLocationHistory> History => _history;
}

/// <summary>\if KO 불변 Process Job 정의입니다. \endif \if EN Represents an immutable process-job definition. \endif</summary>
public sealed class ProcessJobDefinition
{
    private readonly ReadOnlyCollection<string> _materialIds;
    /// <summary>\if KO Process Job 정의를 만듭니다. \endif \if EN Creates a process-job definition. \endif</summary>
    public ProcessJobDefinition(string id, string recipeId, IEnumerable<string> materialIds, bool manualStart = false)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id); ArgumentException.ThrowIfNullOrWhiteSpace(recipeId); ArgumentNullException.ThrowIfNull(materialIds);
        var values = materialIds.ToArray(); if (values.Length == 0 || values.Any(string.IsNullOrWhiteSpace) || values.Distinct(StringComparer.Ordinal).Count() != values.Length) throw new ArgumentException("Material IDs must be non-empty and unique.", nameof(materialIds));
        Id = id; RecipeId = recipeId; ManualStart = manualStart; _materialIds = Array.AsReadOnly(values);
    }
    /// <summary>\if KO Process Job ID입니다. \endif \if EN Gets the process-job ID. \endif</summary>
    public string Id { get; }
    /// <summary>\if KO Recipe ID입니다. \endif \if EN Gets the recipe ID. \endif</summary>
    public string RecipeId { get; }
    /// <summary>\if KO 재료 ID 목록입니다. \endif \if EN Gets material IDs. \endif</summary>
    public IReadOnlyList<string> MaterialIds => _materialIds;
    /// <summary>\if KO 수동 시작 여부입니다. \endif \if EN Gets whether manual start is required. \endif</summary>
    public bool ManualStart { get; }
}

/// <summary>\if KO 불변 Process Job 스냅샷입니다. \endif \if EN Represents an immutable process-job snapshot. \endif</summary>
public sealed class ProcessJobSnapshot
{
    /// <summary>\if KO 스냅샷을 만듭니다. \endif \if EN Creates a snapshot. \endif</summary>
    public ProcessJobSnapshot(ProcessJobDefinition definition, ProcessJobState state) { Definition = definition ?? throw new ArgumentNullException(nameof(definition)); State = state; }
    /// <summary>\if KO 생성 시 보존한 공정 프로그램을 포함하는 스냅샷을 만듭니다. \endif \if EN Creates a snapshot containing the process program retained at creation time. \endif</summary>
    public ProcessJobSnapshot(ProcessJobDefinition definition, ProcessJobState state, Dreamine.Gem.Abstractions.Model.GemProcessProgram processProgram)
        : this(definition, state) => ProcessProgram = processProgram ?? throw new ArgumentNullException(nameof(processProgram));
    /// <summary>\if KO 정의입니다. \endif \if EN Gets the definition. \endif</summary>
    public ProcessJobDefinition Definition { get; }
    /// <summary>\if KO 상태입니다. \endif \if EN Gets the state. \endif</summary>
    public ProcessJobState State { get; }
    /// <summary>\if KO 생성 시 보존된 공정 프로그램이며 기존 직접 생성 스냅샷에서는 null일 수 있습니다. \endif \if EN Gets the process program retained at creation; it may be null on legacy directly constructed snapshots. \endif</summary>
    public Dreamine.Gem.Abstractions.Model.GemProcessProgram? ProcessProgram { get; }
}

/// <summary>\if KO 불변 Control Job 정의입니다. \endif \if EN Represents an immutable control-job definition. \endif</summary>
public sealed class ControlJobDefinition
{
    private readonly ReadOnlyCollection<string> _processJobIds;
    /// <summary>\if KO Control Job 정의를 만듭니다. \endif \if EN Creates a control-job definition. \endif</summary>
    public ControlJobDefinition(string id, IEnumerable<string> processJobIds, bool manualStart = false)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id); ArgumentNullException.ThrowIfNull(processJobIds); var values = processJobIds.ToArray();
        if (values.Length == 0 || values.Any(string.IsNullOrWhiteSpace) || values.Distinct(StringComparer.Ordinal).Count() != values.Length) throw new ArgumentException("Process-job IDs must be non-empty and unique.", nameof(processJobIds));
        Id = id; ManualStart = manualStart; _processJobIds = Array.AsReadOnly(values);
    }
    /// <summary>\if KO Control Job ID입니다. \endif \if EN Gets the control-job ID. \endif</summary>
    public string Id { get; }
    /// <summary>\if KO 순서화된 Process Job ID입니다. \endif \if EN Gets ordered process-job IDs. \endif</summary>
    public IReadOnlyList<string> ProcessJobIds => _processJobIds;
    /// <summary>\if KO 수동 시작 여부입니다. \endif \if EN Gets whether manual start is required. \endif</summary>
    public bool ManualStart { get; }
}

/// <summary>\if KO 불변 Control Job 스냅샷입니다. \endif \if EN Represents an immutable control-job snapshot. \endif</summary>
public sealed class ControlJobSnapshot
{
    /// <summary>\if KO 스냅샷을 만듭니다. \endif \if EN Creates a snapshot. \endif</summary>
    public ControlJobSnapshot(ControlJobDefinition definition, ControlJobState state, int currentProcessJobIndex)
    {
        Definition = definition ?? throw new ArgumentNullException(nameof(definition)); if (currentProcessJobIndex < -1 || currentProcessJobIndex >= definition.ProcessJobIds.Count) throw new ArgumentOutOfRangeException(nameof(currentProcessJobIndex)); State = state; CurrentProcessJobIndex = currentProcessJobIndex;
    }
    /// <summary>\if KO 정의입니다. \endif \if EN Gets the definition. \endif</summary>
    public ControlJobDefinition Definition { get; }
    /// <summary>\if KO 상태입니다. \endif \if EN Gets the state. \endif</summary>
    public ControlJobState State { get; }
    /// <summary>\if KO 현재 Process Job 순서이며 미실행이면 -1입니다. \endif \if EN Gets the current process-job index, or -1 before execution. \endif</summary>
    public int CurrentProcessJobIndex { get; }
}

/// <summary>\if KO Carrier 도착 시 등록할 불변 기판 계획입니다. Experimental 조정 모델입니다. \endif \if EN Represents an immutable substrate plan for carrier arrival; this is an experimental orchestration model. \endif</summary>
public sealed class SubstrateArrivalPlan
{
    /// <summary>\if KO 기판 도착 계획을 만듭니다. \endif \if EN Creates a substrate arrival plan. \endif</summary>
    public SubstrateArrivalPlan(string substrateId, string sourceLocation, string destinationLocation)
    { ArgumentException.ThrowIfNullOrWhiteSpace(substrateId); ArgumentException.ThrowIfNullOrWhiteSpace(sourceLocation); ArgumentException.ThrowIfNullOrWhiteSpace(destinationLocation); SubstrateId = substrateId; SourceLocation = sourceLocation; DestinationLocation = destinationLocation; }
    /// <summary>\if KO Substrate ID입니다. \endif \if EN Gets the substrate ID. \endif</summary>
    public string SubstrateId { get; }
    /// <summary>\if KO 원점 위치입니다. \endif \if EN Gets the source location. \endif</summary>
    public string SourceLocation { get; }
    /// <summary>\if KO 목적 위치입니다. \endif \if EN Gets the destination location. \endif</summary>
    public string DestinationLocation { get; }
}

/// <summary>\if KO Experimental 도착 계획에서 애플리케이션이 명시한 Slot 인덱스와 Substrate ID 연결입니다. Wire 모델이 아닙니다. \endif \if EN Represents an application-declared slot-index/substrate-ID association in an experimental arrival plan; it is not a wire model. \endif</summary>
public sealed class CarrierSubstrateSlotAssignment
{
    /// <summary>\if KO 명시적 Slot 연결을 만듭니다. \endif \if EN Creates an explicit slot association. \endif</summary>
    public CarrierSubstrateSlotAssignment(int slotIndex, string substrateId)
    {
        if (slotIndex < 0) throw new ArgumentOutOfRangeException(nameof(slotIndex));
        ArgumentException.ThrowIfNullOrWhiteSpace(substrateId);
        SlotIndex = slotIndex; SubstrateId = substrateId;
    }
    /// <summary>\if KO 애플리케이션 계획 내 0 기반 Slot 인덱스입니다. \endif \if EN Gets the zero-based slot index within the application plan. \endif</summary>
    public int SlotIndex { get; }
    /// <summary>\if KO 해당 Slot에 명시적으로 연결한 Substrate ID입니다. \endif \if EN Gets the substrate ID explicitly associated with the slot. \endif</summary>
    public string SubstrateId { get; }
}

/// <summary>\if KO Carrier 도착의 불변 자체 통합 계획입니다. Experimental이며 wire 모델이 아닙니다. \endif \if EN Represents an immutable application integration plan for carrier arrival; it is experimental and not a wire model. \endif</summary>
public sealed class CarrierArrivalPlan
{
    private readonly ReadOnlyCollection<CarrierSlotState> _slotMap;
    private readonly ReadOnlyCollection<SubstrateArrivalPlan> _substrates;
    private readonly ReadOnlyCollection<CarrierSubstrateSlotAssignment> _slotAssignments;
    /// <summary>\if KO Carrier 도착 계획을 만듭니다. \endif \if EN Creates a carrier arrival plan. \endif</summary>
    public CarrierArrivalPlan(string portId, string carrierId, IEnumerable<CarrierSlotState> slotMap, IEnumerable<SubstrateArrivalPlan> substrates)
        : this(portId, carrierId, slotMap, substrates, null) { }
    /// <summary>\if KO 애플리케이션 수준의 명시적 Slot↔Substrate 연결을 포함하여 Carrier 도착 계획을 만듭니다. \endif \if EN Creates a carrier-arrival plan with explicit application-level slot/substrate associations. \endif</summary>
    public CarrierArrivalPlan(string portId, string carrierId, IEnumerable<CarrierSlotState> slotMap, IEnumerable<SubstrateArrivalPlan> substrates, IEnumerable<CarrierSubstrateSlotAssignment>? slotAssignments)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(portId); ArgumentException.ThrowIfNullOrWhiteSpace(carrierId); ArgumentNullException.ThrowIfNull(slotMap); ArgumentNullException.ThrowIfNull(substrates);
        var slots = slotMap.ToArray(); var materials = substrates.ToArray();
        if (slots.Length == 0) throw new ArgumentException("Slot map cannot be empty.", nameof(slotMap));
        if (slots.Any(static value => !Enum.IsDefined(value))) throw new ArgumentException("Slot-map values must be defined.", nameof(slotMap));
        if (materials.Any(static value => value is null) || materials.Select(static value => value.SubstrateId).Distinct(StringComparer.Ordinal).Count() != materials.Length || materials.Select(static value => value.SourceLocation).Distinct(StringComparer.Ordinal).Count() != materials.Length) throw new ArgumentException("Substrate IDs and source locations must be unique.", nameof(substrates));
        var assignments = slotAssignments?.ToArray() ?? [];
        if (assignments.Any(static value => value is null) || assignments.Select(static value => value.SlotIndex).Distinct().Count() != assignments.Length || assignments.Select(static value => value.SubstrateId).Distinct(StringComparer.Ordinal).Count() != assignments.Length)
            throw new ArgumentException("Slot assignments must use unique slot indexes and substrate IDs.", nameof(slotAssignments));
        if (slotAssignments is not null)
        {
            var materialIds = materials.Select(static value => value.SubstrateId).ToHashSet(StringComparer.Ordinal);
            if (assignments.Length != materials.Length || assignments.Any(value => value.SlotIndex >= slots.Length || !materialIds.Contains(value.SubstrateId) || slots[value.SlotIndex] is not (CarrierSlotState.CorrectlyOccupied or CarrierSlotState.NotEmpty)))
                throw new ArgumentException("Explicit slot assignments must map every planned substrate to one occupied slot.", nameof(slotAssignments));
            var occupied = slots.Select(static (state, index) => (state, index)).Where(static value => value.state is CarrierSlotState.CorrectlyOccupied or CarrierSlotState.NotEmpty).Select(static value => value.index).ToHashSet();
            if (!occupied.SetEquals(assignments.Select(static value => value.SlotIndex))) throw new ArgumentException("Every occupied slot must have exactly one explicit substrate assignment.", nameof(slotAssignments));
        }
        PortId = portId; CarrierId = carrierId; HasExplicitSlotAssignments = slotAssignments is not null; _slotMap = Array.AsReadOnly(slots); _substrates = Array.AsReadOnly(materials); _slotAssignments = Array.AsReadOnly(assignments);
    }
    /// <summary>\if KO Port ID입니다. \endif \if EN Gets the port ID. \endif</summary>
    public string PortId { get; }
    /// <summary>\if KO Carrier ID입니다. \endif \if EN Gets the carrier ID. \endif</summary>
    public string CarrierId { get; }
    /// <summary>\if KO Slot Map입니다. \endif \if EN Gets the slot map. \endif</summary>
    public IReadOnlyList<CarrierSlotState> SlotMap => _slotMap;
    /// <summary>\if KO 기판 계획입니다. \endif \if EN Gets substrate plans. \endif</summary>
    public IReadOnlyList<SubstrateArrivalPlan> Substrates => _substrates;
    /// <summary>\if KO 애플리케이션이 Slot 연결을 명시했는지 여부입니다. \endif \if EN Gets whether application-level slot associations were supplied explicitly. \endif</summary>
    public bool HasExplicitSlotAssignments { get; }
    /// <summary>\if KO 명시적 Slot↔Substrate 연결입니다. 순서나 위치 ID에서 암시적으로 추론하지 않습니다. \endif \if EN Gets explicit slot/substrate associations; no association is inferred from ordering or location IDs. \endif</summary>
    public IReadOnlyList<CarrierSubstrateSlotAssignment> SlotAssignments => _slotAssignments;
}
