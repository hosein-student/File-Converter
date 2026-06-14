namespace FileConverter.Domain.Exceptions
{
    public sealed class FileTooLargeException : DomainException
    {
        public FileTooLargeException(long actual, long max)
            : base($"File size {actual} bytes exceeds the maximum allowed {max} bytes.") { }
    }
}
