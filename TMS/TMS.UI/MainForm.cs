using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMS.Clientes.Service.Model;
using TMS.UI.AppointmentForms;
using TMS.UI.Properties;

namespace TMS.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void BtnClients_Click(object sender, EventArgs e)
        {
            var clientsForm = new ClientsForm();

            Hide();

            clientsForm.Closed += (s, args) => Show();
            clientsForm.Show();
        }

        private void BtnAppointments_Click(object sender, EventArgs e)
        {
            var appointmentsForm = new AppointmentMainForm();

            Hide();

            appointmentsForm.Closed += (s, args) => Show();
            appointmentsForm.Show();
        }

        private void BtnInvoices_Click(object sender, EventArgs e)
        {
            var invoicesForm = new InvoicesForm();

            Hide();

            invoicesForm.Closed += (s, args) => Show();
            invoicesForm.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void BtnClients_MouseEnter(object sender, EventArgs e)
        {
            btnClients.BackgroundImage = new Bitmap(Resources.customers_hover);
        }

        private void BtnClients_MouseLeave(object sender, EventArgs e)
        {
            btnClients.BackgroundImage = new Bitmap(Resources.customers);
        }

        private void BtnAppointments_MouseEnter(object sender, EventArgs e)
        {
            btnAppointments.BackgroundImage = new Bitmap(Resources.meeting_hover);
        }

        private void BtnAppointments_MouseLeave(object sender, EventArgs e)
        {
            btnAppointments.BackgroundImage = new Bitmap(Resources.meeting);
        }

        private void BtnInvoices_MouseEnter(object sender, EventArgs e)
        {
            btnInvoices.BackgroundImage = new Bitmap(Resources.bill_hover);
        }

        private void BtnInvoices_MouseLeave(object sender, EventArgs e)
        {
            btnInvoices.BackgroundImage = new Bitmap(Resources.bill);
        }
    }
}
