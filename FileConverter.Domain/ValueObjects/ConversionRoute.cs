using FileConverter.Domain.Enums;
using FileConverter.Domain.Exceptions;

namespace FileConverter.Domain.ValueObjects
{
    public sealed class ConversionRoute
    {
        public DocumentFormat InitialFormat {  get;}
        public DocumentFormat TargetFormat { get;}

        private ConversionRoute(DocumentFormat initialFormat, DocumentFormat targetFormat)
        {
            InitialFormat = initialFormat;
            TargetFormat = targetFormat;
        }

        public static ConversionRoute Create(DocumentFormat initialFormat, DocumentFormat targetFormat)
        {
            if (initialFormat == targetFormat)
               throw new SameFormatConversionException(initialFormat);
                

            return new ConversionRoute(initialFormat, targetFormat);
        }

        public override bool Equals(object? obj) =>
            obj is ConversionRoute other && InitialFormat == other.InitialFormat && TargetFormat == other.TargetFormat;

        public override int GetHashCode() => HashCode.Combine(InitialFormat, TargetFormat);
    }
}
