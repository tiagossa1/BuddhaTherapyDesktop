using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Appointment.Domain.Validations;

namespace TMS.Appointment.Domain.Models
{
    public class AppointmentModel : Entity
    {
        public AppointmentModel(Guid id, Guid clientID, DateTime dateTime, int appointmentTypeID, string appointmentTypeName)
        {
            Id = id;
            ClientID = clientID;
            DateTime = dateTime;
            AppointmentTypeID = appointmentTypeID;
            AppointmentTypeName = appointmentTypeName;
        }

        public AppointmentModel()
        {
        }

        public Guid ClientID { get; set; }
        public DateTime DateTime { get; set; }
        public int AppointmentTypeID { get; set; }
        public string AppointmentTypeName { get; set; }
        public override bool IsValid()
        {
            ValidationResult = new AppointmentModelValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
