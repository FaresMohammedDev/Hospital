using FluentValidation;
using Hospital.BL.DTOs.Treatment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BL.Validators.Treatment
{
    public class UpdateTreatmentValidator : AbstractValidator<UpdateTreatmentDto>
    {
        public UpdateTreatmentValidator()
        {
                    RuleFor(x => x.PatientId)
                .GreaterThan(0).WithMessage("Please select a valid Patient.");

                    RuleFor(x => x.DoctorId)
                .GreaterThan(0).WithMessage("Please select a valid Doctor.");

                    RuleFor(x => x.TreatmentDateTime)
                .NotEmpty().WithMessage("Treatment date and time is required.")
                .GreaterThan(DateTime.Now).WithMessage("Treatment date and time must be in the future.");
        }
    }
}
