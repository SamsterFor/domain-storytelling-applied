using TE.DomainStorytellingApplied.Domain.Aggregates.Bookings.ValueObjects;

namespace TE.DomainStorytellingApplied.Domain.Tests.Aggregates.Bookings.ValueObjects;

public class TimeSlotTests
{
    [Fact]
    public void GivenStartBeforeEnd_WhenCreatingTimeSlot_ShouldCreateTimeSlot()
    {
        var start = new DateTimeOffset(2026, 10, 9, 10, 0, 0, TimeSpan.Zero);
        var end = start.AddHours(1);

        var timeSlot = new TimeSlot(start, end);

        timeSlot.Start.ShouldBe(start);
        timeSlot.End.ShouldBe(end);
    }

    [Fact]
    public void GivenStartEqualsEnd_WhenCreatingTimeSlot_ShouldThrowArgumentException()
    {
        var time = new DateTimeOffset(2026, 10, 9, 10, 0, 0, TimeSpan.Zero);

        var exception = Should.Throw<ArgumentException>(() => new TimeSlot(time, time));

        exception.Message.ShouldBe("Start must be before end.");
    }

    [Fact]
    public void GivenStartAfterEnd_WhenCreatingTimeSlot_ShouldThrowArgumentException()
    {
        var end = new DateTimeOffset(2026, 10, 9, 10, 0, 0, TimeSpan.Zero);
        var start = end.AddHours(1);

        var exception = Should.Throw<ArgumentException>(() => new TimeSlot(start, end));

        exception.Message.ShouldBe("Start must be before end.");
    }

    [Fact]
    public void GivenSameStartAndEnd_WhenComparingTimeSlots_ShouldBeEqual()
    {
        var start = new DateTimeOffset(2026, 10, 9, 10, 0, 0, TimeSpan.Zero);
        var end = start.AddHours(1);
        var first = new TimeSlot(start, end);
        var second = new TimeSlot(start, end);

        first.ShouldBe(second);
    }

    [Fact]
    public void GivenDifferentTimes_WhenComparingTimeSlots_ShouldNotBeEqual()
    {
        var start = new DateTimeOffset(2026, 10, 9, 10, 0, 0, TimeSpan.Zero);
        var first = new TimeSlot(start, start.AddHours(1));
        var second = new TimeSlot(start, start.AddHours(2));

        first.ShouldNotBe(second);
    }
}
