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

            InvoiceDto invoice = new InvoiceDto()
            {
                AppointmentID = Guid.NewGuid(),
                ClientID = Guid.NewGuid(),
                Id = invoiceId,
                InvoiceDate = DateTime.Now,
                Price = decimal.One
            };

            InvoiceDto invoiceNewResult = new InvoiceDto()
            {
                AppointmentID = Guid.NewGuid(),
                ClientID = Guid.NewGuid(),
                Id = invoiceId,
                InvoiceDate = DateTime.Now,
                Price = 5.00M
            };

            // Act
            List<string> insertResult = invoiceService.Create(invoice);

            invoice.Price = 5.00M;

            List<string> updateResult = invoiceService.Edit(invoice);

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

            List<string> updateResult = InvoiceService.Edit(null);

            // Assert
            Assert.IsTrue(updateResult.Count > 0);
        }
    }
}
