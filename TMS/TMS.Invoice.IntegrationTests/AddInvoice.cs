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
            InvoiceDto invoice = new InvoiceDto()
            {
                AppointmentID = Guid.NewGuid(),
                ClientID = Guid.NewGuid(),
                Id = Guid.NewGuid(),
                InvoiceDate = default,
                Price = decimal.One
            };

            // Act
            List<string> result = invoiceService.Create(invoice);

            // Assert
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void VaiAdicionarComSucesso()
        {
            // Arrange
            var container = BootStrapDI.Bootstrap();
            InvoiceService invoiceService = new InvoiceService(container.GetInstance<InvoiceDomainService>());

            InvoiceDto invoice = new InvoiceDto()
            {
                AppointmentID = Guid.NewGuid(),
                ClientID = Guid.NewGuid(),
                Id = Guid.NewGuid(),
                InvoiceDate = DateTime.Now,
                Price = decimal.One
            };

            // Act
            List<string> result = invoiceService.Create(invoice);

            // Assert
            Assert.IsTrue(result.Count == 0);
        }
    }
}