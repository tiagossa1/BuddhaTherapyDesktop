using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using TherapyManagementSystem.Domain.Entities;

namespace TherapyManagementSystem.Service.Validators
{
    public class AppointmentValidator : AbstractValidator<Appointment>
    {
        public AppointmentValidator()
        {
            RuleFor(c => c.AppointmentDate)
                .NotEmpty()
                .NotNull()
                .Must(BeAValidDate);

            RuleFor(c => c.AppointmentTypeDescription)
                .NotEmpty()
                .NotNull();

            RuleFor(c => c.ClientId)
                .NotEmpty()
                .NotNull();
        }

        private static bool BeAValidDate(DateTime date)
        {
            return !(date == default);
        }
    }
}
