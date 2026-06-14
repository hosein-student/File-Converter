// using FileConverter.Domain.Enums;
// using FileConverter.Domain.Events;
// using FileConverter.Domain.Exceptions;
// using FileConverter.Domain.ValueObjects;
//
// namespace FileConverter.Domain.Entities
// {
//     public sealed class ConversionJob
//     {
//         public Guid Id { get; private set; }
//         public SourceFile SourceFile { get; private set; }
//         public ConversionRoute Route { get; private set; }
//         public ConversionStatus Status { get; private set; }
//         public string? OutPutPath{  get; private set; }// null until Completed
//         public string? ErrorMessage { get; private set; } // null unless Failed
//         public DateTime CreatedAt { get; private set; }
//         public DateTime? CompletedAt { get; private set; }
//
//         private readonly List<IDomainEvent> _domainEvents = new();
//         public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();
//
//         private ConversionJob() { }
//
//         public static ConversionJob Create(SourceFile sourceFile, ConversionRoute route)
//         {
//             var job = new ConversionJob
//             {
//                 Id = Guid.NewGuid(),
//                 SourceFile = sourceFile,
//                 Route = route,
//                 Status = ConversionStatus.Queued,
//                 CreatedAt = DateTime.UtcNow
//             };
//
//             job._domainEvents.Add(new ConversionJobCreatedEvent(job.Id, route));
//             return job;
//         }
//
//         public void MarkAsProcessing()
//         {
//             if (Status != ConversionStatus.Queued)
//                 throw new InvalidJobTransitionException(Id, Status, ConversionStatus.Processing);
//
//             Status = ConversionStatus.Processing;
//         }
//
//         public void MarkAsCompleted(string outputPath)
//         {
//             if (Status != ConversionStatus.Processing)
//                 throw new InvalidJobTransitionException(Id, Status, ConversionStatus.Completed);
//
//             if (string.IsNullOrWhiteSpace(outputPath))
//                 throw new ArgumentException("Output path cannot be empty.", nameof(outputPath));
//
//             Status = ConversionStatus.Completed;
//             OutPutPath = outputPath;
//             CompletedAt = DateTime.UtcNow;
//
//             _domainEvents.Add(new ConversionJobCompletedEvent(Id, outputPath));
//         }
//
//         public void MarkAsFailed(string errorMessage)
//         {
//             if (Status != ConversionStatus.Processing)
//                 throw new InvalidJobTransitionException(Id, Status, ConversionStatus.Failed);
//
//             Status = ConversionStatus.Failed;
//             ErrorMessage = errorMessage;
//             CompletedAt = DateTime.UtcNow;
//
//             _domainEvents.Add(new ConversionJobFailedEvent(Id, errorMessage));
//         }
//
//         public void ClearDomainEvents() => _domainEvents.Clear();
//     }
// }
