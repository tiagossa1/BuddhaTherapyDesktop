using FastMember;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMS.Invoice.Domain.Interfaces;
using TMS.Invoice.Domain.Services;
using TMS.Invoice.Repository.Repository;
using TMS.Invoice.Service.Model;
using TMS.Invoice.Service.Service;
using TMS.UI.InvoiceForms;
using TMS.UI.Mapper;
using TMS.UI.UIModels;

namespace TMS.UI
{
    public partial class InvoicesForm : Form
    {
        private readonly InvoiceService invoiceService;
        private readonly InvoiceMapper invoiceMapper;
        private List<InvoiceDto> invoices;
        public InvoicesForm()
        {
            invoiceService = new InvoiceService(new InvoiceDomainService(new InvoiceRepository()));
            invoiceMapper = new InvoiceMapper();

            InitializeComponent();
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            var createOrUpdateInvoiceForm = new CreateOrUpdateInvoiceForm(null);

            Hide();

            createOrUpdateInvoiceForm.Closed += (s, args) =>
            {
                RefreshDataSource();
                Show();
            };

            createOrUpdateInvoiceForm.Show();
        }

        private void RefreshDataSource()
        {
            invoices = invoiceService.GetAll().ToList();
            dataGridView1.DataSource = invoiceMapper.ToUiModelList(invoices);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            var invoiceIndex = dataGridView1.CurrentCell.RowIndex;

            DialogResult dialogResult = MessageBox.Show("Tem a certeza que quer eliminar este recibo?", "Confirmação", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                invoiceService.Delete(invoices[invoiceIndex].Id);
                RefreshDataSource();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            var selectedInvoice = invoices[dataGridView1.CurrentCell.RowIndex];
            var createOrUpdateInvoiceForm = new CreateOrUpdateInvoiceForm(selectedInvoice);

            Hide();

            createOrUpdateInvoiceForm.Closed += (s, args) =>
            {
                Show();
                RefreshDataSource();
            };

            createOrUpdateInvoiceForm.Show();
        }

        private void InvoicesForm_Load(object sender, EventArgs e)
        {
            RefreshDataSource();
        }

        private void DataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.StateChanged == DataGridViewElementStates.Selected)
            {
                btnDelete.Enabled = true;
                btnEdit.Enabled = true;
            }
            else if(e.StateChanged != DataGridViewElementStates.Displayed)
            {
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
            }
        }

        private void TxtFilter_TextChanged(object sender, EventArgs e)
        {
            txtFilter.Text = txtFilter.Text.Trim();

            if (!string.IsNullOrWhiteSpace(txtFilter.Text))
            {
                var selectedInvoices = invoiceMapper.ToUiModelList(invoices).FindAll(x => 
                (x.Consulta ?? string.Empty).Contains(txtFilter.Text) ||
                (x.Data.ToString() ?? string.Empty).Contains(txtFilter.Text) ||
                (x.Preco.ToString() ?? string.Empty).Contains(txtFilter.Text));

                dataGridView1.DataSource = ConvertToDataTable(selectedInvoices);
            }
            else
            {
                RefreshDataSource();
            }
        }

        private DataTable ConvertToDataTable(List<InvoiceUIModel> selectedInvoices)
        {
            DataTable table = new DataTable();
            using (var reader = ObjectReader.Create(selectedInvoices))
            {
                table.Load(reader);
            }

            return table;
        }
    }
}
