using Dreamine.Gem300.Abstractions.Model;
using Dreamine.Gem300.Abstractions.States;
using Dreamine.Secs.Abstractions.Model;
using Xunit;

namespace Dreamine.Gem300.Abstractions.Tests;

public sealed class Gem300ModelTests
{
    [Fact]
    public void ObjectKeyUsesOrdinalTypeAndIdEquality()
    {
        var first = new Gem300ObjectKey("Carrier", "C1"); var second = new Gem300ObjectKey("Carrier", "C1");
        Assert.Equal(first, second); Assert.NotEqual(first, new Gem300ObjectKey("carrier", "C1")); Assert.Equal(first.GetHashCode(), second.GetHashCode());
    }

    [Theory]
    [InlineData("Bad>Type", "1")]
    [InlineData("Type", "Bad:Id")]
    public void ObjectKeyRejectsReservedSeparators(string type, string id) => Assert.Throws<ArgumentException>(() => new Gem300ObjectKey(type, id));

    [Fact]
    public void CarrierSnapshotCopiesSlotMap()
    {
        CarrierSlotState[] slots = [CarrierSlotState.Empty];
        var snapshot = new CarrierSnapshot("C", "P", CarrierIdStatus.VerificationOk, CarrierSlotMapStatus.VerificationOk, CarrierAccessingStatus.NotAccessed, slots);
        slots[0] = CarrierSlotState.CrossSlotted; Assert.Equal(CarrierSlotState.Empty, snapshot.SlotMap[0]);
    }

    [Fact]
    public void JobDefinitionsCopyAndValidateOrderedIds()
    {
        string[] ids = ["S1", "S2"]; var process = new ProcessJobDefinition("P", "R", ids); ids[0] = "X";
        Assert.Equal("S1", process.MaterialIds[0]); Assert.Throws<ArgumentException>(() => new ControlJobDefinition("C", new[] { "P", "P" }));
    }

    [Fact]
    public void CarrierArrivalCopiesPlansAndRejectsDuplicateSources()
    {
        var source = new SubstrateArrivalPlan("S", "P:1", "P:2");
        var plan = new CarrierArrivalPlan("P", "C", new[] { CarrierSlotState.CorrectlyOccupied }, new[] { source });
        Assert.Single(plan.Substrates);
        Assert.Throws<ArgumentException>(() => new CarrierArrivalPlan("P", "C", new[] { CarrierSlotState.Empty, CarrierSlotState.Empty }, new[] { source, new SubstrateArrivalPlan("S2", "P:1", "P:3") }));
    }

    [Fact]
    public void DomainEventRequiresPositiveSequence() => Assert.Throws<ArgumentOutOfRangeException>(() => new Gem300DomainEvent(0, Gem300EventKind.CarrierChanged, "C", DateTimeOffset.UnixEpoch));

    [Fact]
    public void AttributeDefinitionPreservesTypedSecsValue()
    {
        var definition = new Gem300AttributeDefinition("Capacity", new SecsUInt16Item(25), false);
        Assert.Equal((ushort)25, Assert.IsType<SecsUInt16Item>(definition.InitialValue).Values.Span[0]);
    }
}
