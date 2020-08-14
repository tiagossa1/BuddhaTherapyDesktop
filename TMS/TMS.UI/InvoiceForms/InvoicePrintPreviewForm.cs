using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMS.Invoice.Service.Model;

namespace TMS.UI.InvoiceForms
{
    public partial class InvoicePrintPreviewForm : Form
    {
        private readonly InvoiceDto invoice;
        public InvoicePrintPreviewForm(InvoiceDto invoice)
        {
            this.invoice = invoice;

            InitializeComponent();
        }

        private void InvoicePrintPreviewForm_Load(object sender, EventArgs e)
        {
            Microsoft.Reporting.WinForms.ReportParameter[] parameters = new Microsoft.Reporting.WinForms.ReportParameter[]
            {
                new Microsoft.Reporting.WinForms.ReportParameter("ID", invoice.Id.ToString()),
                new Microsoft.Reporting.WinForms.ReportParameter("Name", ""),
                new Microsoft.Reporting.WinForms.ReportParameter("AppointmentType", ""),
                new Microsoft.Reporting.WinForms.ReportParameter("AppointmentDate", ""),
                new Microsoft.Reporting.WinForms.ReportParameter("Price", invoice.Price.ToString()),
                new Microsoft.Reporting.WinForms.ReportParameter("NIF", "")
            };

            reportViewer1.LocalReport.SetParameters(parameters);
            this.reportViewer1.RefreshReport();
        }
    }
}
