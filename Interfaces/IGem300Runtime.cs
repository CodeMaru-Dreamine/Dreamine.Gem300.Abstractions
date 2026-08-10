using Dreamine.Gem.Abstractions.Interfaces;

namespace Dreamine.Gem300.Abstractions.Interfaces;

/// <summary>
/// \if KO
/// <para>독립 GEM300 기능 모듈을 통합할 최소 런타임 경계 계약입니다.</para>
/// \endif
/// \if EN
/// <para>Defines the minimal runtime boundary for integrating independent GEM300 capability modules.</para>
/// \endif
/// </summary>
public interface IGem300Runtime
{
    /// <summary>
    /// \if KO
    /// <para>기반 GEM 런타임 계약을 가져옵니다.</para>
    /// \endif
    /// \if EN
    /// <para>Gets the underlying GEM runtime contract.</para>
    /// \endif
    /// </summary>
    IGemRuntime GemRuntime { get; }

    /// <summary>\if KO 객체 서비스 경계를 가져옵니다. \endif \if EN Gets the object-service boundary. \endif</summary>
    IGem300ObjectService Objects { get; }
    /// <summary>\if KO Carrier 관리 경계를 가져옵니다. \endif \if EN Gets the carrier-management boundary. \endif</summary>
    ICarrierManager Carriers { get; }
    /// <summary>\if KO Substrate 추적 경계를 가져옵니다. \endif \if EN Gets the substrate-tracking boundary. \endif</summary>
    ISubstrateTracker Substrates { get; }
    /// <summary>\if KO Process Job 관리 경계를 가져옵니다. \endif \if EN Gets the process-job boundary. \endif</summary>
    IProcessJobManager ProcessJobs { get; }
    /// <summary>\if KO Control Job 관리 경계를 가져옵니다. \endif \if EN Gets the control-job boundary. \endif</summary>
    IControlJobManager ControlJobs { get; }
    /// <summary>\if KO 도메인 이벤트 저널을 가져옵니다. \endif \if EN Gets the domain-event journal. \endif</summary>
    IGem300EventJournal Events { get; }
}
