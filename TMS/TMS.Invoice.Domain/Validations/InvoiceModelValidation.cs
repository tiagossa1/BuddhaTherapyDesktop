using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Invoice.Domain.Models;

namespace TMS.Invoice.Domain.Validations
{
    public class InvoiceModelValidation : InvoiceValidation<InvoiceModel>
    {
        public InvoiceModelValidation()
        {
            ValidateInvoiceDate();
            ValidatePrice();
        }
    }
}
