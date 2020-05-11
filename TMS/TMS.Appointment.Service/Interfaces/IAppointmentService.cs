using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Appointment.Service.Model;

namespace TMS.Appointment.Service.Interfaces
{
    public interface IAppointmentService
    {
        IList<string> Post(AppointmentDto obj);

        IList<string> Put(AppointmentDto obj);

        bool Delete(Guid id);

        AppointmentDto Get(Guid id);

        IList<AppointmentDto> GetAll();
    }
}
