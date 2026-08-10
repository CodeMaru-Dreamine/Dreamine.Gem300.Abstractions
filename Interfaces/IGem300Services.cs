using Dreamine.Gem300.Abstractions.Model;
using Dreamine.Gem300.Abstractions.States;
using Dreamine.Secs.Abstractions.Model;

namespace Dreamine.Gem300.Abstractions.Interfaces;

/// <summary>\if KO E39 기반 객체 속성 저장소 계약입니다. \endif \if EN Defines an E39-based object attribute store. \endif</summary>
public interface IGem300ObjectService
{
    /// <summary>\if KO 객체를 등록합니다. \endif \if EN Registers an object. \endif</summary>
    void Register(Gem300ObjectKey key, IEnumerable<Gem300AttributeDefinition> attributes);
    /// <summary>\if KO 속성을 조회합니다. \endif \if EN Gets an attribute. \endif</summary>
    bool TryGetAttribute(Gem300ObjectKey key, string name, out SecsItem? value);
    /// <summary>\if KO 쓰기 가능한 속성을 변경합니다. \endif \if EN Changes a writable attribute. \endif</summary>
    bool TrySetAttribute(Gem300ObjectKey key, string name, SecsItem value);
    /// <summary>\if KO 모든 공개 속성의 안정적인 스냅샷을 반환합니다. \endif \if EN Returns a stable snapshot of all public attributes. \endif</summary>
    IReadOnlyDictionary<string, SecsItem> GetAttributes(Gem300ObjectKey key);
    /// <summary>\if KO 객체 동작 처리기를 등록합니다. 결과는 wire ACK가 아닙니다. \endif \if EN Registers an object-action handler; its result is not a wire ACK. \endif</summary>
    void RegisterAction(Gem300ObjectKey key, string actionName, Func<IReadOnlyDictionary<string, SecsItem>, CancellationToken, ValueTask<Dreamine.Gem.Abstractions.Model.GemCommandResult>> handler);
    /// <summary>\if KO 객체 동작을 제한 시간 안에 실행합니다. \endif \if EN Executes an object action within a timeout. \endif</summary>
    ValueTask<Dreamine.Gem.Abstractions.Model.GemCommandResult> ExecuteActionAsync(Gem300ObjectKey key, string actionName, IReadOnlyDictionary<string, SecsItem> parameters, TimeSpan timeout, CancellationToken cancellationToken = default);
    /// <summary>\if KO 객체를 제거합니다. \endif \if EN Removes an object. \endif</summary>
    bool Remove(Gem300ObjectKey key);
}

/// <summary>\if KO 프로세스 내 GEM300 도메인 이벤트 저널입니다. \endif \if EN Defines a process-local GEM300 domain-event journal. \endif</summary>
public interface IGem300EventJournal
{
    /// <summary>\if KO 이벤트를 기록하고 할당된 순서를 반환합니다. \endif \if EN Records an event and returns its allocated sequence. \endif</summary>
    Gem300DomainEvent Record(Gem300EventKind kind, string aggregateId);
    /// <summary>\if KO 기록의 안정적인 스냅샷을 반환합니다. \endif \if EN Returns a stable event snapshot. \endif</summary>
    IReadOnlyList<Gem300DomainEvent> GetSnapshot();
}

