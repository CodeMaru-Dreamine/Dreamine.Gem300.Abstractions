namespace Dreamine.Gem300.Abstractions.Model;

/// <summary>\if KO 제한 용량 이벤트 저널의 안정적인 상태 스냅샷입니다. \endif \if EN Represents a stable health snapshot for a bounded event journal. \endif</summary>
public sealed class Gem300EventJournalHealth
{
    /// <summary>\if KO 상태 스냅샷을 만듭니다. \endif \if EN Creates a health snapshot. \endif</summary>
    public Gem300EventJournalHealth(Guid journalId, int capacity, int retainedCount, long totalRecorded, long droppedCount, long? firstRetainedSequence, long? lastRetainedSequence)
    {
        if (journalId == Guid.Empty) throw new ArgumentException("Journal ID cannot be empty.", nameof(journalId));
        if (capacity <= 0) throw new ArgumentOutOfRangeException(nameof(capacity));
        if (retainedCount < 0 || retainedCount > capacity) throw new ArgumentOutOfRangeException(nameof(retainedCount));
        if (totalRecorded < 0) throw new ArgumentOutOfRangeException(nameof(totalRecorded));
        if (droppedCount < 0 || droppedCount > totalRecorded) throw new ArgumentOutOfRangeException(nameof(droppedCount));
        JournalId = journalId; Capacity = capacity; RetainedCount = retainedCount; TotalRecorded = totalRecorded; DroppedCount = droppedCount; FirstRetainedSequence = firstRetainedSequence; LastRetainedSequence = lastRetainedSequence;
    }

    /// <summary>\if KO 저널 ID입니다. \endif \if EN Gets the journal ID. \endif</summary>
    public Guid JournalId { get; }
    /// <summary>\if KO 보존 용량입니다. \endif \if EN Gets the retention capacity. \endif</summary>
    public int Capacity { get; }
    /// <summary>\if KO 현재 보존된 이벤트 수입니다. \endif \if EN Gets the retained event count. \endif</summary>
    public int RetainedCount { get; }
    /// <summary>\if KO 누적 기록 수입니다. \endif \if EN Gets the total recorded count. \endif</summary>
    public long TotalRecorded { get; }
    /// <summary>\if KO 용량 제한으로 삭제된 누적 이벤트 수입니다. \endif \if EN Gets the number of events dropped by retention. \endif</summary>
    public long DroppedCount { get; }
    /// <summary>\if KO 보존 구간의 첫 순서입니다. \endif \if EN Gets the first retained sequence. \endif</summary>
    public long? FirstRetainedSequence { get; }
    /// <summary>\if KO 보존 구간의 마지막 순서입니다. \endif \if EN Gets the last retained sequence. \endif</summary>
    public long? LastRetainedSequence { get; }
}

/// <summary>\if KO 비차단 이벤트 게시기의 상태 스냅샷입니다. \endif \if EN Represents a health snapshot for the non-throwing event publisher. \endif</summary>
public sealed class Gem300EventPublisherHealth
{
    /// <summary>\if KO 게시기 상태를 만듭니다. \endif \if EN Creates a publisher-health snapshot. \endif</summary>
    public Gem300EventPublisherHealth(long failureCount, string? lastError, DateTimeOffset? lastFailureAt)
    {
        if (failureCount < 0) throw new ArgumentOutOfRangeException(nameof(failureCount));
        FailureCount = failureCount; LastError = lastError; LastFailureAt = lastFailureAt;
    }

    /// <summary>\if KO 저널 기록 실패 누계입니다. \endif \if EN Gets the cumulative journal-recording failure count. \endif</summary>
    public long FailureCount { get; }
    /// <summary>\if KO 마지막 오류의 유형 및 메시지입니다. \endif \if EN Gets the type and message of the last error. \endif</summary>
    public string? LastError { get; }
    /// <summary>\if KO 마지막 실패 시각입니다. \endif \if EN Gets the last failure time. \endif</summary>
    public DateTimeOffset? LastFailureAt { get; }
}
