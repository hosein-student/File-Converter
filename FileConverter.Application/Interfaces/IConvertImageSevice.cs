using FileConverter.Domain.Enums;
using FileConverter.Domain.Models;

namespace FileConverter.Application.Interfaces;

public interface IConvertImageSevice
{
    Task<ConversionStreamResult> ConvertStreamImageAsync(
        Stream inputImage,
        string originalFileName,
        ImageFormat targetFormat,
        CancellationToken cancellationToken);
}