using Dreamine.Gem.Abstractions.Model;
using Dreamine.Gem300.Abstractions.Model;
using Dreamine.Gem300.Abstractions.States;
using Dreamine.Secs.Abstractions.Model;
using Xunit;

namespace Dreamine.Gem300.Abstractions.Tests;

public sealed class Gem300CoverageContractTests
{
    [Fact]
    public void StateSnapshotsPreserveAllOrthogonalValues()
    {
        var history = new SubstrateLocationHistory("L1", DateTimeOffset.UnixEpoch, DateTimeOffset.UnixEpoch.AddMinutes(1));
        Assert.Equal("L1", history.LocationId);
        Assert.Equal(DateTimeOffset.UnixEpoch, history.TimeIn);
        Assert.Equal(DateTimeOffset.UnixEpoch.AddMinutes(1), history.TimeOut);

        var port = new LoadPortSnapshot("P1", LoadPortTransferState.ReadyToUnload, LoadPortAccessMode.Automatic,
            LoadPortReservationState.Reserved, CarrierAssociationState.Associated, "C1");
        Assert.Equal("P1", port.Id);
        Assert.Equal(LoadPortTransferState.ReadyToUnload, port.TransferState);
        Assert.Equal(LoadPortAccessMode.Automatic, port.AccessMode);
        Assert.Equal(LoadPortReservationState.Reserved, port.ReservationState);
        Assert.Equal(CarrierAssociationState.Associated, port.AssociationState);
        Assert.Equal("C1", port.CarrierId);

        var carrier = new CarrierSnapshot("C1", "P1", CarrierIdStatus.VerificationOk,
            CarrierSlotMapStatus.VerificationOk, CarrierAccessingStatus.InAccess, [CarrierSlotState.CorrectlyOccupied]);
        Assert.Equal("C1", carrier.Id);
        Assert.Equal("P1", carrier.PortId);
        Assert.Equal(CarrierIdStatus.VerificationOk, carrier.IdStatus);
        Assert.Equal(CarrierSlotMapStatus.VerificationOk, carrier.SlotMapStatus);
        Assert.Equal(CarrierAccessingStatus.InAccess, carrier.AccessingStatus);
        Assert.Equal(CarrierSlotState.CorrectlyOccupied, carrier.SlotMap[0]);

        var substrate = new SubstrateSnapshot("S1", "SRC", "DST", "L1", SubstrateTransportState.AtWork,
            SubstrateProcessingState.InProcess, SubstrateIdStatus.Confirmed, [history]);
        Assert.Equal("S1", substrate.Id);
        Assert.Equal("SRC", substrate.Source);
        Assert.Equal("DST", substrate.Destination);
        Assert.Equal("L1", substrate.CurrentLocation);
        Assert.Equal(SubstrateTransportState.AtWork, substrate.TransportState);
        Assert.Equal(SubstrateProcessingState.InProcess, substrate.ProcessingState);
        Assert.Equal(SubstrateIdStatus.Confirmed, substrate.IdStatus);
        Assert.Equal(history, substrate.History[0]);
    }

    [Fact]
    public void JobAndArrivalModelsPreserveOrderedImmutableDefinitions()
    {
        var process = new ProcessJobDefinition("PJ1", "R1", ["S1"], true);
        var program = new GemProcessProgram("R1", [1]);
        var processSnapshot = new ProcessJobSnapshot(process, ProcessJobState.WaitingForStart, program);
        Assert.Equal("PJ1", process.Id);
        Assert.Equal("R1", process.RecipeId);
        Assert.Equal(new[] { "S1" }, process.MaterialIds);
        Assert.True(process.ManualStart);
        Assert.Equal(process, processSnapshot.Definition);
        Assert.Equal(ProcessJobState.WaitingForStart, processSnapshot.State);
        Assert.Equal(program, processSnapshot.ProcessProgram);

        var control = new ControlJobDefinition("CJ1", ["PJ1"], true);
        var controlSnapshot = new ControlJobSnapshot(control, ControlJobState.Selected, 0);
        Assert.Equal("CJ1", control.Id);
        Assert.Equal(new[] { "PJ1" }, control.ProcessJobIds);
        Assert.True(control.ManualStart);
        Assert.Equal(control, controlSnapshot.Definition);
        Assert.Equal(ControlJobState.Selected, controlSnapshot.State);
        Assert.Equal(0, controlSnapshot.CurrentProcessJobIndex);

        var substrate = new SubstrateArrivalPlan("S1", "SRC", "DST");
        var assignment = new CarrierSubstrateSlotAssignment(0, "S1");
        var arrival = new CarrierArrivalPlan("P1", "C1", [CarrierSlotState.CorrectlyOccupied], [substrate], [assignment]);
        Assert.Equal("S1", substrate.SubstrateId);
        Assert.Equal("SRC", substrate.SourceLocation);
        Assert.Equal("DST", substrate.DestinationLocation);
        Assert.Equal(0, assignment.SlotIndex);
        Assert.Equal("S1", assignment.SubstrateId);
        Assert.Equal("P1", arrival.PortId);
        Assert.Equal("C1", arrival.CarrierId);
        Assert.True(arrival.HasExplicitSlotAssignments);
        Assert.Equal(CarrierSlotState.CorrectlyOccupied, arrival.SlotMap[0]);
        Assert.Equal(substrate, arrival.Substrates[0]);
        Assert.Equal(assignment, arrival.SlotAssignments[0]);
    }

