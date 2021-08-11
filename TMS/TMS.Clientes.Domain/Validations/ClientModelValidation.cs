using TMS.Client.Domain.Model;

namespace TMS.Client.Domain.Validations
{
    public class ClientModelValidation : ClientValidation<Model.ClientModel>
    {
        public ClientModelValidation()
        {
            ValidateName();
            ValidateLastName();
            ValidateAddress();
            //ValidateJobTitle();
            //ValidateNif();
            //ValidatePhoneNumber();
            //ValidateEmail();
        }
    }
}
