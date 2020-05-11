using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TMS.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var clientsForm = new ClientsForm();

            Hide();

            clientsForm.Closed += (s, args) => Show();
            clientsForm.Show();
        }

        private void BtnAppointments_Click(object sender, EventArgs e)
        {
            var appointmentsForm = new AppointmentsForm();

            Hide();

            appointmentsForm.Closed += (s, args) => Show();
            appointmentsForm.Show();
        }

        private void btnInvoices_Click(object sender, EventArgs e)
        {
            var invoicesForm = new InvoicesForm();

            Hide();

            invoicesForm.Closed += (s, args) => Show();
            invoicesForm.Show();

        }
    }
}
