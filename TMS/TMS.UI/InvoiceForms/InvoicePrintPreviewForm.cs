using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMS.Appointment.Domain.Services;
using TMS.Appointment.Repository;
using TMS.Client.Domain.Services;
using TMS.Clientes.Repository.Repository;
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
            var clientService = new ClientDomainService(new ClientRepository());
            var appointmentService = new AppointmentDomainService(new AppointmentRepository());

            var selectedClient = clientService.Get(invoice.ClientID);
            var selectedAppointment = appointmentService.Get(invoice.AppointmentID);

            Microsoft.Reporting.WinForms.ReportParameter[] parameters = new Microsoft.Reporting.WinForms.ReportParameter[]
            {
                new Microsoft.Reporting.WinForms.ReportParameter("ID", invoice.Id.ToString()),
                new Microsoft.Reporting.WinForms.ReportParameter("Name", $"{selectedClient.FirstName} {selectedClient.LastName}"),
                new Microsoft.Reporting.WinForms.ReportParameter("AppointmentType", selectedAppointment.AppointmentTypeName),
                new Microsoft.Reporting.WinForms.ReportParameter("AppointmentDate", selectedAppointment.DateTime.ToLocalTime().ToString("MM/dd/yyyy HH:mm")),
                new Microsoft.Reporting.WinForms.ReportParameter("Price", invoice.Price.ToString()),
                new Microsoft.Reporting.WinForms.ReportParameter("NIF", selectedClient.NIF)
            };

            //reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource() { Name = "invoice", Value = invoice });
            reportViewer1.LocalReport.ReportPath = $"{Directory.GetCurrentDirectory()}/InvoiceForms/rptInvoice.rdlc";
            reportViewer1.LocalReport.SetParameters(parameters);
            this.reportViewer1.RefreshReport();
        }
    }
}
