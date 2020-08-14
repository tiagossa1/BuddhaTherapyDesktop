using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Appointment.Domain.Models;
using TMS.Client.Domain.Model;
using TMS.Invoice.Domain.Models;
using TMS.Invoice.Service.Model;

namespace TMS.Invoice.Service.Mapping
{
    public static class InvoiceAssembler
    {
        public static InvoiceModel DtoToEntity(InvoiceDto invoiceDto)
        {
            if (invoiceDto is null)
                return new InvoiceModel();
            return new InvoiceModel()
            {
                Appointment = new AppointmentModel()
                {
                    Id = invoiceDto.Appointment.Id,
                    AppointmentDescription = invoiceDto.Appointment.AppointmentDescription,
                    AppointmentTypeID = invoiceDto.Appointment.AppointmentTypeID,
                    AppointmentTypeName = invoiceDto.Appointment.AppointmentTypeName,
                    Client = new ClientModel()
                    {
                        Address = invoiceDto.Appointment.Client.Address,
                        Email = invoiceDto.Appointment.Client.Email,
                        FirstName = invoiceDto.Appointment.Client.FirstName,
                        Id = invoiceDto.Appointment.Client.Id,
                        JobTitle = invoiceDto.Appointment.Client.JobTitle,
                        LastName = invoiceDto.Appointment.Client.LastName,
                        NIF = invoiceDto.Appointment.Client.NIF,
                        PhoneNumber = invoiceDto.Appointment.Client.PhoneNumber
                    },
                    DateTime = invoiceDto.Appointment.DateTime
                },
                Id = invoiceDto.Id,
                InvoiceDate = invoiceDto.InvoiceDate,
                Price = invoiceDto.Price
            };
        }

        public static InvoiceDto EntityToDto(InvoiceModel invoice)
        {
            if (invoice is null)
                return new InvoiceDto();
            return new InvoiceDto()
            {
                Appointment = new Appointment.Service.Model.AppointmentDto()
                {
                    Id = invoice.Appointment.Id,
                    AppointmentDescription = invoice.Appointment.AppointmentDescription,
                    AppointmentTypeID = invoice.Appointment.AppointmentTypeID,
                    AppointmentTypeName = invoice.Appointment.AppointmentTypeName,
                    Client = new Clientes.Service.Model.ClientDto()
                    {
                        Address = invoice.Appointment.Client.Address,
                        Email = invoice.Appointment.Client.Email,
                        FirstName = invoice.Appointment.Client.FirstName,
                        Id = invoice.Appointment.Client.Id,
                        JobTitle = invoice.Appointment.Client.JobTitle,
                        LastName = invoice.Appointment.Client.LastName,
                        NIF = invoice.Appointment.Client.NIF,
                        PhoneNumber = invoice.Appointment.Client.PhoneNumber
                    },
                    DateTime = invoice.Appointment.DateTime
                },
                Id = invoice.Id,
                InvoiceDate = invoice.InvoiceDate,
                Price = invoice.Price
            };
        }

        public static List<InvoiceModel> DtosToEntities(List<InvoiceDto> invoices)
        {
            if (invoices is null)
                return new List<InvoiceModel>();

            return new List<InvoiceModel>(invoices.Select(DtoToEntity));
        }

        public static List<InvoiceDto> EntitiesToDto(List<InvoiceModel> invoices)
        {
            if (invoices is null)
                return new List<InvoiceDto>();

            return new List<InvoiceDto>(invoices.Select(EntityToDto));
        }
    }
}
