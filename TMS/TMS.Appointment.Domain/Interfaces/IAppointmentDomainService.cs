using System;
using System.Collections.Generic;
using TMS.Appointment.Domain.Models;

namespace TMS.Appointment.Domain.Interfaces
{
    public interface IAppointmentDomainService
    {
        List<string> Create(AppointmentModel obj);

        List<string> Update(AppointmentModel obj);

        bool Delete(Guid id);

        AppointmentModel Get(Guid id);

        List<AppointmentModel> GetAll();
    }
}
