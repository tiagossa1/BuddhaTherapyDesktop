using System;

namespace TMS.Clientes.Service.Model
{
    public class ClientDto
    {
        public ClientDto(Guid id, string firstName, string lastName, string address, int phoneNumber, string email, int nif, string jobTitle)
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

        public ClientDto()
        {
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public int NIF { get; set; }
        public string JobTitle { get; set; }

        public override bool Equals(object obj)
        {
            var compareTo = obj as ClientDto;
            if (ReferenceEquals(this, compareTo)) return true;
            if (compareTo is null) return false;

            return Id.Equals(compareTo.Id);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }
    }
}
