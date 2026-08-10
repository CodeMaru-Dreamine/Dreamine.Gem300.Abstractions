namespace Dreamine.Gem300.Abstractions.States;

/// <summary>\if KO 로드 포트 전송 상태입니다. \endif \if EN Defines load-port transfer states. \endif</summary>
public enum LoadPortTransferState
{
    /// <summary>\if KO 서비스 중이 아닙니다. \endif \if EN Out of service. \endif</summary>
    OutOfService,
    /// <summary>\if KO 전송이 차단되었습니다. \endif \if EN Transfer is blocked. \endif</summary>
    TransferBlocked,
    /// <summary>\if KO 로드 준비 상태입니다. \endif \if EN Ready to load. \endif</summary>
    ReadyToLoad,
    /// <summary>\if KO 언로드 준비 상태입니다. \endif \if EN Ready to unload. \endif</summary>
    ReadyToUnload
}

/// <summary>\if KO 로드 포트 접근 모드입니다. \endif \if EN Defines load-port access modes. \endif</summary>
public enum LoadPortAccessMode
{
    /// <summary>\if KO 수동 접근입니다. \endif \if EN Manual access. \endif</summary>
    Manual,
    /// <summary>\if KO 자동 접근입니다. \endif \if EN Automatic access. \endif</summary>
    Automatic
}

/// <summary>\if KO 로드 포트 예약 상태입니다. \endif \if EN Defines load-port reservation states. \endif</summary>
public enum LoadPortReservationState
{
    /// <summary>\if KO 예약되지 않았습니다. \endif \if EN Not reserved. \endif</summary>
    NotReserved,
    /// <summary>\if KO 예약되었습니다. \endif \if EN Reserved. \endif</summary>
    Reserved
}

/// <summary>\if KO 로드 포트와 캐리어의 연계 상태입니다. \endif \if EN Defines load-port/carrier association states. \endif</summary>
public enum CarrierAssociationState
{
    /// <summary>\if KO 연계되지 않았습니다. \endif \if EN Not associated. \endif</summary>
    NotAssociated,
    /// <summary>\if KO 연계되었습니다. \endif \if EN Associated. \endif</summary>
    Associated
}

/// <summary>\if KO 캐리어 식별 검증 상태입니다. \endif \if EN Defines carrier-ID verification states. \endif</summary>
public enum CarrierIdStatus
{
    /// <summary>\if KO ID를 읽지 않았습니다. \endif \if EN ID not read. \endif</summary>
    IdNotRead,
    /// <summary>\if KO 호스트 결정을 기다립니다. \endif \if EN Waiting for host. \endif</summary>
    WaitingForHost,
    /// <summary>\if KO 검증에 성공했습니다. \endif \if EN Verification succeeded. \endif</summary>
    VerificationOk,
    /// <summary>\if KO 검증에 실패했습니다. \endif \if EN Verification failed. \endif</summary>
    VerificationFailed
}

/// <summary>\if KO 캐리어 슬롯 맵 검증 상태입니다. \endif \if EN Defines carrier slot-map verification states. \endif</summary>
public enum CarrierSlotMapStatus
{
    /// <summary>\if KO 슬롯 맵을 읽지 않았습니다. \endif \if EN Slot map not read. \endif</summary>
    SlotMapNotRead,
    /// <summary>\if KO 호스트 결정을 기다립니다. \endif \if EN Waiting for host. \endif</summary>
    WaitingForHost,
    /// <summary>\if KO 검증에 성공했습니다. \endif \if EN Verification succeeded. \endif</summary>
    VerificationOk,
    /// <summary>\if KO 검증에 실패했습니다. \endif \if EN Verification failed. \endif</summary>
    VerificationFailed
}

