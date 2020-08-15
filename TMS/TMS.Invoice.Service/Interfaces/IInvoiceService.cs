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
        List<string> Create(InvoiceDto obj);

        List<string> Edit(InvoiceDto obj);

        bool Delete(Guid id);

        InvoiceDto Get(Guid id);

        List<InvoiceDto> GetAll();
    }
}
