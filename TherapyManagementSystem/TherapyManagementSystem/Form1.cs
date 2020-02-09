using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Configuration;
using TherapyManagementSystem.Common;

namespace TherapyManagementSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            VerifyPrerequesites();
        }

        private void VerifyPrerequesites()
        {
            Directory.CreateDirectory("C:/TMS");

            if (!File.Exists(Constants.AdminPasswordPath) || new FileInfo(Constants.AdminPasswordPath).Length == 0)
            {
                var password = ConfigurationManager.AppSettings["adminPassword"];

                if (string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("You must provide a password to use this software.", "No input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }

                using (StreamWriter sw = File.CreateText(Constants.AdminPasswordPath))
                {
                    sw.WriteLine(BCrypt.Net.BCrypt.HashPassword(password));
                }
            }

            if (!File.Exists(Constants.DatabasePath))
            {
                SQLiteConnection.CreateFile(Constants.DatabasePath);

                using (SQLiteConnection dbConnection = new SQLiteConnection($"URI=file:{Constants.DatabasePath}"))
                {
                    dbConnection.Open();

                    const string billingTableInsertQuery = @"CREATE TABLE IF NOT EXISTS Billings (ID TEXT NOT NULL,
                                                        AppointmentID   TEXT NOT NULL,
	                                                    Price           NUMERIC NOT NULL,
	                                                    Discounted      INTEGER NOT NULL,
	                                                    DiscountPercentage  NUMERIC,
	                                                    PRIMARY KEY(ID));";

                    const string therapistTableInsertQuery = @"CREATE TABLE IF NOT EXISTS Therapists (
                                                        ID              TEXT NOT NULL,
	                                                    Name            TEXT NOT NULL,
	                                                    Gender          TEXT NOT NULL,
	                                                    MobileNumber    TEXT NOT NULL,
	                                                    Email           TEXT,
	                                                    Address         TEXT,
	                                                    Username        TEXT NOT NULL,
	                                                    Password        TEXT NOT NULL,
	                                                    PRIMARY KEY(ID));";

                    const string clientTableInsertQuery = @"CREATE TABLE IF NOT EXISTS Clients (
                                                        ID              TEXT NOT NULL,
	                                                    Name            TEXT NOT NULL,
	                                                    Gender          TEXT NOT NULL,
	                                                    MobileNumber    TEXT NOT NULL,
	                                                    Email           TEXT,
	                                                    Address         TEXT,
	                                                    CivilStatus     TEXT,
	                                                    DateOfBirth     TEXT,
	                                                    NIF             TEXT,
	                                                    Occupation      INTEGER NOT NULL,
	                                                    Observations    INTEGER,
	                                                    TherapistID     TEXT NOT NULL,
	                                                    PRIMARY KEY(ID)); ";

                    const string appointmentTableInsertQuery = @"CREATE TABLE IF NOT EXISTS Appointments (
                                                        ID              TEXT NOT NULL,
	                                                    AppointmentType TEXT NOT NULL,
	                                                    ClientID        TEXT NOT NULL,
	                                                    TherapistID     TEXT NOT NULL,
	                                                    AppointmentDate TEXT NOT NULL,
	                                                    PRIMARY KEY(ID)); ";

                    using (var command = new SQLiteCommand(dbConnection))
                    {
                        command.CommandText = billingTableInsertQuery;
                        command.ExecuteNonQuery();

                        command.CommandText = therapistTableInsertQuery;
                        command.ExecuteNonQuery();

                        command.CommandText = clientTableInsertQuery;
                        command.ExecuteNonQuery();

                        command.CommandText = appointmentTableInsertQuery;
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
