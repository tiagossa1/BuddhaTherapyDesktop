using System;
using System.Collections.Generic;
using System.Text;

namespace TherapyManagementSystem.Domain.Entities
{
    public class Appointment : BaseEntity
    {
        public Guid ClientId { get; set; }
        public Client Client { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int AppointmentTypeId { get; set; }
        public string AppointmentTypeDescription { get; set; }
    }
}
