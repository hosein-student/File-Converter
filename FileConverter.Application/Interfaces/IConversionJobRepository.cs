using FileConverter.Domain.Entities;

namespace FileConverter.Domain.Interfaces
{
    public interface IConversionJobRepository
    {
        Task<ConversionJob?> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task AddAsync(ConversionJob job, CancellationToken ct = default);
        Task UpdateAsync(ConversionJob job, CancellationToken ct = default);
    }
}
