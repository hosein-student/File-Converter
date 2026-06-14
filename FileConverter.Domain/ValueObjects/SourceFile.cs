using FileConverter.Domain.Exceptions;

namespace FileConverter.Domain.ValueObjects
{
    public sealed class SourceFile
    {
        public string OriginalFileName {  get;}
        public long SizeInBytes {  get;}
        public string StoragePath {  get;}

        private static readonly long MaxSizeInBytes = 50 * 1024 * 1024; //50MB

        private SourceFile(string originalFileName, long sizeInBytes, string storagePath)
        {
            OriginalFileName = originalFileName;
            SizeInBytes = sizeInBytes;
            StoragePath = storagePath; 
        }

        public static SourceFile Create(string originalFileName, long sizeInBytes, string storagePath)
        {
            if (string.IsNullOrWhiteSpace(originalFileName))
                throw new ArgumentNullException("File name cannot be empty.", nameof(originalFileName));

            if (sizeInBytes <= 0)
                throw new ArgumentException("File size must be positive.", nameof(sizeInBytes));

            if (sizeInBytes > MaxSizeInBytes)
                throw new FileTooLargeException(sizeInBytes, MaxSizeInBytes);

            if (string.IsNullOrWhiteSpace(storagePath))
                throw new ArgumentException("Storage path cannot be empty.", nameof(storagePath));

            return new SourceFile(originalFileName, sizeInBytes, storagePath);
        }
    }
}
