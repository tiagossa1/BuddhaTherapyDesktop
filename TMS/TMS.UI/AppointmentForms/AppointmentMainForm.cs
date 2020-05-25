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
            dataGridView1.DataSource = appointmentMapper.ToUiModelList(appointments);
        }

        private void AppointmentsForm_Load(object sender, EventArgs e)
        {
            RefreshDataSource();
        }

        private void DataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.StateChanged == DataGridViewElementStates.Selected)
            {
                btnDelete.Enabled = !btnDelete.Enabled;
                btnEdit.Enabled = !btnEdit.Enabled;
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
    }
}
