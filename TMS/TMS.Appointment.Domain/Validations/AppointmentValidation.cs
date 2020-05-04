using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TMS.Appointment.Domain.Models;

namespace TMS.Appointment.Domain.Validations
{
    public abstract class AppointmentValidation<T> : AbstractValidator<T> where T : AppointmentModel
    {
        protected void ValidateDateTime()
        {
            RuleFor(c => c.DateTime)
                .Must(BeAValidDate).WithMessage("Invalid datetime.");
        }

        protected void ValidateAppointmentTypeID()
        {
            RuleFor(c => c.AppointmentTypeID)
                .NotEmpty().WithMessage("Invalid Appointment Type ID.");
        }

        protected void ValidateAppointmentTypeName()
        {
            RuleFor(c => c.AppointmentTypeName)
                .NotEmpty().WithMessage("Appointment Type Name cannot be empty.")
                .NotNull().WithMessage("Appointment Type Name cannot be null.");
        }

        private bool BeAValidDate(DateTime date)
        {
            return date != default;
        }
    }
}
