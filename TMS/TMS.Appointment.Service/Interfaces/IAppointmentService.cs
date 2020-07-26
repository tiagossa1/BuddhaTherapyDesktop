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
        List<string> Post(AppointmentDto obj);

        List<string> Put(AppointmentDto obj);

        bool Delete(Guid id);

        AppointmentDto Get(Guid id);

        List<AppointmentDto> GetAll();
    }
}