    [Fact]
    public void ObjectEventAttributeAndHealthModelsExposeValidatedContext()
    {
        var key = new Gem300ObjectKey("Carrier", "C1");
        Assert.True(key.Equals((object)new Gem300ObjectKey("Carrier", "C1")));
        Assert.False(key.Equals((Gem300ObjectKey?)null));

        var attribute = new Gem300AttributeDefinition("Capacity", new SecsUInt16Item(25), true);
        Assert.Equal("Capacity", attribute.Name);
        Assert.True(attribute.Writable);

        var journalId = Guid.NewGuid();
        var domainEvent = new Gem300DomainEvent(journalId, 1, Gem300EventKind.CarrierChanged, "Carrier", "C1", DateTimeOffset.UnixEpoch);
        Assert.Equal(journalId, domainEvent.JournalId);
        Assert.Equal(1, domainEvent.Sequence);
        Assert.Equal(Gem300EventKind.CarrierChanged, domainEvent.Kind);
        Assert.Equal("Carrier", domainEvent.AggregateType);
        Assert.Equal("C1", domainEvent.AggregateId);
        Assert.Equal(DateTimeOffset.UnixEpoch, domainEvent.OccurredAt);

        var journal = new Gem300EventJournalHealth(journalId, 10, 2, 5, 3, 4, 5);
        Assert.Equal(journalId, journal.JournalId);
        Assert.Equal(10, journal.Capacity);
        Assert.Equal(2, journal.RetainedCount);
        Assert.Equal(5, journal.TotalRecorded);
        Assert.Equal(3, journal.DroppedCount);
        Assert.Equal(4, journal.FirstRetainedSequence);
        Assert.Equal(5, journal.LastRetainedSequence);

        var failedAt = DateTimeOffset.UnixEpoch.AddMinutes(1);
        var publisher = new Gem300EventPublisherHealth(2, "failure", failedAt);
        Assert.Equal(2, publisher.FailureCount);
        Assert.Equal("failure", publisher.LastError);
        Assert.Equal(failedAt, publisher.LastFailureAt);
    }

    [Fact]
    public void InvalidCrossFieldCombinationsAreRejected()
    {
        Assert.Throws<ArgumentException>(() => new LoadPortSnapshot("P", LoadPortTransferState.OutOfService,
            LoadPortAccessMode.Manual, LoadPortReservationState.NotReserved, CarrierAssociationState.Associated, null));
        Assert.Throws<ArgumentException>(() => new CarrierSnapshot("C", "P", CarrierIdStatus.IdNotRead,
            CarrierSlotMapStatus.SlotMapNotRead, CarrierAccessingStatus.NotAccessed, []));
        Assert.Throws<ArgumentOutOfRangeException>(() => new ControlJobSnapshot(new ControlJobDefinition("C", ["P"]), ControlJobState.Queued, 1));
        Assert.Throws<ArgumentOutOfRangeException>(() => new CarrierSubstrateSlotAssignment(-1, "S"));
        Assert.Throws<ArgumentException>(() => new Gem300EventJournalHealth(Guid.Empty, 1, 0, 0, 0, null, null));
        Assert.Throws<ArgumentOutOfRangeException>(() => new Gem300EventPublisherHealth(-1, null, null));
    }
}
