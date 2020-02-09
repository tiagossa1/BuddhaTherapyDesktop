using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TherapyManagementSystem.BusinessLogicLayer;
using TherapyManagementSystem.Common;
using TherapyManagementSystem.Common.Models;

namespace TherapyManagementSystem.UserCreation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnCreateUser_Click(object sender, EventArgs e)
        {
            var therapist = new Therapist()
            {
                ID = Guid.NewGuid().ToString(),
                Name = txtName.Text,
                Address = txtAddress.Text,
                Email = txtEmail.Text,
                Gender = comboGender.Text,
                MobileNumber = txtMobileNumber.Text,
                Password = BCrypt.Net.BCrypt.HashPassword(txtPassword.Text),
                Username = txtUsername.Text
            };

            TherapistValidation validator = new TherapistValidation();

            try
            {
                validator.ValidateAndThrow(therapist);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            using (SQLiteConnection dbConnection = new SQLiteConnection($"URI=file:{Constants.DatabasePath}"))
            {
                dbConnection.Open();

                const string insertTherapistQuery = "INSERT INTO Therapists(ID, Name, Gender, MobileNumber, Email, Address, Username, Password) VALUES(@id,@name,@gender,@mobileNumber,@email,@address,@username,@password)";

                using (var command = new SQLiteCommand(dbConnection))
                {
                    command.CommandText = insertTherapistQuery;
                    command.Parameters.AddWithValue("@id", therapist.ID);
                    command.Parameters.AddWithValue("@name", therapist.Name);
                    command.Parameters.AddWithValue("@gender", therapist.Gender);
                    command.Parameters.AddWithValue("@mobileNumber", therapist.MobileNumber);
                    command.Parameters.AddWithValue("@email", therapist.Email);
                    command.Parameters.AddWithValue("@address", therapist.Address);
                    command.Parameters.AddWithValue("@username", therapist.Username);
                    command.Parameters.AddWithValue("@password", therapist.Password);

                    command.ExecuteNonQuery();
                }
            }

            var dialogResult = MessageBox.Show($"Inserted {therapist.Name} successfully! Do you want to add another therapist?", "Therapist inserted", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dialogResult != DialogResult.Yes)
            {
                Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboGender.DataSource = Enum.GetValues(typeof(Constants.Gender));
        }
    }
}
