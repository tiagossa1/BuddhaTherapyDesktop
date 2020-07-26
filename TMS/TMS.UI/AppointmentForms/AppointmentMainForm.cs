using FastMember;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMS.Appointment.Domain.Interfaces;
using TMS.Appointment.Domain.Services;
using TMS.Appointment.Repository;
using TMS.Appointment.Service.Model;
using TMS.Appointment.Service.Service;
using TMS.UI.Mapper;
using TMS.UI.UIModels;

namespace TMS.UI.AppointmentForms
{
    public partial class AppointmentMainForm : Form
    {
        private readonly AppointmentService appointmentService;
        private List<AppointmentDto> appointments = new List<AppointmentDto>();
        private readonly AppointmentMapper appointmentMapper;

        public AppointmentMainForm()
        {
            appointmentService = new AppointmentService(new AppointmentDomainService(new AppointmentRepository()));
            appointmentMapper = new AppointmentMapper();

            InitializeComponent();
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            var createOrUpdateAppointmentForm = new CreateOrUpdateAppointmentForm(null);

            Hide();

            createOrUpdateAppointmentForm.Closed += (s, args) =>
            {
                RefreshDataSource();
                Show();
            };

            createOrUpdateAppointmentForm.Show();
        }

        private void RefreshDataSource()
        {
            appointments = appointmentService.GetAll().ToList();
            dataGridView1.DataSource = ConvertToDataTable(appointmentMapper.ToUiModelList(appointments));
        }

        private DataTable ConvertToDataTable(List<AppointmentUIModel> selectedAppointments)
        {
            DataTable table = new DataTable();
            using (var reader = ObjectReader.Create(selectedAppointments))
            {
                table.Load(reader);
            }

            return table;
        }

        private void AppointmentsForm_Load(object sender, EventArgs e)
        {
            RefreshDataSource();
        }

        private void DataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.StateChanged == DataGridViewElementStates.Selected)
            {
                btnDelete.Enabled = true;
                btnEdit.Enabled = true;
            }
            else if (e.StateChanged != DataGridViewElementStates.Displayed)
            {
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            var appointmentIndex = dataGridView1.CurrentCell.RowIndex;

            DialogResult dialogResult = MessageBox.Show("Tem a certeza que quer eliminar esta consulta?", "Confirmação", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                appointmentService.Delete(appointments[appointmentIndex].Id);
                RefreshDataSource();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            var selectedAppointment = appointments[dataGridView1.CurrentCell.RowIndex];
            var createOrUpdateAppointmentForm = new CreateOrUpdateAppointmentForm(selectedAppointment);

            Hide();

            createOrUpdateAppointmentForm.Closed += (s, args) =>
            {
                Show();
                RefreshDataSource();
            };

            createOrUpdateAppointmentForm.Show();
        }

        private void TxtFilter_TextChanged(object sender, EventArgs e)
        {
            txtFilter.Text = txtFilter.Text.Trim();

            if (!string.IsNullOrWhiteSpace(txtFilter.Text))
            {
                var selectedAppointments = appointmentMapper.ToUiModelList(appointments).FindAll(x =>
                (x.TipoDeConsulta ?? string.Empty).Contains(txtFilter.Text) ||
                (x.Data.ToString() ?? string.Empty).Contains(txtFilter.Text) ||
                (x.Descricao ?? string.Empty).Contains(txtFilter.Text) ||
                (x.Nome ?? string.Empty).Contains(txtFilter.Text));

                dataGridView1.DataSource = ConvertToDataTable(selectedAppointments);
            }
            else
            {
                RefreshDataSource();
            }
        }
    }
}
