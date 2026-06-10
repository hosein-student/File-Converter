using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using FileConverter.Application.Interfaces;
using FileConverter.Domain.Enums;
using FileConverter.Domain.Models;

namespace FileConverter.Application.UseCases.ConvertImage;

public class ConvertImageUseCase : IConvertImageUseCase
{
    private readonly IConvertImageSevice _convertImageSevice;

    public ConvertImageUseCase(IConvertImageSevice convertImageSevice)
    {
        _convertImageSevice = convertImageSevice;
    }

    public async Task<ConversionStreamResult> ExecuteAsync(Stream inputImage, string originalFileName,
        ImageFormat targetFormat,
        CancellationToken cancellationToken)
    {
        double sizeMB = 0.0;
        if (inputImage.CanSeek)
        {
            long size = inputImage.Length;
            sizeMB = size / (1024.0 * 1024.0);
        }

        if (sizeMB != 0 && sizeMB <= 15)
        {
            var result = await _convertImageSevice.ConvertStreamImageAsync(inputImage, originalFileName, targetFormat,
                cancellationToken);

            return result;
        }
        else
        {
            return new ConversionStreamResult(null, null, string.Empty, 0, false,
                "حجم تصویر نباید بیشتر از 15 مگابایت باشد.");
        }
    }
}