/// <summary>\if KO E87 기반 Carrier·Load Port 관리 계약입니다. \endif \if EN Defines an E87-based carrier and load-port manager. \endif</summary>
public interface ICarrierManager
{
    /// <summary>\if KO 로드 포트를 등록합니다. \endif \if EN Registers a load port. \endif</summary>
    void RegisterLoadPort(string portId, LoadPortAccessMode accessMode = LoadPortAccessMode.Automatic);
    /// <summary>\if KO 포트를 서비스 상태로 전환합니다. \endif \if EN Places a port in service. \endif</summary>
    void SetInService(string portId);
    /// <summary>\if KO 비어 있는 포트를 서비스 밖으로 전환합니다. \endif \if EN Takes an empty port out of service. \endif</summary>
    void SetOutOfService(string portId);
    /// <summary>\if KO 비어 있고 미예약인 포트의 접근 모드를 변경합니다. \endif \if EN Changes access mode on an empty, unreserved port. \endif</summary>
    void ChangeAccessMode(string portId, LoadPortAccessMode accessMode);
    /// <summary>\if KO 포트를 예약합니다. \endif \if EN Reserves a port. \endif</summary>
    void Reserve(string portId);
    /// <summary>\if KO 포트 예약을 취소합니다. \endif \if EN Cancels a port reservation. \endif</summary>
    void CancelReservation(string portId);
    /// <summary>\if KO Carrier 객체를 만들고 포트와 연계합니다. \endif \if EN Creates and associates a carrier object. \endif</summary>
    void Bind(string portId, string carrierId, int capacity);
    /// <summary>\if KO 로드 전송을 시작합니다. \endif \if EN Begins load transfer. \endif</summary>
    void BeginLoad(string portId);
    /// <summary>\if KO 로드 전송을 완료합니다. \endif \if EN Completes load transfer. \endif</summary>
    void CompleteLoad(string portId);
    /// <summary>\if KO Carrier ID 결정을 호스트 대기로 전환합니다. \endif \if EN Places carrier-ID verification in host-wait. \endif</summary>
    void WaitForIdDecision(string carrierId);
    /// <summary>\if KO Carrier ID를 수락합니다. \endif \if EN Accepts a carrier ID. \endif</summary>
    void AcceptId(string carrierId);
    /// <summary>\if KO Carrier ID를 거부합니다. \endif \if EN Rejects a carrier ID. \endif</summary>
    void RejectId(string carrierId);
    /// <summary>\if KO 읽은 Slot Map을 호스트 대기로 기록합니다. \endif \if EN Records a read slot map awaiting host decision. \endif</summary>
    void WaitForSlotMapDecision(string carrierId, IEnumerable<CarrierSlotState> slotMap);
    /// <summary>\if KO Slot Map을 수락합니다. \endif \if EN Accepts a slot map. \endif</summary>
    void AcceptSlotMap(string carrierId);
    /// <summary>\if KO Slot Map을 거부합니다. \endif \if EN Rejects a slot map. \endif</summary>
    void RejectSlotMap(string carrierId);
    /// <summary>\if KO 검증된 Carrier 접근을 시작합니다. \endif \if EN Begins access to a verified carrier. \endif</summary>
    void BeginAccess(string carrierId);
    /// <summary>\if KO Carrier 접근을 정상 완료합니다. \endif \if EN Completes carrier access normally. \endif</summary>
    void CompleteAccess(string carrierId);
    /// <summary>\if KO Carrier 접근을 비정상 종료합니다. \endif \if EN Stops carrier access abnormally. \endif</summary>
    void StopAccess(string carrierId);
    /// <summary>\if KO 완료 또는 정지된 Carrier를 언로드 준비로 전환합니다. \endif \if EN Makes a completed or stopped carrier ready to unload. \endif</summary>
    void PrepareUnload(string carrierId);
    /// <summary>\if KO 언로드 전송을 시작합니다. \endif \if EN Begins unload transfer. \endif</summary>
    void BeginUnload(string portId);
    /// <summary>\if KO 언로드를 완료하고 Carrier 객체를 제거합니다. \endif \if EN Completes unload and removes the carrier object. \endif</summary>
    void CompleteUnload(string portId);
    /// <summary>\if KO 포트 스냅샷을 조회합니다. \endif \if EN Gets a load-port snapshot. \endif</summary>
    LoadPortSnapshot GetLoadPort(string portId);
    /// <summary>\if KO Carrier 스냅샷을 조회합니다. \endif \if EN Gets a carrier snapshot. \endif</summary>
    CarrierSnapshot GetCarrier(string carrierId);
}

/// <summary>\if KO E90 기반 Substrate 추적 계약입니다. \endif \if EN Defines an E90-based substrate tracker. \endif</summary>
public interface ISubstrateTracker
{
    /// <summary>\if KO 기판을 원점 위치에 등록합니다. \endif \if EN Registers a substrate at its source. \endif</summary>
    void Register(string substrateId, string sourceLocation, string destinationLocation, bool idConfirmed = true);
    /// <summary>\if KO 기판 ID를 확인합니다. \endif \if EN Confirms a substrate ID. \endif</summary>
    void ConfirmId(string substrateId);
    /// <summary>\if KO 기판 ID 확인에 실패합니다. \endif \if EN Fails substrate-ID confirmation. \endif</summary>
    void RejectId(string substrateId);
    /// <summary>\if KO 비점유 위치로 기판을 이동합니다. \endif \if EN Moves a substrate to an unoccupied location. \endif</summary>
    void Move(string substrateId, string locationId);
    /// <summary>\if KO 기판 처리를 시작합니다. \endif \if EN Begins substrate processing. \endif</summary>
    void BeginProcessing(string substrateId);
    /// <summary>\if KO 기판 처리를 최종 상태로 완료합니다. \endif \if EN Completes substrate processing with a terminal state. \endif</summary>
    void CompleteProcessing(string substrateId, SubstrateProcessingState result);
    /// <summary>\if KO 기판을 분실 상태로 표시합니다. \endif \if EN Marks a substrate lost. \endif</summary>
    void MarkLost(string substrateId);
    /// <summary>\if KO 목적지의 기판 객체를 제거합니다. \endif \if EN Removes a substrate object at destination. \endif</summary>
    void Remove(string substrateId);
    /// <summary>\if KO 기판 스냅샷을 조회합니다. \endif \if EN Gets a substrate snapshot. \endif</summary>
    SubstrateSnapshot Get(string substrateId);
    /// <summary>\if KO 기판 스냅샷 조회를 시도합니다. \endif \if EN Attempts to get a substrate snapshot. \endif</summary>
    bool TryGet(string substrateId, out SubstrateSnapshot? substrate);
    /// <summary>\if KO 위치 점유 상태를 조회합니다. \endif \if EN Gets material-location occupancy. \endif</summary>
    MaterialLocationState GetLocationState(string locationId);
}

