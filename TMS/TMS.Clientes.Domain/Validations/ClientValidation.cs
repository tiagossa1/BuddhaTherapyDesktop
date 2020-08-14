using FluentValidation;
using TMS.Client.Domain.Model;

namespace TMS.Client.Domain.Validations
{
    public abstract class ClientValidation<T> : AbstractValidator<T> where T : ClientModel
    {
        protected void ValidateName()
        {
            RuleFor(c => c.FirstName)
                .NotEmpty().WithMessage("Please ensure you have entered the First Name");
        }
        protected void ValidateLastName()
        {
            RuleFor(c => c.LastName)
                            .NotEmpty().WithMessage("Please ensure you have entered the Last Name");
        }
        protected void ValidateAddress()
        {
            RuleFor(c => c.Address)
                            .NotEmpty().WithMessage("Please ensure you have entered the Address");
        }
        protected void ValidateJobTitle()
        {
            RuleFor(c => c.JobTitle)
                            .NotEmpty().WithMessage("Please ensure you have entered the JobTitle");
        }
        protected void ValidateEmail()
        {
            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Please ensure you have entered the Email")
                .EmailAddress();
        }
        protected void ValidateNif()
        {
            RuleFor(c => c.NIF)
                .Must(x => x?.Length == 9).WithMessage("Please ensure you have entered the Nif");
        }
        protected void ValidatePhoneNumber()
        {
            RuleFor(c => c.PhoneNumber)
                .Must(x => x?.Length == 9).WithMessage("Please ensure you have entered the Phone Number");
        }
    }
}