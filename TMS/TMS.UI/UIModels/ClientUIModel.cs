using FastMember;
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
            Nome = firstName;
            Sobrenome = lastName;
            Endereco = address;
            Contacto = phoneNumber;
            Email = email;
            NIF = nif;
            Profissao = jobTitle;
        }

        [Ordinal(0)]
        public string Nome { get; set; }
        [Ordinal(1)]
        public string Sobrenome { get; set; }
        [Ordinal(2)]
        public string Endereco { get; set; }
        [Ordinal(3)]
        public int Contacto { get; set; }
        [Ordinal(4)]
        public string Email { get; set; }
        [Ordinal(5)]
        public int NIF { get; set; }
        [Ordinal(6)]
        public string Profissao { get; set; }
    }
}
