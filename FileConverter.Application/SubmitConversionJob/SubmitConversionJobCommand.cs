using FileConverter.Application.Common.Results;
using FileConverter.Domain.Enums;
using MediatR;

namespace FileConverter.Application.Jobs.Commands.SubmitConversionJob
{
    public sealed record SubmitConversionJobCommand(
     Stream FileStream,
     string FileName,
     long FileSizeInBytes,
     string TargetFormat
 ) : IRequest<Result<Guid>>;
}
