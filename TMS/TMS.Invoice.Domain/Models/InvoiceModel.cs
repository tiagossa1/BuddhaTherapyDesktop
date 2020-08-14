using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Appointment.Domain.Models;
using TMS.Client.Domain.Model;
using TMS.Invoice.Domain.Validations;

namespace TMS.Invoice.Domain.Models
{
    public class InvoiceModel : Entity
    {
        public Guid AppointmentID { get; set; }
        public Guid ClientID { get; set; }
        public decimal Price { get; set; }
        public DateTime InvoiceDate { get; set; }
        public override bool IsValid()
        {
            ValidationResult = new InvoiceModelValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