/// <summary>\if KO 장비의 캐리어 접근 상태입니다. \endif \if EN Defines equipment carrier-access states. \endif</summary>
public enum CarrierAccessingStatus
{
    /// <summary>\if KO 아직 접근하지 않았습니다. \endif \if EN Not accessed. \endif</summary>
    NotAccessed,
    /// <summary>\if KO 접근 중입니다. \endif \if EN In access. \endif</summary>
    InAccess,
    /// <summary>\if KO 접근을 정상 완료했습니다. \endif \if EN Carrier access completed. \endif</summary>
    CarrierComplete,
    /// <summary>\if KO 접근이 비정상 종료되었습니다. \endif \if EN Carrier access stopped. \endif</summary>
    CarrierStopped
}

/// <summary>\if KO 캐리어 슬롯 상태입니다. \endif \if EN Defines carrier slot states. \endif</summary>
public enum CarrierSlotState
{
    /// <summary>\if KO 정의되지 않았습니다. \endif \if EN Undefined. \endif</summary>
    Undefined,
    /// <summary>\if KO 비어 있습니다. \endif \if EN Empty. \endif</summary>
    Empty,
    /// <summary>\if KO 점유만 확인되었습니다. \endif \if EN Occupancy only is known. \endif</summary>
    NotEmpty,
    /// <summary>\if KO 올바르게 점유되었습니다. \endif \if EN Correctly occupied. \endif</summary>
    CorrectlyOccupied,
    /// <summary>\if KO 이중 적재입니다. \endif \if EN Double slotted. \endif</summary>
    DoubleSlotted,
    /// <summary>\if KO 교차 적재입니다. \endif \if EN Cross slotted. \endif</summary>
    CrossSlotted
}

/// <summary>\if KO 기판 운송 상태입니다. \endif \if EN Defines substrate transport states. \endif</summary>
public enum SubstrateTransportState
{
    /// <summary>\if KO 원점에 있습니다. \endif \if EN At source. \endif</summary>
    AtSource,
    /// <summary>\if KO 작업 위치에 있습니다. \endif \if EN At work. \endif</summary>
    AtWork,
    /// <summary>\if KO 목적지에 있습니다. \endif \if EN At destination. \endif</summary>
    AtDestination
}

/// <summary>\if KO 기판 처리 상태입니다. \endif \if EN Defines substrate processing states. \endif</summary>
public enum SubstrateProcessingState
{
    /// <summary>\if KO 처리가 필요합니다. \endif \if EN Needs processing. \endif</summary>
    NeedsProcessing,
    /// <summary>\if KO 처리 중입니다. \endif \if EN In process. \endif</summary>
    InProcess,
    /// <summary>\if KO 정상 처리되었습니다. \endif \if EN Processed successfully. \endif</summary>
    Processed,
    /// <summary>\if KO 중단되었습니다. \endif \if EN Aborted. \endif</summary>
    Aborted,
    /// <summary>\if KO 결과가 거부되었습니다. \endif \if EN Rejected. \endif</summary>
    Rejected,
    /// <summary>\if KO 분실되었습니다. \endif \if EN Lost. \endif</summary>
    Lost,
    /// <summary>\if KO 정지되었습니다. \endif \if EN Stopped. \endif</summary>
    Stopped,
    /// <summary>\if KO 처리를 건너뛰었습니다. \endif \if EN Skipped. \endif</summary>
    Skipped
}

/// <summary>\if KO 기판 식별 확인 상태입니다. \endif \if EN Defines substrate-ID confirmation states. \endif</summary>
public enum SubstrateIdStatus
{
    /// <summary>\if KO 확인되지 않았습니다. \endif \if EN Not confirmed. \endif</summary>
    NotConfirmed,
    /// <summary>\if KO 호스트 결정을 기다립니다. \endif \if EN Waiting for host. \endif</summary>
    WaitingForHost,
    /// <summary>\if KO 확인되었습니다. \endif \if EN Confirmed. \endif</summary>
    Confirmed,
    /// <summary>\if KO 확인에 실패했습니다. \endif \if EN Confirmation failed. \endif</summary>
    ConfirmationFailed
}