/// <summary>\if KO E40 기반 Process Job 관리 계약입니다. \endif \if EN Defines an E40-based process-job manager. \endif</summary>
public interface IProcessJobManager
{
    /// <summary>\if KO Process Job을 생성합니다. \endif \if EN Creates a process job. \endif</summary>
    void Create(ProcessJobDefinition definition);
    /// <summary>\if KO 자원을 할당하고 설정을 시작합니다. \endif \if EN Allocates resources and starts setup. \endif</summary>
    void Allocate(string id);
    /// <summary>\if KO 설정을 완료합니다. \endif \if EN Completes setup. \endif</summary>
    void CompleteSetup(string id);
    /// <summary>\if KO 수동 대기 Job을 시작합니다. \endif \if EN Starts a manually waiting job. \endif</summary>
    void Start(string id);
    /// <summary>\if KO 일시정지를 요청합니다. \endif \if EN Requests pause. \endif</summary>
    void Pause(string id);
    /// <summary>\if KO 일시정지 도달을 확인합니다. \endif \if EN Confirms pause. \endif</summary>
    void ConfirmPaused(string id);
    /// <summary>\if KO 처리를 재개합니다. \endif \if EN Resumes processing. \endif</summary>
    void Resume(string id);
    /// <summary>\if KO 순차 정지를 요청합니다. \endif \if EN Requests an orderly stop. \endif</summary>
    void Stop(string id);
    /// <summary>\if KO 정지 완료를 확인합니다. \endif \if EN Confirms stop completion. \endif</summary>
    void ConfirmStopped(string id);
    /// <summary>\if KO 즉시 중단을 요청합니다. \endif \if EN Requests immediate abort. \endif</summary>
    void Abort(string id);
    /// <summary>\if KO 중단 완료를 확인합니다. \endif \if EN Confirms abort completion. \endif</summary>
    void ConfirmAborted(string id);
    /// <summary>\if KO 정상 처리를 완료합니다. \endif \if EN Completes processing normally. \endif</summary>
    void Complete(string id);
    /// <summary>\if KO 대기 또는 Post Active Job을 삭제합니다. \endif \if EN Deletes a queued or post-active job. \endif</summary>
    void Delete(string id);
    /// <summary>\if KO Job 스냅샷을 조회합니다. \endif \if EN Gets a job snapshot. \endif</summary>
    ProcessJobSnapshot Get(string id);
}

/// <summary>\if KO E94 기반 Control Job 관리 계약입니다. \endif \if EN Defines an E94-based control-job manager. \endif</summary>
public interface IControlJobManager
{
    /// <summary>\if KO Control Job을 대기열 끝에 생성합니다. \endif \if EN Creates a control job at the queue tail. \endif</summary>
    void Create(ControlJobDefinition definition);
    /// <summary>\if KO 대기열 선두 Job을 선택합니다. \endif \if EN Selects the queue-head job. \endif</summary>
    void Select(string id);
    /// <summary>\if KO 선택된 Job을 준비 상태에 진입시킵니다. \endif \if EN Makes a selected job ready. \endif</summary>
    void Ready(string id);
    /// <summary>\if KO 수동 대기 Job을 시작합니다. \endif \if EN Starts a manually waiting job. \endif</summary>
    void Start(string id);
    /// <summary>\if KO 실행을 일시정지합니다. \endif \if EN Pauses execution. \endif</summary>
    void Pause(string id);
    /// <summary>\if KO 실행을 재개합니다. \endif \if EN Resumes execution. \endif</summary>
    void Resume(string id);
    /// <summary>\if KO 다음 Process Job으로 진행합니다. \endif \if EN Advances to the next process job. \endif</summary>
    void Advance(string id);
    /// <summary>\if KO Control Job을 완료합니다. \endif \if EN Completes a control job. \endif</summary>
    void Complete(string id);
    /// <summary>\if KO 실행 중인 Control Job을 중단 완료로 전환합니다. \endif \if EN Completes an active control job by abort. \endif</summary>
    void Abort(string id);
    /// <summary>\if KO 대기 또는 완료 Job을 삭제합니다. \endif \if EN Deletes a queued or completed job. \endif</summary>
    void Delete(string id);
    /// <summary>\if KO Control Job 스냅샷을 조회합니다. \endif \if EN Gets a control-job snapshot. \endif</summary>
    ControlJobSnapshot Get(string id);
}
