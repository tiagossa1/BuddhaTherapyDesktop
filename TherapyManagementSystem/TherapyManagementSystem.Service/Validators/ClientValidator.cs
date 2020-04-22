using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using TherapyManagementSystem.Domain.Entities;

namespace TherapyManagementSystem.Service.Validators
{
    public class ClientValidator : AbstractValidator<Client>
    {
        public ClientValidator()
        {
            RuleFor(c => c)
                .NotNull()
                .OnAnyFailure(x => throw new ArgumentNullException("Couldn't found the object."));
            RuleFor(c => c.FirstName)
                .NotNull()
                .NotEmpty();
            RuleFor(c => c.LastName)
                .NotEmpty()
                .NotNull();
            RuleFor(c => c.Address)
                .NotEmpty()
                .NotNull();
            RuleFor(c => c.JobTitle)
                .NotEmpty()
                .NotNull();
            RuleFor(c => c.NIF)
                .NotEmpty()
                .NotNull();
            RuleFor(c => c.PhoneNumber)
                .NotEmpty()
                .NotNull()
                .MaximumLength(9);
        }
    }
}
