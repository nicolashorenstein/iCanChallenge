using FluentValidation;
using iCanChallenge.Application.Students.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCanChallenge.Application.Validators.Students
{
    public class GetStudentByIdValidator : AbstractValidator<GetStudentsByIdQuery>
    {
        public GetStudentByIdValidator()
        {
            RuleFor(x => x.StudentId)
             .NotNull()
             .GreaterThan(0)
             .Must(x => x.ToString().Length <= 5)
             .WithMessage("The StudentId must be a positive integer with no more than 5 digits.");
        }
    }
}
