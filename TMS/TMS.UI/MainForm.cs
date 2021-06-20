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
using TMS.Appointment.Service.Service;
using TMS.Client.Domain.Services;
using TMS.Clientes.Repository.Repository;
using TMS.Clientes.Service.Model;
using TMS.ImportRepository;
using TMS.UI.AppointmentForms;
using TMS.UI.Mapper;
using TMS.UI.Properties;

namespace TMS.UI
{
    public partial class MainForm : Form
    {
        private string todaysAppointmentTooltipText = string.Empty;
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
            var clientService = new ClientDomainService(new ClientRepository());

            if (clientService.Count() == 0)
            {
                MessageBox.Show("Não tem clientes. Por favor, crie pelo menos um cliente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var appointmentsForm = new AppointmentMainForm();

                Hide();

                appointmentsForm.Closed += (s, args) => Show();
                appointmentsForm.Show();
            }
        }

        private void BtnInvoices_Click(object sender, EventArgs e)
        {
            var clientService = new ClientDomainService(new ClientRepository());
            var appointmentService = new AppointmentDomainService(new AppointmentRepository());

            if (clientService.Count() == 0)
            {
                MessageBox.Show("Não existem clientes. Por favor, crie pelo menos um cliente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (appointmentService.Count() == 0)
            {
                MessageBox.Show("Não existem consultas. Por favor, crie pelo menos uma consulta.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var invoicesForm = new InvoicesForm();

                Hide();

                invoicesForm.Closed += (s, args) => Show();
                invoicesForm.Show();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CheckIfThereAreAppointmentsForToday();
        }

        private void AppointmentsNotificationBadge_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(todaysAppointmentTooltipText))
                MessageBox.Show(todaysAppointmentTooltipText, "Informação", MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        private void MainForm_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                CheckIfThereAreAppointmentsForToday();
            }
        }

        private void CheckIfThereAreAppointmentsForToday()
        {
            AppointmentMapper appointmentMapper = new AppointmentMapper();

            var appointments = new AppointmentService(new AppointmentDomainService(new AppointmentRepository())).GetAll();

            var appointmentsForToday = appointmentMapper.ToUiModelList(appointments.FindAll(x => x.DateTime >= DateTime.Now));

            appointmentsNotificationBadge.Text = appointmentsForToday.Count.ToString();

            if (appointmentsForToday.Count > 0)
            {
                todaysAppointmentTooltipText = $"Consultas para hoje: {string.Join(" | ", appointmentsForToday.Select(x => x.Nome))} | {string.Join(" ", appointmentsForToday.Select(x => x.TipoDeConsulta))} | {string.Join(" ", appointmentsForToday.Select(x => x.Data))}.";
            }
        }
    }
}
