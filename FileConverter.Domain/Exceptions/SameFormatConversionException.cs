using FileConverter.Domain.Enums;

namespace FileConverter.Domain.Exceptions
{
    public sealed class SameFormatConversionException : DomainException
    {
        public SameFormatConversionException(DocumentFormat format)
        : base($"Can't convert a {format} file to the same format.") { }
    }
}
