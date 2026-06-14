using FileConverter.Domain.ValueObjects;
namespace FileConverter.Domain.Events
{
    public sealed record ConversionJobCreatedEvent(
        Guid JobId,
        ConversionRoute Route
    ) : IDomainEvent
    {
        public Guid EventId { get; } = Guid.NewGuid();
        public DateTime OccurredAt { get; } = DateTime.UtcNow;
    }
}
