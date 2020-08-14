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

        private void BtnImportFromSqlite_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var clientService = new ClientService(new ClientDomainService(new ClientRepository()));
                    var errorList = new Dictionary<string, List<string>>();
                    var repository = new Repository($"Data Source={openFileDialog1.FileName};Version=3;");

                    foreach (var client in repository.Get())
                    {
                        var clientDto = new ClientDto()
                        {
                            Id = Guid.NewGuid(),
                            Address = client.Localidade,
                            Email = client.Email,
                            FirstName = client.Nome,
                            LastName = client.Apelidos,
                            JobTitle = client.Profisso,
                            NIF = client.NIF,
                            PhoneNumber = string.IsNullOrEmpty(client.Telemvel) ? client.TelefoneFixo : client.Telemvel
                        };

                        var errors = clientService.Create(clientDto);

                        if (errors?.Count > 0)
                        {
                            errorList.Add($"{client.Nome} {client.Apelidos}", errors);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
