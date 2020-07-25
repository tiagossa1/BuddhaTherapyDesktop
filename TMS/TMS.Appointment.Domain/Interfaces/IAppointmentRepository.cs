using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Appointment.Domain.Models;

namespace TMS.Appointment.Domain.Interfaces
{
    public interface IAppointmentRepository
    {
        bool Create(AppointmentModel obj);

        bool Update(AppointmentModel obj);

        bool Delete(Guid id);
        bool DeleteByClientID(Guid id);

        AppointmentModel Get(Guid id);

        List<AppointmentModel> GetAll();
    }
}
