using System;
using System.Collections.Generic;
using System.Linq;
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

        public IList<AppointmentModel> GetAll()
        {
            return _appointmentRepository.GetAll();
        }

        public IList<string> Post(AppointmentModel obj)
        {
            if (!obj.IsValid())
                return NotifyValidationErrors(obj);

            bool result = _appointmentRepository.Post(obj);

            return result ? new List<string>() : new List<string>() { "Error inserting on the database" };
        }

        public IList<string> Put(AppointmentModel obj)
        {
            if (!obj.IsValid())
                return NotifyValidationErrors(obj);

            bool result = _appointmentRepository.Put(obj);

            return result ? new List<string>() : new List<string>() { "Error updating on the database" };
        }

        private IList<string> NotifyValidationErrors(AppointmentModel appointment)
        {
            return appointment.ValidationResult.Errors.Select(x => x.ErrorMessage).ToList();
        }
    }
}
