using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Invoice.Service.Model;

namespace TMS.Invoice.Service.Interfaces
{
    public interface IInvoiceService
    {
        IList<string> Post(InvoiceDto obj);

        IList<string> Put(InvoiceDto obj);

        bool Delete(Guid id);

        InvoiceDto Get(Guid id);

        IList<InvoiceDto> GetAll();
    }
}
