using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Invoice.DI;
using TMS.Invoice.Domain.Services;
using TMS.Invoice.Service.Model;
using TMS.Invoice.Service.Service;

namespace TMS.Invoice.IntegrationTests
{
    [TestClass]
    public class UpdateInvoice
    {
        [TestMethod]
        public void VaiAtualizarComSucesso()
        {
            // Arrange
            var container = BootStrapDI.Bootstrap();

            InvoiceService invoiceService = new InvoiceService(container.GetInstance<InvoiceDomainService>());

            Guid invoiceId = Guid.NewGuid();

            InvoiceDto invoice = new InvoiceDto(invoiceId, Guid.NewGuid(), decimal.One, DateTime.Now);

            InvoiceDto invoiceNewResult = new InvoiceDto(invoiceId, Guid.NewGuid(), 5.00M, DateTime.Now);

            // Act
            IList<string> insertResult = invoiceService.Post(invoice);

            invoice.Price = 5.00M;

            IList<string> updateResult = invoiceService.Put(invoice);

            InvoiceDto getResult = invoiceService.Get(invoiceId);

            // Assert
            Assert.IsTrue(insertResult.Count == 0);
            Assert.IsTrue(updateResult.Count == 0);
            Assert.IsTrue(getResult.Equals(invoiceNewResult));
        }

        [TestMethod]
        public void NãoAtualizaComValorNull()
        {
            // Arrange
            var container = BootStrapDI.Bootstrap();

            InvoiceService InvoiceService = new InvoiceService(container.GetInstance<InvoiceDomainService>());

            IList<string> updateResult = InvoiceService.Put(null);

            // Assert
            Assert.IsTrue(updateResult.Count > 0);
        }
    }
}
