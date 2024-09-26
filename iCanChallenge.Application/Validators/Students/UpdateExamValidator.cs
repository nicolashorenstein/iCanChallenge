using FluentValidation;
using iCanChallenge.Application.Students.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCanChallenge.Application.Validators.Students
{
    public class UpdateExamValidator : AbstractValidator<UpdateExamQuery>
    {
        public UpdateExamValidator()
        {
            RuleFor(x => x.Command.StudentId)
             .NotNull()
             .GreaterThan(0)
             .Must(x => x.ToString().Length <= 5)
             .WithMessage("The StudentId must be a positive integer with no more than 5 digits.");
            RuleFor(x => x.Command.ExamId)
                .NotNull()
                .GreaterThan(0)
                .Must(x => x.ToString().Length == 3)
                .WithMessage("The ExamId must be a positive integer with no more than 3 digits.");
            RuleFor(x => x.Command.DateTaken).NotNull();
            RuleFor(x => x.Command.Score).NotNull();

        }
    }
}
