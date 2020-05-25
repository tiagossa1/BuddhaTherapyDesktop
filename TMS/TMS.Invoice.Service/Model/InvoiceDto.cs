using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Invoice.Service.Model
{
    public class InvoiceDto
    {
        public InvoiceDto()
        {
        }

        public InvoiceDto(Guid id, Guid appointmentId, Guid clientId, decimal price, DateTime invoiceDate)
        {
            Id = id;
            AppointmentId = appointmentId;
            ClientId = clientId;
            Price = price;
            InvoiceDate = invoiceDate;
        }
        public Guid Id { get; set; }
        public Guid AppointmentId { get; set; }
        public Guid ClientId { get; set; }
        public decimal Price { get; set; }
        public DateTime InvoiceDate { get; set; }

        public override bool Equals(object obj)
        {
            var compareTo = obj as InvoiceDto;
            if (ReferenceEquals(this, compareTo)) return true;
            if (compareTo is null) return false;

            return Id.Equals(compareTo.Id);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }
    }
}
