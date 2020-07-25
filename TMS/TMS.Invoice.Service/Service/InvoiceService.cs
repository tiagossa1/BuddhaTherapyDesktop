using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Invoice.Domain.Interfaces;
using TMS.Invoice.Service.Interfaces;
using TMS.Invoice.Service.Mapping;
using TMS.Invoice.Service.Model;

namespace TMS.Invoice.Service.Service
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceDomainService invoiceDomainService;

        public InvoiceService(IInvoiceDomainService invoiceDomainService)
        {
            this.invoiceDomainService = invoiceDomainService;
        }

        public bool Delete(Guid id)
        {
            return invoiceDomainService.Delete(id);
        }

        public InvoiceDto Get(Guid id)
        {
            return InvoiceAssembler.EntityToDto(invoiceDomainService.Get(id));
        }

        public List<InvoiceDto> GetAll()
        {
            return InvoiceAssembler.EntitiesToDto(invoiceDomainService.GetAll().ToList());
        }

        public List<string> Post(InvoiceDto obj)
        {
            return invoiceDomainService.Post(InvoiceAssembler.DtoToEntity(obj));
        }

        public List<string> Put(InvoiceDto obj)
        {
            return invoiceDomainService.Put(InvoiceAssembler.DtoToEntity(obj));
        }
    }
}
