using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TMS.Invoice.Domain.Interfaces;
using TMS.Invoice.Domain.Models;
using TMS.Invoice.Domain.Services;

namespace TMS.Invoice.Domain.Tests
{
    [TestClass]
    public class InvoiceDomainServiceTests
    {
        [TestMethod]
        public void Post_VaiFalharDevidoAErrosDeValidacaoDeDominio()
        {
            // Arrange
            var invoiceRepository = new Mock<IInvoiceRepository>();

            InvoiceDomainService invoiceDomainService = new InvoiceDomainService(invoiceRepository.Object);

            InvoiceModel invoice = new InvoiceModel()
            {
                AppointmentID = Guid.NewGuid(),
                ClientID = Guid.NewGuid(),
                Id = Guid.NewGuid(),
                InvoiceDate = default,
                Price = 5
            };

            // Act
            List<string> result = invoiceDomainService.Post(invoice);

            // Assert
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void Post_VaiFalharNoInsertNaDb()
        {
            // Arrange
            var invoiceRepository = new Mock<IInvoiceRepository>();

            invoiceRepository.Setup(x => x.Post(It.IsAny<InvoiceModel>())).Returns(false);

            InvoiceDomainService invoiceDomainService = new InvoiceDomainService(invoiceRepository.Object);

            InvoiceModel invoice = new InvoiceModel()
            {
                AppointmentID = Guid.NewGuid(),
                ClientID = Guid.NewGuid(),
                Id = Guid.NewGuid(),
                InvoiceDate = default,
                Price = default
            };

            // Act
            IList<string> result = invoiceDomainService.Post(invoice);

            // Assert
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void Post_VaiDarSucesso()
        {
            // Arrange
            var invoiceRepository = new Mock<IInvoiceRepository>();

            invoiceRepository.Setup(x => x.Post(It.IsAny<InvoiceModel>())).Returns(true);

            InvoiceDomainService invoiceDomainService = new InvoiceDomainService(invoiceRepository.Object);

            InvoiceModel invoice = new InvoiceModel()
            {
                AppointmentID = Guid.NewGuid(),
                ClientID = Guid.NewGuid(),
                Id = Guid.NewGuid(),
                InvoiceDate = DateTime.Now,
                Price = 5
            };

            // Act
            List<string> result = invoiceDomainService.Post(invoice);

            // Assert
            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void Put_VaiFalharDevidoAErrosDeValidacaoDeDominio()
        {
            // Arrange
            var invoiceRepository = new Mock<IInvoiceRepository>();

            InvoiceDomainService InvoiceDomainService = new InvoiceDomainService(invoiceRepository.Object);

            InvoiceModel invoice = new InvoiceModel()
            {
                AppointmentID = Guid.NewGuid(),
                ClientID = Guid.NewGuid(),
                Id = Guid.NewGuid(),
                InvoiceDate = default,
                Price = decimal.One
            };

            // Act
            List<string> result = InvoiceDomainService.Put(invoice);

            // Assert
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void Put_VaiFalharNoInsertNaDb()
        {
            // Arrange
            var invoiceRepository = new Mock<IInvoiceRepository>();

            invoiceRepository.Setup(x => x.Put(It.IsAny<InvoiceModel>())).Returns(false);

            InvoiceDomainService invoiceDomainService = new InvoiceDomainService(invoiceRepository.Object);

            InvoiceModel invoice = new InvoiceModel()
            {
                AppointmentID = Guid.NewGuid(),
                ClientID = Guid.NewGuid(),
                Id = Guid.NewGuid(),
                InvoiceDate = DateTime.Now,
                Price = decimal.One
            };

            // Act
            IList<string> result = invoiceDomainService.Put(invoice);

            // Assert
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void Put_VaiDarSucesso()
        {
            // Arrange
            var invoiceRepository = new Mock<IInvoiceRepository>();

            invoiceRepository.Setup(x => x.Put(It.IsAny<InvoiceModel>())).Returns(true);

            InvoiceDomainService invoiceDomainService = new InvoiceDomainService(invoiceRepository.Object);

            InvoiceModel invoice = new InvoiceModel()
            {
                AppointmentID = Guid.NewGuid(),
                ClientID = Guid.NewGuid(),
                Id = Guid.NewGuid(),
                InvoiceDate = DateTime.Now,
                Price = decimal.One
            };

            // Act
            List<string> result = invoiceDomainService.Put(invoice);

            // Assert
            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void Delete_VaiDarSucessoEApagar()
        {
            // Arrange
            var invoiceRepository = new Mock<IInvoiceRepository>();

            invoiceRepository.Setup(x => x.Delete(It.IsAny<Guid>())).Returns(true);

            InvoiceDomainService invoiceDomainService = new InvoiceDomainService(invoiceRepository.Object);

            // Act
            bool result = invoiceDomainService.Delete(Guid.NewGuid());

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Get_VaiRetornarOInvoicee()
        {
            // Arrange
            Guid invoiceGuid = Guid.NewGuid();

            var invoiceRepository = new Mock<IInvoiceRepository>();

            invoiceRepository.Setup(x => x.Get(It.IsAny<Guid>())).Returns(new InvoiceModel()
            {
                Id = invoiceGuid,
                AppointmentID = Guid.NewGuid(),
                ClientID = Guid.NewGuid(),
                InvoiceDate = DateTime.Now,
                Price = decimal.One
            });

            InvoiceDomainService invoiceDomainService = new InvoiceDomainService(invoiceRepository.Object);

            // Act
            InvoiceModel result = invoiceDomainService.Get(Guid.NewGuid());

            // Assert
            Assert.AreEqual(result.GetType(), typeof(InvoiceModel));
        }

        [TestMethod]
        public void GetAll_VaiRetornarOsRecibos()
        {
            // Arrange
            var invoices = new List<InvoiceModel>() { new InvoiceModel() {
                Id = Guid.NewGuid(),
                AppointmentID = Guid.NewGuid(),
                ClientID = Guid.NewGuid(),
                InvoiceDate = DateTime.Now,
                Price = decimal.One
            } };

            var invoiceRepository = new Mock<IInvoiceRepository>();

            invoiceRepository.Setup(x => x.GetAll()).Returns(invoices);
            InvoiceDomainService invoiceDomainService = new InvoiceDomainService(invoiceRepository.Object);

            // Act
            var result = invoiceDomainService.GetAll();

            // Assert
            Assert.AreEqual(invoices, result);
        }
    }
}
