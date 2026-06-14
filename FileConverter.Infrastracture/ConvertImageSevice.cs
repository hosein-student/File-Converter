using System.Net.Mime;
using System.Runtime.InteropServices;
using FileConverter.Application.Interfaces;
using FileConverter.Domain.Enums;
using FileConverter.Domain.Models;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Bmp;
using SixLabors.ImageSharp.Formats.Gif;
using SixLabors.ImageSharp.Formats.Ico;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Formats.Webp;

namespace FileConverter.Infrastracture;

public class ConvertImageSevice : IConvertImageSevice
{
    public async Task<ConversionStreamResult> ConvertStreamImageAsync(Stream inputImage, string originalFileName,
        ImageFormat targetFormat,
        CancellationToken cancellationToken)
    {
        try
        {
            using var image = await Image.LoadAsync(inputImage, cancellationToken);

            var outputStream = new MemoryStream();
            var encoder = GetConvertFormat(targetFormat);
            await image.SaveAsync(outputStream, encoder, cancellationToken);
            outputStream.Position = 0;
            var newFileName = Path.GetFileNameWithoutExtension(originalFileName) + GetExtension(targetFormat);
            var contentType = GetContentType(targetFormat);

            return new ConversionStreamResult(
                OutputStream: outputStream, // استریم حاوی عکس تبدیل شده
                FileName: newFileName, // اسم فایل جدید
                ContentType: contentType, // نوع محتوا
                SizeInBytes: outputStream.Length, // حجم فایل جدید
                Success: true, // یعنی موفق بوده
                ErrorMessage: null);
        }
        catch
        {
            return new ConversionStreamResult(
                OutputStream: null,
                FileName: null,
                ContentType: string.Empty,
                SizeInBytes: 0,
                Success: false,
                ErrorMessage: "انجام نشد بعدا تلاش کنید"
            );
        }
    }

    IImageEncoder GetConvertFormat(ImageFormat format)
    {
        return format switch
        {
            ImageFormat.Png => new PngEncoder(),
            ImageFormat.Jpeg => new JpegEncoder { Quality = 85 },
            ImageFormat.Jpg => new JpegEncoder { Quality = 85 },
            ImageFormat.Webp => new WebpEncoder { Quality = 85 },
            ImageFormat.Bmp => new BmpEncoder(),
            ImageFormat.Gif => new GifEncoder(),
            ImageFormat.Ico => new IcoEncoder(),
            _ => new PngEncoder()
        };
    }

    private string GetExtension(ImageFormat format)
    {
        return format switch
        {
            ImageFormat.Png => ".png",
            ImageFormat.Jpeg => ".jpeg",
            ImageFormat.Jpg => ".jpg",
            ImageFormat.Webp => ".webp",
            ImageFormat.Bmp => ".bmp",
            ImageFormat.Gif => ".gif",
            ImageFormat.Ico => ".ico",
            _ => ".png"
        };
    }

    private string GetContentType(ImageFormat format)
    {
        return format switch
        {
            ImageFormat.Png => "image/png",
            ImageFormat.Jpeg or ImageFormat.Jpg => "image/jpeg",
            ImageFormat.Webp => "image/webp",
            ImageFormat.Bmp => "image/bmp",
            ImageFormat.Gif => "image/gif",
            _ => "application/octet-stream"
        };
    }
}