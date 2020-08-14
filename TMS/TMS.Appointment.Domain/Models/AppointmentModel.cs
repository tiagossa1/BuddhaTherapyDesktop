using System;
using TMS.Appointment.Domain.Validations;
using TMS.Client.Domain.Model;

namespace TMS.Appointment.Domain.Models
{
    public class AppointmentModel : Entity
    {
        public Guid ClientID { get; set; }
        public DateTime DateTime { get; set; }
        public int AppointmentTypeID { get; set; }
        public string AppointmentTypeName { get; set; }
        public string AppointmentDescription { get; set; }
        public override bool IsValid()
        {
            ValidationResult = new AppointmentModelValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
