namespace FileConverter.Domain.Models;

public record ConversionStreamResult(
    Stream? OutputStream, // خروجی: استریم عکس تبدیل شده
    string? FileName, // خروجی: نام فایل جدید (مثلاً photo.jpg)
    string ContentType, // خروجی: نوع MIME (مثلاً image/jpeg)
    long SizeInBytes, // خروجی: حجم فایل تبدیل شده
    bool Success, // خروجی: موفقیت یا شکست عملیات
    string? ErrorMessage = null);  // خروجی: پیام خطا (در صورت شکست))
