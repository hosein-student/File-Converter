namespace FileConverter.Domain.Interfaces
{
    public interface IFileStorageService
    {
        Task<string> SaveAsync(Stream fileStream, string fileName, CancellationToken ct = default);
        Task<Stream> GetAsync(string storagePath, CancellationToken ct = default);
        Task DeleteAsync(string storagePath, CancellationToken ct = default);
    }
}
