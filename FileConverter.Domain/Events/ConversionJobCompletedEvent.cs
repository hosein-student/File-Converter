namespace FileConverter.Domain.Events
{
    public sealed record ConversionJobCompletedEvent(
        Guid JobId,
        string OutputPath
    ) : IDomainEvent
    {
        public Guid EventId { get; } = Guid.NewGuid();
        public DateTime OccurredAt { get; } = DateTime.UtcNow;
    }
}
