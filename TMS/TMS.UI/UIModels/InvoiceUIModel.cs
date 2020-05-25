using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.UI.UIModels
{
    public class InvoiceUIModel
    {
        public InvoiceUIModel()
        {
        }

        public InvoiceUIModel(string appointmentName, string clientFirstName, string clientLastName, decimal price, DateTime invoiceDate)
        {
            AppointmentName = appointmentName;
            ClientFirstName = clientFirstName;
            ClientLastName = clientLastName;
            Price = price;
            InvoiceDate = invoiceDate;
        }
        public string AppointmentName { get; private set; }
        public string ClientFirstName { get; private set; }
        public string ClientLastName { get; private set; }
        public decimal Price { get; private set; }
        public DateTime InvoiceDate { get; private set; }
    }
}
