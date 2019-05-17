using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuddhaTherapy
{
    public partial class Form1 : Form
    {
        public Button BtnRegister
        {
            get { return btnRegister; }
            set { btnRegister = value; }
        }
        public Form1()
        {
            InitializeComponent();
            this.lbl1.Text = "Bem-vindo, " + Environment.UserName + "!";

            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-HKKVG54;Initial Catalog=buddhaDb;Integrated Security=True"))
            {
                try
                {
                    connection.Open();
                }
                catch (SqlException error)
                {
                    MessageBox.Show(error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.btnRegister.Enabled = false;
                    this.btnSignin.Enabled = false;
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm(this);
            registerForm.Show();

            if (Application.OpenForms.OfType<RegisterForm>().Count() == 1)
            {
                this.btnRegister.Enabled = false;
            }
        }
    }
}
