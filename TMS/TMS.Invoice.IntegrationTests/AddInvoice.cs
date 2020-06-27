using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TMS.Invoice.DI;
using TMS.Invoice.Domain.Services;
using TMS.Invoice.Service.Model;
using TMS.Invoice.Service.Service;

namespace TMS.Invoice.IntegrationTests
{
    [TestClass]
    public class AddInvoice
    {
        [TestMethod]
        public void VaiFalharDevidoAErrosDeValidacaoDeDominio()
        {
            // Arrange
            var container = BootStrapDI.Bootstrap();
            InvoiceService invoiceService = new InvoiceService(container.GetInstance<InvoiceDomainService>());
            InvoiceDto invoice = new InvoiceDto(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), decimal.One, default);

            // Act
            IList<string> result = invoiceService.Post(invoice);

            // Assert
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void VaiAdicionarComSucesso()
        {
            // Arrange
            var container = BootStrapDI.Bootstrap();
            InvoiceService invoiceService = new InvoiceService(container.GetInstance<InvoiceDomainService>());
            InvoiceDto invoice = new InvoiceDto(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), decimal.One, DateTime.Now);

            // Act
            IList<string> result = invoiceService.Post(invoice);

            // Assert
            Assert.IsTrue(result.Count == 0);
        }
    }
}