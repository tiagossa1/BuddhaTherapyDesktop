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

namespace TMS.UI
{
    public partial class InvoicesForm : Form
    {
        private readonly InvoiceService invoiceService;
        private List<InvoiceDto> invoices;
        public InvoicesForm()
        {
            InitializeComponent();

            invoiceService = new InvoiceService(new InvoiceDomainService(new InvoiceRepository()));
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            var createOrUpdateInvoice = new CreateOrUpdateInvoiceForm(null);

            Hide();

            createOrUpdateInvoice.Closed += (s, args) =>
            {
                RefreshDataSource();
                Show();
            };

            createOrUpdateInvoice.Show();
        }

        private void RefreshDataSource()
        {
            invoices = invoiceService.GetAll().ToList();
            dataGridView1.DataSource = invoices;
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
                btnDelete.Enabled = !btnDelete.Enabled;
                btnEdit.Enabled = !btnEdit.Enabled;
            }
        }
    }
}
