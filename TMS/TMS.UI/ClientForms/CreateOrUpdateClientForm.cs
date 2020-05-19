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
using TMS.Clientes.Repository.Repository;
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

        private void BtnCreateOrEdit_Click(object sender, EventArgs e)
        {
            ClientService clientService = new ClientService(new ClientDomainService(new ClientRepository()));
            List<string> results;

            ClientDto clientDto = new ClientDto()
            {
                Id = Client != null ? Client.Id : Guid.NewGuid(),
                Address = txtAddress.Text,
                Email = txtEmail.Text,
                FirstName = txtFirstname.Text,
                LastName = txtLastName.Text,
                JobTitle = txtJobTitle.Text,
                NIF = int.Parse(txtNIF.Text),
                PhoneNumber = int.Parse(txtPhoneNumber.Text)
            };

            if (Client != null)
            {
                results = clientService.Put(clientDto).ToList();
            }
            else
            {
                results = clientService.Post(clientDto).ToList();
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

        private void TxtNIF_TextChanged(object sender, EventArgs e)
        {
            CheckNumericField(txtNIF);
        }

        private void TxtPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            CheckNumericField(txtPhoneNumber);
        }

        private void CheckNumericField(TextBox textBox)
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
                txtFirstname.Text = Client.FirstName;
                txtJobTitle.Text = Client.JobTitle;
                txtLastName.Text = Client.LastName;
                txtNIF.Text = Client.NIF.ToString();
                txtPhoneNumber.Text = Client.PhoneNumber.ToString();

                ChangeCreateLabelsToEditingLabels();
            }
        }

        private void ChangeCreateLabelsToEditingLabels()
        {
            Text = "Editar Cliente";
            btnCreateOrEdit.Text = "Editar";
        }
    }
}
