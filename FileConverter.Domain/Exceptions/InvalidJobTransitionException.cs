using FileConverter.Domain.Enums;

namespace FileConverter.Domain.Exceptions
{
    public sealed class InvalidJobTransitionException : DomainException
    {
        public InvalidJobTransitionException(Guid jobId, ConversionStatus from, ConversionStatus to)
            : base($"Job {jobId} cannot transition from {from} to {to}.") { }
    }
}
