using FastMember;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.UI.UIModels
{
    public class AppointmentUIModel
    {
        public AppointmentUIModel(string clientName, DateTime dateTime, string appointmentTypeName, string appointmentDescription)
        {
            Nome = clientName;
            Data = dateTime;
            TipoDeConsulta = appointmentTypeName;
            Descricao = appointmentDescription;
        }

        public AppointmentUIModel()
        {
        }

        [Ordinal(0)]
        public string Nome { get; set; }
        [Ordinal(1)]
        public DateTime Data { get; set; }
        [Ordinal(2)]
        public string TipoDeConsulta { get; set; }
        [Ordinal(3)]
        public string Descricao { get; set; }
    }
}
