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
using TMS.Client.Repository.Repository;
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
                        var telefone = SetTelefone(client);

                        var clientDto = new ClientDto()
                        {
                            Id = Guid.NewGuid(),
                            Address = client.Localidade ?? "Localidade não definida",
                            Email = client.Email ?? "Email não definido",
                            FirstName = client.Nome ?? "Nome não definido",
                            LastName = client.Apelidos ?? "Apelido não definido",
                            JobTitle = client.Profisso ?? "Profissão não definida",
                            NIF = client.NIF ?? "NIF não definido",
                            PhoneNumber = telefone
                        };

                        var errors = clientService.Create(clientDto);

                        if (errors?.Count > 0)
                        {
                            errorList.Add($"{client.Nome}{client.Apelidos}", errors);
                        }
                    }

                    if (errorList?.Count > 0)
                    {
                        MessageBox.Show($"Houve erros: {string.Join(",", errorList.Values)}.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Todos os utilizadores foram importados com sucesso.", "Sucesso",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private static string SetTelefone(AccessClientModel client)
        {
            string telefone;

            if (!string.IsNullOrWhiteSpace(client.TelefoneFixo))
            {
                telefone = client.TelefoneFixo;
            }
            else if (!string.IsNullOrWhiteSpace(client.Telemvel))
            {
                telefone = client.Telemvel;
            }
            else
            {
                telefone = "Telefone não definido.";
            }

            return telefone;
        }
    }
}
