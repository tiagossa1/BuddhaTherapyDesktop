using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuddhaTherapy
{
    public partial class RegisterForm : Form
    {
        private readonly Form1 _form1;
        public RegisterForm(Form1 form1)
        {
            _form1 = form1;
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.txtPassword.UseSystemPasswordChar = this.txtPassword.UseSystemPasswordChar == true ? false : true;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-HKKVG54;Initial Catalog=buddhaDb;Integrated Security=True"))
            {
                try
                {
                    this.btnSave.Enabled = false;
                    this.txtName.Enabled = false;
                    this.txtPassword.Enabled = false;
                    this.txtUsername.Enabled = false;
                    this.comboGender.Enabled = false;
                    this.btnShowPassword.Enabled = false;

                    string cmdText = "INSERT INTO dbo.therapist(id, name, username, password, gender, admin) VALUES(@id, @name, @username, @password, @gender, @admin)";
                    SqlCommand cmd = new SqlCommand(cmdText, connection);
                    cmd.Parameters.AddWithValue("@id", Guid.NewGuid().ToString());
                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@password", EncryptPassword.MD5Hash(txtPassword.Text));
                    cmd.Parameters.AddWithValue("@gender", comboGender.Text);
                    cmd.Parameters.AddWithValue("@admin", false);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Terapeuta registada com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (SqlException error)
                {
                    MessageBox.Show(error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void RegisterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _form1.BtnRegister.Enabled = true;
        }
    }
}
