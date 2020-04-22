using System;
using System.Collections.Generic;
using System.Text;

namespace TherapyManagementSystem.Domain.Entities
{
    public class Invoice : BaseEntity
    {
        public Guid AppointmentId { get; set; }
        public Guid ClientId { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
    }
}
