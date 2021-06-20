using FastMember;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMS.Client.Domain.Interfaces;
using TMS.Client.Domain.Services;
using TMS.Clientes.Repository.Repository;
using TMS.Clientes.Service.Model;
using TMS.Core;
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
            var nifSelected = dataGridView1.CurrentRow.Cells[5].Value.ToString();

            DialogResult dialogResult = MessageBox.Show("Ao eliminar este cliente, todas as receitas e consultas são eliminadas. Continuar?", "Confirmação", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                var clientSelected = clients.Find(x => x.NIF == nifSelected);
                clientService.Delete(clientSelected.Id);
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
            var nifSelected = dataGridView1.CurrentRow.Cells[5].Value.ToString();

            var selectedClient = clients.Find(x => string.Equals(x.NIF, nifSelected, StringComparison.InvariantCulture));
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
                (x.Contacto ?? string.Empty).ContainsIgnoreCase(txtFilter.Text) ||
                (x.Email ?? string.Empty).ContainsIgnoreCase(txtFilter.Text) ||
                (x.Endereco ?? string.Empty).ContainsIgnoreCase(txtFilter.Text) ||
                (x.NIF ?? string.Empty).ContainsIgnoreCase(txtFilter.Text) ||
                (x.Nome ?? string.Empty).ContainsIgnoreCase(txtFilter.Text) ||
                (x.Profissao ?? string.Empty).ContainsIgnoreCase(txtFilter.Text) ||
                (x.Sobrenome ?? string.Empty).ContainsIgnoreCase(txtFilter.Text));

                dataGridView1.DataSource = ConvertToDataTable(selectedClients);
            }
            else
            {
                RefreshDataSource();
            }
        }

        private DataTable ConvertToDataTable(List<ClientUIModel> selectedClients)
        {
            DataTable table = new DataTable();
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
