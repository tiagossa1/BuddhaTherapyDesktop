using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TherapyManagementSystem.Domain.Entities;
using TherapyManagementSystem.Service.Services;
using TherapyManagementSystem.UI;

namespace TherapyManagementSystem.WinForms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
                MessageBox.Show("O campo Username está vazio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (string.IsNullOrWhiteSpace(txtPassword.Text))
                MessageBox.Show("O campo Password está vazio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Login login = new Login()
            {
                Username = txtUsername.Text,
                Password = txtPassword.Text
            };

            var loginService = new LoginService(login);

            if (loginService.VerifyLoginCredentials())
            {
                Hide();

                Form1 form = new Form1();
                form.Show();
            }
        }
    }
}
