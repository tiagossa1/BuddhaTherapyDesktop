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
    public class GetInvoices
    {
        [TestMethod]
        public void VaiRetornarUmInvoiceVazio()
        {
            // Arrange
            var container = BootStrapDI.Bootstrap();

            InvoiceService invoiceService = new InvoiceService(container.GetInstance<InvoiceDomainService>());

            // Act
            InvoiceDto invoice = invoiceService.Get(Guid.NewGuid());

            // Assert
            Assert.IsTrue(invoice.Equals(new InvoiceDto()));
        }

        [TestMethod]
        public void VaiRetornarUmInvoice()
        {
            // Arrange
            var container = BootStrapDI.Bootstrap();

            InvoiceService InvoiceService = new InvoiceService(container.GetInstance<InvoiceDomainService>());

            Guid invoiceId = Guid.NewGuid();

            // Act
            InvoiceDto invoice = new InvoiceDto(invoiceId, Guid.NewGuid(), decimal.One, DateTime.Now);

            IList<string> postResult = InvoiceService.Post(invoice);

            InvoiceDto getResult = InvoiceService.Get(invoiceId);

            // Assert
            Assert.IsTrue(postResult.Count == 0);
            Assert.IsTrue(getResult.Equals(invoice));
        }

        [TestMethod]
        public void VaiRetornarTodosOsInvoices()
        {
            // Arrange
            var container = BootStrapDI.Bootstrap();

            InvoiceService InvoiceService = new InvoiceService(container.GetInstance<InvoiceDomainService>());

            Guid invoiceId = Guid.NewGuid();

            // Act
            InvoiceDto invoice = new InvoiceDto(invoiceId, Guid.NewGuid(), decimal.One, DateTime.Now);

            IList<string> postResult = InvoiceService.Post(invoice);

            List<InvoiceDto> getAllResult = InvoiceService.GetAll().ToList();

            // Assert
            Assert.IsTrue(postResult.Count == 0);
            Assert.IsTrue(getAllResult.Contains(invoice));
        }
    }
}
