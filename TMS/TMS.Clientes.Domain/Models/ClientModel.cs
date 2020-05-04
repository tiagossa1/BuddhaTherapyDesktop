using System;
using TMS.Client.Domain.Validations;

namespace TMS.Client.Domain.Model
{
    public class ClientModel : Entity
    {
        public ClientModel(Guid id, string firstName, string lastName, string address, int phoneNumber, string email, int nif, string jobTitle)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
            NIF = nif;
            JobTitle = jobTitle;
        }

        public ClientModel()
        {
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Address { get; private set; }
        public int PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public int NIF { get; private set; }
        public string JobTitle { get; private set; }

        public override bool IsValid()
        {
            ValidationResult = new ClientModelValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
