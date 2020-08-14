using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Appointment.Domain.Interfaces;
using TMS.Appointment.Service.Interfaces;
using TMS.Appointment.Service.Mapping;
using TMS.Appointment.Service.Model;
using TMS.Invoice.Domain.Interfaces;
using TMS.Invoice.Domain.Services;
using TMS.Invoice.Repository.Repository;

namespace TMS.Appointment.Service.Service
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentDomainService appointmentDomainService;
        private readonly IInvoiceDomainService invoiceDomainService;

        public AppointmentService(IAppointmentDomainService appointmentDomainService)
        {
            this.appointmentDomainService = appointmentDomainService;
            invoiceDomainService = new InvoiceDomainService(new InvoiceRepository());
        }

        public bool Delete(Guid id)
        {
            foreach (var invoice in invoiceDomainService.GetAll().FindAll(x => x.AppointmentID == id))
            {
                invoiceDomainService.Delete(invoice.Id);
            }

            return appointmentDomainService.Delete(id);
        }

        public AppointmentDto Get(Guid id)
        {
            return AppointmentAssembler.EntityToDto(appointmentDomainService.Get(id));
        }

        public List<AppointmentDto> GetAll()
        {
            return AppointmentAssembler.EntitiesToDto(appointmentDomainService.GetAll().ToList());
        }

        public List<string> Create(AppointmentDto obj)
        {
            return appointmentDomainService.Create(AppointmentAssembler.DtoToEntity(obj));
        }

        public List<string> Edit(AppointmentDto obj)
        {
            return appointmentDomainService.Update(AppointmentAssembler.DtoToEntity(obj));
        }
    }
}
