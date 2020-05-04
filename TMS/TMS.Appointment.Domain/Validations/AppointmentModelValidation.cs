using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Appointment.Domain.Models;

namespace TMS.Appointment.Domain.Validations
{
    public class AppointmentModelValidation : AppointmentValidation<AppointmentModel>
    {
        public AppointmentModelValidation()
        {
            ValidateAppointmentTypeID();
            ValidateAppointmentTypeName();
            ValidateDateTime();
        }
    }
}
