using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Invoice.Domain.Models;

namespace TMS.Invoice.Domain.Interfaces
{
    public interface IInvoiceRepository
    {
        bool Post(InvoiceModel obj);

        bool Put(InvoiceModel obj);

        bool Delete(Guid id);

        InvoiceModel Get(Guid id);

        IList<InvoiceModel> GetAll();
    }
}
