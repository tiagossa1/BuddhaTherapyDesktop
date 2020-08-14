using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using TMS.Appointment.Domain.Services;
using TMS.Appointment.Repository;
using TMS.Appointment.Service.Model;
using TMS.Appointment.Service.Service;
using TMS.Client.Domain.Services;
using TMS.Clientes.Repository.Repository;
using TMS.Clientes.Service.Model;

namespace TMS.UI
{
    public partial class CreateOrUpdateAppointmentForm : Form
    {
        private readonly ClientService clientService;
        private readonly AppointmentService appointmentService;
        public AppointmentDto Appointment { get; }
        public CreateOrUpdateAppointmentForm(AppointmentDto appointment)
        {
            clientService = new ClientService(new ClientDomainService(new ClientRepository()));
            appointmentService = new AppointmentService(new AppointmentDomainService(new AppointmentRepository()));

            Appointment = appointment;

            InitializeComponent();
        }

        private void CreateOrUpdateAppointmentForm_Load(object sender, EventArgs e)
        {
            SetupClientComboBox();
            SetupAppointmentTypeComboBox();

            if (Appointment != null)
            {
                cmbClient.SelectedValue = Appointment.ClientID;
                cmbAppointmentType.SelectedIndex = cmbAppointmentType.FindStringExact(Enum.GetName(typeof(CoreEnums.AppointmentType), Appointment.AppointmentTypeID));

                datePicker.Value = Appointment.DateTime;
                timePicker.Value = Appointment.DateTime;

                ChangeCreateLabelsToEditingLabels();
            }

            datePicker.Value = DateTime.Now;
            timePicker.Value = DateTime.Now;
            //timePicker.ShowUpDown = true;
        }

        private void SetupAppointmentTypeComboBox()
        {
            cmbAppointmentType.DataSource = Enum.GetValues(typeof(CoreEnums.AppointmentType)).Cast<CoreEnums.AppointmentType>().OrderBy(x => x).ToList();
        }

        private void SetupClientComboBox()
        {
            cmbClient.DataSource = clientService.GetAll();
            cmbClient.DisplayMember = "FirstName";
            cmbClient.ValueMember = "ID";
        }

        private void CmbClient_Format(object sender, ListControlConvertEventArgs e)
        {
            string firstName = ((ClientDto)e.ListItem).FirstName;
            string lastName = ((ClientDto)e.ListItem).LastName;

            e.Value = $"{firstName} {lastName}";
        }

        private void ChangeCreateLabelsToEditingLabels()
        {
            Text = "Editar Consulta";
            btnCreateOrEdit.Text = "Editar";
        }

        private void BtnCreateOrEdit_Click(object sender, EventArgs e)
        {
            List<string> results;

            AppointmentDto appointment = new AppointmentDto()
            {
                Id = Appointment != null ? Appointment.Id : Guid.NewGuid(),
                DateTime = datePicker.Value.Date + timePicker.Value.TimeOfDay,
                ClientID = ((ClientDto)cmbClient.SelectedItem).Id,
                AppointmentTypeID = (int)(CoreEnums.AppointmentType)cmbAppointmentType.SelectedItem,
                AppointmentTypeName = ((CoreEnums.AppointmentType)cmbAppointmentType.SelectedItem).ToString(),
                AppointmentDescription = txtDescription.Text
            };

            if (Appointment != null)
            {
                results = appointmentService.Edit(appointment).ToList();
            }
            else
            {
                results = appointmentService.Create(appointment).ToList();
            }

            if (results.Count > 0)
            {
                MessageBox.Show(string.Join(Environment.NewLine, results), "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var message = Appointment != null ? "Consulta editada com sucesso!" : "Consulta criada com sucesso!";

                MessageBox.Show(message, "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }
    }
}
