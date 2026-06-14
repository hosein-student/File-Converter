using FluentValidation;

namespace FileConverter.Application.Jobs.Commands.SubmitConversionJob
{
    public sealed class SubmitConversionJobValidator
    : AbstractValidator<SubmitConversionJobCommand>
    {
        private static readonly string[] Allowed = ["pdf", "docx"];

        public SubmitConversionJobValidator()
        {
            RuleFor(x => x.FileName)
                .NotEmpty().WithMessage("File name is required.")
                .MaximumLength(50).WithMessage("File name is too long.");

            RuleFor(x => x.FileSizeInBytes)
                .GreaterThan(0).WithMessage("File must not be empty.")
                .LessThanOrEqualTo(50 * 1024 * 1024)
                .WithMessage("File must not exceed 50 MB.");

            RuleFor(x => x.TargetFormat)
                .NotEmpty()
                .Must(f => Allowed.Contains(f.ToLowerInvariant()))
                .WithMessage("Target format must be 'pdf' or 'docx'.");

            RuleFor(x => x.FileStream)
                .NotNull().WithMessage("File stream is required.");
        }
    }
}
