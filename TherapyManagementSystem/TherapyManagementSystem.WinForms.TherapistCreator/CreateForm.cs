using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TherapyManagementSystem.Domain.Entities;
using TherapyManagementSystem.Service.Services;
using TherapyManagementSystem.Service.Validators;

namespace TherapyManagementSystem.WinForms.TherapistCreator
{
    public partial class CreateForm : Form
    {
        private readonly BaseService<Therapist> service = new BaseService<Therapist>();
        public CreateForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Therapist therapist = new Therapist()
            {
                Id = Guid.NewGuid(),
                Email = txtEmail.Text,
                FirstName = txtNome.Text,
                LastName = txtApelido.Text,
                Password = txtPassword.Text,
                Username = txtUsername.Text
            };

            try
            {
                service.Post<TherapistValidator>(therapist);
            }
            catch (ValidationException ex)
            {
                MessageBox.Show("Erro", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
