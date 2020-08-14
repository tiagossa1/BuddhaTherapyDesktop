using System;
using TMS.Client.Domain.Validations;

namespace TMS.Client.Domain.Model
{
    public class ClientModel : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string NIF { get; set; }
        public string JobTitle { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new ClientModelValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
