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
                AppointmentID = invoiceDto.AppointmentID,
                ClientID = invoiceDto.ClientID,
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
                AppointmentID = invoice.AppointmentID,
                ClientID = invoice.ClientID,
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
