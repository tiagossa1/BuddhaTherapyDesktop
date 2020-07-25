using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TMS.Client.DI;
using TMS.Client.Domain.Services;
using TMS.Clientes.Service.Model;

namespace TMS.Client.IntegrationTests
{
    [TestClass]
    public class AdicionarNovoCliente
    {
        [DataTestMethod]
        [DataRow(null, "XYZ", "XYZ", 912564785, "XYZ", 123456789, "XYZ")]
        [DataRow("XYZ", "XYZ", "XYZ", 912564785, "XYZ", 123456789, "")]
        public void VaiFalharDevidoaErrosdeValidacaodeDominio(string firstName, string lastname, string address, int phoneNumber, string email, int nif, string jobTitle)
        {
            // Arrange
            var container = BootStrapDI.Bootstrap();
            ClientService ClientService = new ClientService(container.GetInstance<ClientDomainService>());
            ClientDto cliente = new ClientDto(Guid.NewGuid(), firstName, lastname, address, phoneNumber, email, nif, jobTitle);

            // Act
            IList<string> result = ClientService.Post(cliente);

            // Assert
            Assert.IsTrue(result.Count > 0);
        }

        [DataTestMethod]
        [DataRow("XYZ", "XYZ", "XYZ", 912564785, "XYZ@x.x", 123456789, "XYZ")]
        public void VaiAdicionarComSucesso(string firstName, string lastname, string address, int phoneNumber, string email, int nif, string jobTitle)
        {
            // Arrange
            var container = BootStrapDI.Bootstrap();
            ClientService ClientService = new ClientService(container.GetInstance<ClientDomainService>());
            ClientDto cliente = new ClientDto(Guid.NewGuid(), firstName, lastname, address, phoneNumber, email, nif, jobTitle);

            // Act
            IList<string> result = ClientService.Post(cliente);

            // Assert
            Assert.IsTrue(result.Count == 0);
        }
    }
}
