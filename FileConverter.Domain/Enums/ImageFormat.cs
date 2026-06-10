namespace FileConverter.Domain.Enums;

public enum ImageFormat
{
    // ===== فرمت‌های رایج (پیشنهادی برای شروع) =====
    Png, // Portable Network Graphics - شفافیت و کیفیت بالا
    Jpeg, // Joint Photographic Experts Group - بهترین برای عکس‌ها
    Jpg, // همان JPEG (برای راحتی کاربر)
    Webp, // WebP - فرمت مدرن گوگل (کیفیت + حجم کم)
    Bmp, // Bitmap - بدون فشرده‌سازی
    Gif, // Graphics Interchange Format - انیمیشن و رنگ محدود
    Ico, // Windows Icon - برای آیکون‌ها
    
    // ===== فرمت‌های پیشرفته (برای آینده) =====
    Tiff, // Tagged Image File Format - کیفیت بالا، مناسب چاپ
    Tif, // همان TIFF
    Heic, // High Efficiency Image Format - فرمت اپل
    Heif, // High Efficiency Image Format - فرمت مدرن
    Avif, // AV1 Image Format - جدیدترین فرمت با فشرده‌سازی عالی
    Svg, // Scalable Vector Graphics - برداری (نیاز به کتابخانه خاص)

    // ===== فرمت‌های خاص =====
    Tga, // Truevision Targa
    Psd, // Photoshop Document
    Exr, // OpenEXR (HDR)
    Hdr, // Radiance HDR
    Pbm, // Portable Bitmap
    Pgm, // Portable Graymap
    Ppm, // Portable Pixmap
    Pnm, // Portable AnyMap
}