using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using TherapyManagementSystem.Domain.Entities;

namespace TherapyManagementSystem.Service.Validators
{
    public class InvoiceValidator : AbstractValidator<Invoice>
    {
        public InvoiceValidator()
        {
            RuleFor(c => c.AppointmentId)
                .NotEmpty()
                .NotNull();

            RuleFor(c => c.ClientId)
                .NotEmpty()
                .NotNull();

            RuleFor(c => c.Date)
                .NotEmpty()
                .NotNull()
                .Must(BeAValidDate);

            RuleFor(c => c.Price)
                .NotEmpty()
                .NotNull();
        }

        private static bool BeAValidDate(DateTime date)
        {
            return !(date == default);
        }
    }
}
