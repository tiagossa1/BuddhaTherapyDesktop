using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.UI.UIModels
{
    public class ClientUIModel
    {
        public ClientUIModel()
        {
        }

        public ClientUIModel(string firstName, string lastName, string address, int phoneNumber, string email, int nif, string jobTitle)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
            NIF = nif;
            JobTitle = jobTitle;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Address { get; private set; }
        public int PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public int NIF { get; private set; }
        public string JobTitle { get; private set; }
    }
}