/// <summary>\if KO 재료 위치 점유 상태입니다. \endif \if EN Defines material-location occupancy. \endif</summary>
public enum MaterialLocationState
{
    /// <summary>\if KO 비점유 상태입니다. \endif \if EN Unoccupied. \endif</summary>
    Unoccupied,
    /// <summary>\if KO 점유 상태입니다. \endif \if EN Occupied. \endif</summary>
    Occupied
}

/// <summary>\if KO E40 Process Job의 leaf 상태입니다. \endif \if EN Defines E40 process-job leaf states. \endif</summary>
public enum ProcessJobState
{
    /// <summary>\if KO 대기 또는 풀에 있습니다. \endif \if EN Queued or pooled. \endif</summary>
    Queued,
    /// <summary>\if KO 설정 중입니다. \endif \if EN Setting up. \endif</summary>
    SettingUp,
    /// <summary>\if KO 수동 시작을 기다립니다. \endif \if EN Waiting for manual start. \endif</summary>
    WaitingForStart,
    /// <summary>\if KO 처리 중입니다. \endif \if EN Processing. \endif</summary>
    Processing,
    /// <summary>\if KO 일시정지를 진행합니다. \endif \if EN Pausing. \endif</summary>
    Pausing,
    /// <summary>\if KO 일시정지되었습니다. \endif \if EN Paused. \endif</summary>
    Paused,
    /// <summary>\if KO 정지를 진행합니다. \endif \if EN Stopping. \endif</summary>
    Stopping,
    /// <summary>\if KO 중단을 진행합니다. \endif \if EN Aborting. \endif</summary>
    Aborting,
    /// <summary>\if KO 처리를 완료했습니다. \endif \if EN Processing completed. \endif</summary>
    ProcessComplete,
    /// <summary>\if KO 정지 완료 상태입니다. \endif \if EN Stopped. \endif</summary>
    Stopped,
    /// <summary>\if KO 중단 완료 상태입니다. \endif \if EN Aborted. \endif</summary>
    Aborted
}

/// <summary>\if KO E94 Control Job 상태입니다. \endif \if EN Defines E94 control-job states. \endif</summary>
public enum ControlJobState
{
    /// <summary>\if KO 대기열에 있습니다. \endif \if EN Queued. \endif</summary>
    Queued,
    /// <summary>\if KO 선택되었습니다. \endif \if EN Selected. \endif</summary>
    Selected,
    /// <summary>\if KO 사용자 시작을 기다립니다. \endif \if EN Waiting for start. \endif</summary>
    WaitingForStart,
    /// <summary>\if KO 실행 중입니다. \endif \if EN Executing. \endif</summary>
    Executing,
    /// <summary>\if KO 일시정지되었습니다. \endif \if EN Paused. \endif</summary>
    Paused,
    /// <summary>\if KO 완료되었습니다. \endif \if EN Completed. \endif</summary>
    Completed
}

/// <summary>\if KO GEM300 도메인 이벤트 종류입니다. 자체 관찰 모델이며 wire 값이 아닙니다. \endif \if EN Defines application-domain GEM300 event kinds; these are not wire values. \endif</summary>
public enum Gem300EventKind
{
    /// <summary>\if KO 객체가 변경되었습니다. \endif \if EN An object changed. \endif</summary>
    ObjectChanged,
    /// <summary>\if KO 로드 포트가 변경되었습니다. \endif \if EN A load port changed. \endif</summary>
    LoadPortChanged,
    /// <summary>\if KO 캐리어가 변경되었습니다. \endif \if EN A carrier changed. \endif</summary>
    CarrierChanged,
    /// <summary>\if KO 기판이 변경되었습니다. \endif \if EN A substrate changed. \endif</summary>
    SubstrateChanged,
    /// <summary>\if KO Process Job이 변경되었습니다. \endif \if EN A process job changed. \endif</summary>
    ProcessJobChanged,
    /// <summary>\if KO Control Job이 변경되었습니다. \endif \if EN A control job changed. \endif</summary>
    ControlJobChanged
}
