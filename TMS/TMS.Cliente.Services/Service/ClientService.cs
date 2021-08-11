using System;
using System.Collections.Generic;
using System.Linq;
using TMS.Appointment.Domain.Interfaces;
using TMS.Appointment.Domain.Services;
using TMS.Appointment.Repository;
using TMS.Client.Domain.Interfaces;
using TMS.Client.Domain.Model;
using TMS.Clientes.Service.Mapping;
using TMS.Clientes.Service.Model;
using TMS.Clientes.Services.Interfaces;
using TMS.Invoice.Domain.Interfaces;
using TMS.Invoice.Domain.Services;
using TMS.Invoice.Repository.Repository;

namespace TMS.Client.Domain.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientDomainService clientDomainService;
        private readonly IAppointmentDomainService appointmentDomainService;
        private readonly IInvoiceDomainService invoiceDomainService;
        public ClientService(IClientDomainService clientDomainService)
        {
            this.clientDomainService = clientDomainService;
            appointmentDomainService = new AppointmentDomainService(new AppointmentRepository());
            invoiceDomainService = new InvoiceDomainService(new InvoiceRepository());
        }
        public bool Delete(Guid id)
        {
            foreach (var appointment in appointmentDomainService.GetAll().FindAll(x => x.ClientID == id))
            {
                appointmentDomainService.Delete(appointment.Id);
            }

            foreach (var invoice in invoiceDomainService.GetAll().FindAll(x => x.ClientID == id))
            {
                invoiceDomainService.Delete(invoice.Id);
            }

            return clientDomainService.Delete(id);
        }

        public ClientDto Get(Guid id)
        {
            return ClientAssembler.EntityToDto(clientDomainService.Get(id));
        }

        public List<ClientDto> GetAll()
        {
            return ClientAssembler.EntitiesToDto(clientDomainService.GetAll().ToList());
        }

        public List<string> Create(ClientDto cliente)
        {
            return clientDomainService.Post(ClientAssembler.DtoToEntity(cliente));
        }

        public List<string> Edit(ClientDto cliente)
        {
            return clientDomainService.Put(ClientAssembler.DtoToEntity(cliente));
        }
    }
}