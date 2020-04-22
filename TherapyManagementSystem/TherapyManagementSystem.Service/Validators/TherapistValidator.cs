using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using TherapyManagementSystem.Domain.Entities;

namespace TherapyManagementSystem.Service.Validators
{
    public class TherapistValidator : AbstractValidator<Therapist>
    {
        public TherapistValidator()
        {
            RuleFor(c => c.FirstName)
                .NotEmpty()
                .NotNull();

            RuleFor(c => c.LastName)
                .NotEmpty()
                .NotNull();

            RuleFor(c => c.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress();

            RuleFor(c => c.Username)
                .NotEmpty()
                .NotNull();

            RuleFor(c => c.Password)
                .NotEmpty()
                .NotNull();
        }
    }
}
