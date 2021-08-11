using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TMS.Appointment.Domain.Interfaces;
using TMS.Appointment.Domain.Models;

namespace TMS.Appointment.Domain.Services
{
    public class AppointmentDomainService : IAppointmentDomainService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        public AppointmentDomainService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public bool Delete(Guid id)
        {
            return _appointmentRepository.Delete(id);
        }

        public AppointmentModel Get(Guid id)
        {
            return _appointmentRepository.Get(id);
        }

        public List<AppointmentModel> GetAll()
        {
            return _appointmentRepository.GetAll();
        }

        public List<string> Create(AppointmentModel obj)
        {
            if (!obj.IsValid())
                return NotifyValidationErrors(obj);

            bool result = _appointmentRepository.Create(obj);

            return result ? new List<string>() : new List<string>() { "Error inserting on the database" };
        }

        public List<string> Update(AppointmentModel obj)
        {
            if (!obj.IsValid())
                return NotifyValidationErrors(obj);

            bool result = _appointmentRepository.Update(obj);

            return result ? new List<string>() : new List<string>() { "Error updating on the database" };
        }

        private List<string> NotifyValidationErrors(AppointmentModel appointment)
        {
            return appointment.ValidationResult.Errors.Select(x => x.ErrorMessage).ToList();
        }

        public long Count()
        {
            return _appointmentRepository.Count();
        }
    }
}
