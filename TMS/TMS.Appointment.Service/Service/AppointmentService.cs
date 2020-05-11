using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Appointment.Domain.Interfaces;
using TMS.Appointment.Service.Interfaces;
using TMS.Appointment.Service.Mapping;
using TMS.Appointment.Service.Model;

namespace TMS.Appointment.Service.Service
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentDomainService appointmentDomainService;

        public AppointmentService(IAppointmentDomainService appointmentDomainService)
        {
            this.appointmentDomainService = appointmentDomainService;
        }

        public bool Delete(Guid id)
        {
            return appointmentDomainService.Delete(id);
        }

        public AppointmentDto Get(Guid id)
        {
            return AppointmentAssembler.EntityToDto(appointmentDomainService.Get(id));
        }

        public IList<AppointmentDto> GetAll()
        {
            return AppointmentAssembler.EntitiesToDto(appointmentDomainService.GetAll().ToList());
        }

        public IList<string> Post(AppointmentDto obj)
        {
            return appointmentDomainService.Post(AppointmentAssembler.DtoToEntity(obj));
        }

        public IList<string> Put(AppointmentDto obj)
        {
            return appointmentDomainService.Put(AppointmentAssembler.DtoToEntity(obj));
        }
    }
}
