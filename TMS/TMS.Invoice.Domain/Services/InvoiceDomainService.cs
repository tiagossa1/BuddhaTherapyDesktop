using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Invoice.Domain.Interfaces;
using TMS.Invoice.Domain.Models;

namespace TMS.Invoice.Domain.Services
{
    public class InvoiceDomainService : IInvoiceDomainService
    {
        private readonly IInvoiceRepository invoiceRepository;

        public InvoiceDomainService(IInvoiceRepository invoiceRepository)
        {
            this.invoiceRepository = invoiceRepository;
        }

        public bool Delete(Guid id)
        {
            return invoiceRepository.Delete(id);
        }

        public InvoiceModel Get(Guid id)
        {
            return invoiceRepository.Get(id);
        }

        public List<InvoiceModel> GetAll()
        {
            return invoiceRepository.GetAll();
        }

        public List<string> Post(InvoiceModel obj)
        {
            if (!obj.IsValid())
                return NotifyValidationErrors(obj);

            bool result = invoiceRepository.Post(obj);

            return result ? new List<string>() : new List<string>() { "Error inserting on the database" };
        }

        public List<string> Put(InvoiceModel obj)
        {
            if (!obj.IsValid())
                return NotifyValidationErrors(obj);

            bool result = invoiceRepository.Put(obj);

            return result ? new List<string>() : new List<string>() { "Error updating on the database" };
        }

        private List<string> NotifyValidationErrors(InvoiceModel invoiceModel)
        {
            return invoiceModel.ValidationResult.Errors.Select(x => x.ErrorMessage).ToList();
        }
    }
}
