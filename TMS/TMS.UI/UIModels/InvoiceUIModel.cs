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

        public InvoiceUIModel(string appointmentName, decimal price, DateTime invoiceDate)
        {
            Consulta = appointmentName;
            //ClientFirstName = clientFirstName;
            //ClientLastName = clientLastName;
            Preco = price;
            Data = invoiceDate;
        }
        public string Consulta { get; private set; }
        //public string ClientFirstName { get; private set; }
        //public string ClientLastName { get; private set; }
        public decimal Preco { get; private set; }
        public DateTime Data { get; private set; }
    }
}
