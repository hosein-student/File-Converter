namespace FileConverter.Domain.Exceptions
{
    public sealed class JobNotFoundException : DomainException
    {
        public JobNotFoundException(Guid jobId)
            : base($"Conversion job {jobId} was not found.") { }
    }
}
