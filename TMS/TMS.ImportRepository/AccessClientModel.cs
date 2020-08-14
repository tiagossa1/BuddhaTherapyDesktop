using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.ImportRepository
{
    public class AccessClientModel
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Apelidos { get; set; }
        public string Morada { get; set; }
        public string Localidade { get; set; }
        public string Telemvel { get; set; }
        public string TelefoneFixo { get; set; }
        public string Email { get; set; }
        public string Observaes { get; set; }
        public string NIF { get; set; }
        public string DataDeNascimento { get; set; }
        public string Profisso { get; set; }
    }
}
