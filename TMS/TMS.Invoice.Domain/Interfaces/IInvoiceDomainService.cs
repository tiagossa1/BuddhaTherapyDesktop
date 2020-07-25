using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Invoice.Domain.Models;

namespace TMS.Invoice.Domain.Interfaces
{
    public interface IInvoiceDomainService
    {
        List<string> Post(InvoiceModel obj);

        List<string> Put(InvoiceModel obj);

        bool Delete(Guid id);
        bool DeleteByClientID(Guid id);

        InvoiceModel Get(Guid id);

        List<InvoiceModel> GetAll();
    }
}
