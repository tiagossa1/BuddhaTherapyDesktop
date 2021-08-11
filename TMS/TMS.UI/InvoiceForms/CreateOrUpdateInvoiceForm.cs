using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMS.Appointment.Domain.Services;
using TMS.Appointment.Repository;
using TMS.Appointment.Service.Model;
using TMS.Appointment.Service.Service;
using TMS.Client.Domain.Services;
using TMS.Client.Repository.Repository;
using TMS.Invoice.Domain.Services;
using TMS.Invoice.Repository.Repository;
using TMS.Invoice.Service.Model;
using TMS.Invoice.Service.Service;

namespace TMS.UI.InvoiceForms
{
    public partial class CreateOrUpdateInvoiceForm : Form
    {
        private readonly InvoiceService invoiceService;
        private readonly AppointmentService appointmentService;
        private readonly ClientService clientService;
        private readonly List<AppointmentDto> appointments;

        private InvoiceDto Invoice { get; }
        public CreateOrUpdateInvoiceForm(InvoiceDto invoice)
        {
            InitializeComponent();

            Invoice = invoice;

            invoiceService = new InvoiceService(new InvoiceDomainService(new InvoiceRepository()));
            appointmentService = new AppointmentService(new AppointmentDomainService(new AppointmentRepository()));
            appointments = appointmentService.GetAll().ToList();

            clientService = new ClientService(new ClientDomainService(new ClientRepository()));
        }

        private void CreateOrUpdateInvoiceForm_Load(object sender, EventArgs e)
        {
            SetupAppointmentComboBox();

            if (Invoice != null)
            {
                cmbAppointments.SelectedIndex = invoiceService.GetAll().ToList().FindIndex(i => i.Id == Invoice.Id);
                txtPrice.Text = Invoice.Price.ToString();

                ChangeCreateLabelsToEditingLabels();
            }
        }

        private void SetupAppointmentComboBox()
        {
            var appointments = appointmentService.GetAll().Select(a =>
            {
                var client = clientService.Get(a.ClientID);
                return $"{client.FirstName} {client.LastName} | {a.DateTime}";
            }).ToArray();

            cmbAppointments.Items.AddRange(appointments);
        }

        private void BtnCreateOrEdit_Click(object sender, EventArgs e)
        {
            var selectedAppointment = appointments[cmbAppointments.SelectedIndex];

            var invoice = new InvoiceDto()
            {
                Id = Invoice != null ? Invoice.Id : Guid.NewGuid(),
                AppointmentID = selectedAppointment.Id,
                ClientID = selectedAppointment.ClientID,
                InvoiceDate = DateTime.UtcNow,
                Price = decimal.Parse(txtPrice.Text)
            };

            List<string> results;

            if (Invoice != null)
            {
                results = invoiceService.Edit(invoice).ToList();
            }
            else
            {
                results = invoiceService.Create(invoice).ToList();
            }

            if (results.Count > 0)
            {
                MessageBox.Show(string.Join(Environment.NewLine, results), "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var message = Invoice != null ? "Recibo editado com sucesso!" : "Recibo adicionado com sucesso!";

                MessageBox.Show(message, "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Close();
        }

        private void TxtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allows 0-9, backspace, and decimal
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
                return;
            }

            // checks to make sure only 1 decimal is allowed
            if (e.KeyChar == 46 && (sender as TextBox)?.Text.IndexOf(e.KeyChar) != -1)
            {
                e.Handled = true;
            }
        }

        private void ChangeCreateLabelsToEditingLabels()
        {
            Text = "Editar Recibo";
            btnCreateOrEdit.Text = "Editar";
        }
    }
}
