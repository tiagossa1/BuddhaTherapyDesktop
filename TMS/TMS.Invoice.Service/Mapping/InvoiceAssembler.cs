using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            return new InvoiceModel(invoiceDto.Id, invoiceDto.AppointmentId, invoiceDto.ClientId, invoiceDto.Price, invoiceDto.InvoiceDate);
        }

        public static InvoiceDto EntityToDto(InvoiceModel invoice)
        {
            if (invoice is null)
                return new InvoiceDto();
            return new InvoiceDto(invoice.Id, invoice.AppointmentId, invoice.ClientId, invoice.Price, invoice.InvoiceDate);
        }

        public static List<InvoiceModel> DtosToEntities(List<InvoiceDto> invoices)
        {
            if (invoices is null)
                return new List<InvoiceModel>();
            return new List<InvoiceModel>(invoices.Select(x => new InvoiceModel(x.Id, x.ClientId, x.AppointmentId, x.Price, x.InvoiceDate)));
        }

        public static List<InvoiceDto> EntitiesToDto(List<InvoiceModel> cliente)
        {
            if (cliente is null)
                return new List<InvoiceDto>();

            return new List<InvoiceDto>(cliente.Select(x => new InvoiceDto(x.Id, x.ClientId, x.AppointmentId, x.Price, x.InvoiceDate)));
        }
    }
}
