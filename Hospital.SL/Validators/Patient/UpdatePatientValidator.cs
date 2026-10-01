using FluentValidation;
using Hospital.BL.DTOs.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BL.Validators.Patient
{
    public class UpdatePatientValidator : AbstractValidator<UpdatePatientDto>
    {
        public UpdatePatientValidator()
        {
                RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Patient name is required.")
            .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

                RuleFor(x => x.Illness)
            .NotEmpty().WithMessage("Illness description is required.")
            .MaximumLength(200).WithMessage("Illness description cannot exceed 200 characters.");

                RuleFor(x => x.Birthday)
            .NotEmpty().WithMessage("Birthday is required.")
            .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today))
            .WithMessage("Birthday cannot be in the future.");
        }
    }
}
