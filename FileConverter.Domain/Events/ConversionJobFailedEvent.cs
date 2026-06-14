namespace FileConverter.Domain.Events
{
    public sealed record ConversionJobFailedEvent(
        Guid JobId,
        string Error
    ) :IDomainEvent
    {
        public Guid EventId { get; } = Guid.NewGuid();
        public DateTime OccurredAt { get; } = DateTime.UtcNow;
    }
}
