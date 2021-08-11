using FastMember;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TMS.Client.Domain.Services;
using TMS.Client.Repository.Repository;
using TMS.Clientes.Service.Model;
using TMS.UI.ClientForms;
using TMS.UI.Mapper;
using TMS.UI.UIModels;

namespace TMS.UI
{
    public partial class ClientsForm : Form
    {
        private readonly ClientService clientService;
        private readonly ClientMapper clientMapper;
        private List<ClientDto> clients = new List<ClientDto>();

        public ClientsForm()
        {
            clientService = new ClientService(new ClientDomainService(new ClientRepository()));
            clientMapper = new ClientMapper();

            InitializeComponent();
        }

        private void ClientsForm_Load(object sender, EventArgs e)
        {
            RefreshDataSource();
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            var addClientForm = new CreateOrUpdateClientForm(null);

            Hide();

            addClientForm.Closed += (s, args) =>
            {
                RefreshDataSource();
                Show();
            };

            addClientForm.Show();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            var clientIndex = dataGridView1.CurrentCell.RowIndex;

            DialogResult dialogResult = MessageBox.Show("Ao eliminar este cliente, todas as receitas e consultas são eliminadas. Continuar?", "Confirmação", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                clientService.Delete(clients[clientIndex].Id);
                RefreshDataSource();
            }
        }

        private void RefreshDataSource()
        {
            clients = clientService.GetAll().ToList();
            dataGridView1.DataSource = ConvertToDataTable(clientMapper.ToUiModelList(clients));
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            var selectedClient = clients[dataGridView1.CurrentCell.RowIndex];
            var addClientForm = new CreateOrUpdateClientForm(selectedClient);

            Hide();

            addClientForm.Closed += (s, args) =>
            {
                RefreshDataSource();
                Show();
            };

            addClientForm.Show();
        }

        private void TxtFilter_TextChanged(object sender, EventArgs e)
        {
            txtFilter.Text = txtFilter.Text.Trim();

            if (!string.IsNullOrWhiteSpace(txtFilter.Text))
            {
                var selectedClients = clientMapper.ToUiModelList(clients).FindAll(x =>
                (x.Contacto.ToString()).Contains(txtFilter.Text) ||
                (x.Email ?? string.Empty).Contains(txtFilter.Text) ||
                (x.Endereco ?? string.Empty).Contains(txtFilter.Text) ||
                (x.NIF.ToString()).Contains(txtFilter.Text) ||
                (x.Nome ?? string.Empty).Contains(txtFilter.Text) ||
                (x.Profissao ?? string.Empty).Contains(txtFilter.Text) ||
                (x.Sobrenome ?? string.Empty).Contains(txtFilter.Text));

                dataGridView1.DataSource = ConvertToDataTable(selectedClients);
            }
            else
            {
                RefreshDataSource();
            }
        }

        private DataTable ConvertToDataTable(List<ClientUIModel> selectedClients)
        {
            var table = new DataTable();
            using (var reader = ObjectReader.Create(selectedClients))
            {
                table.Load(reader);
            }

            return table;
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
    }
}
