using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMS.Client.Domain.Services;
using TMS.Client.Repository.Repository;
using TMS.Clientes.Service.Model;

namespace TMS.UI.ClientForms
{
    public partial class CreateOrUpdateClientForm : Form
    {
        private ClientDto Client { get; }
        public CreateOrUpdateClientForm(ClientDto client)
        {
            Client = client;
            InitializeComponent();
        }

        private void TxtNIF_TextChanged(object sender, EventArgs e)
        {
            CheckNumericField(txtNIF);
        }

        private void TxtPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            CheckNumericField(txtPhoneNumber);
        }

        private void CheckNumericField(Guna2TextBox textBox)
        {
            if (Regex.IsMatch(textBox.Text, "[^0-9]"))
            {
                textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1);
            }
        }

        private void AddClientForm_Load(object sender, EventArgs e)
        {
            if (Client != null)
            {
                txtAddress.Text = Client.Address;
                txtEmail.Text = Client.Email;
                txtFirstName.Text = Client.FirstName;
                txtJobTitle.Text = Client.JobTitle;
                txtLastName.Text = Client.LastName;
                txtNIF.Text = Client.NIF;
                txtPhoneNumber.Text = Client.PhoneNumber;

                ChangeCreateLabelsToEditingLabels();
            }
        }

        private void ChangeCreateLabelsToEditingLabels()
        {
            Text = "Editar Cliente";
            btnCreateOrEdit.Text = "Editar";
        }

        private void BtnCreateOrEdit_Click(object sender, EventArgs e)
        {
            ClientService clientService = new ClientService(new ClientDomainService(new ClientRepository()));
            List<string> results;

            ClientDto clientDto = new ClientDto()
            {
                Id = Client != null ? Client.Id : Guid.NewGuid(),
                Address = txtAddress.Text,
                Email = txtEmail.Text,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                JobTitle = txtJobTitle.Text,
                NIF = txtNIF.Text,
                PhoneNumber = txtPhoneNumber.Text
            };

            if (Client != null)
            {
                results = clientService.Edit(clientDto).ToList();
            }
            else
            {
                results = clientService.Create(clientDto).ToList();
            }

            if (results.Count > 0)
            {
                MessageBox.Show(string.Join(Environment.NewLine, results), "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var message = Client != null ? "Client editado com sucesso!" : "Client adicionado com sucesso!";

                MessageBox.Show(message, "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }
    }
}
