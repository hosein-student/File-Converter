using FileConverter.Domain.Enums;

namespace FileConverter.Domain.Interfaces
{
    public interface IDocumentConversionService
    {
        Task<string> ConvertAsync(
            string inputPath,
            DocumentFormat targetFormat,
            CancellationToken ct = default
        );
    }
}
