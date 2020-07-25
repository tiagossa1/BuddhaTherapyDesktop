using System;
using System.Collections.Generic;
using System.Linq;
using TMS.Appointment.Domain.Interfaces;
using TMS.Appointment.Domain.Services;
using TMS.Appointment.Repository;
using TMS.Client.Domain.Interfaces;
using TMS.Client.Domain.Model;
using TMS.Invoice.Domain.Interfaces;
using TMS.Invoice.Repository.Repository;

namespace TMS.Client.Domain.Services
{
    public class ClientDomainService : IClientDomainService
    {
        private readonly IClientRepository _clienteRepository;
        private readonly IAppointmentRepository appointmentRepository;
        private readonly IInvoiceRepository invoiceRepository;
        public ClientDomainService(IClientRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
            appointmentRepository = new AppointmentRepository();
            invoiceRepository = new InvoiceRepository();
        }
        public bool Delete(Guid id)
        {
            appointmentRepository.DeleteByClientID(id);
            invoiceRepository.DeleteByClientID(id);
            return _clienteRepository.Delete(id);
        }

        public ClientModel Get(Guid id)
        {
            return _clienteRepository.Get(id);
        }

        public List<ClientModel> GetAll()
        {
            return _clienteRepository.GetAll();
        }

        public List<string> Post(ClientModel cliente)
        {
            if (!cliente.IsValid())
                return NotifyValidationErrors(cliente);

            bool result = _clienteRepository.Post(cliente);

            return result ? new List<string>() : new List<string>() { "Error inserting on the database" };
        }

        public List<string> Put(ClientModel cliente)
        {
            if (!cliente.IsValid())
                return NotifyValidationErrors(cliente);

            bool result = _clienteRepository.Put(cliente);

            return result ? new List<string>() : new List<string>() { "Error updating on the database" };
        }
        private List<string> NotifyValidationErrors(ClientModel cliente)
        {
            return cliente.ValidationResult.Errors.Select(x => x.ErrorMessage).ToList();
        }
    }
}