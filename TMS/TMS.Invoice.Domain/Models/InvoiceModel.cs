using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Invoice.Domain.Validations;

namespace TMS.Invoice.Domain.Models
{
    public class InvoiceModel : Entity
    {
        public InvoiceModel()
        {
        }

        public InvoiceModel(Guid id, Guid clientId, decimal price, DateTime invoiceDate)
        {
            Id = id;
            ClientId = clientId;
            Price = price;
            InvoiceDate = invoiceDate;
        }
        public Guid AppointmentId { get; private set; }
        public Guid ClientId { get; private set; }
        public decimal Price { get; private set; }
        public DateTime InvoiceDate { get; private set; }
        public override bool IsValid()
        {
            ValidationResult = new InvoiceModelValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
