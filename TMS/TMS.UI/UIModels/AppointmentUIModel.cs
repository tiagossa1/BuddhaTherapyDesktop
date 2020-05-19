using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.UI.UIModels
{
    public class AppointmentUIModel
    {
        public AppointmentUIModel(string clientName, DateTime dateTime, string appointmentTypeName)
        {
            ClientName = clientName;
            DateTime = dateTime;
            AppointmentTypeName = appointmentTypeName;
        }

        public AppointmentUIModel()
        {
        }

        public string ClientName { get; set; }
        public DateTime DateTime { get; set; }
        public string AppointmentTypeName { get; set; }
    }
}
