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
        [DataRow(null, "XYZ", "XYZ", "912564785", "XYZ", "123456789", "XYZ")]
        [DataRow("XYZ", "XYZ", "XYZ", "912564785", "XYZ", "123456789", "")]
        public void VaiFalharDevidoaErrosdeValidacaodeDominio(string firstName, string lastname, string address, string phoneNumber, string email, string nif, string jobTitle)
        {
            // Arrange
            var container = BootStrapDI.Bootstrap();
            ClientService clientService = new ClientService(container.GetInstance<ClientDomainService>());
            ClientDto client = new ClientDto()
            {
                Address = address,
                Email = email,
                FirstName = firstName,
                Id = Guid.NewGuid(),
                JobTitle = jobTitle,
                LastName = lastname,
                NIF = nif,
                PhoneNumber = phoneNumber
            };

            // Act
            List<string> result = clientService.Create(client);

            // Assert
            Assert.IsTrue(result.Count > 0);
        }

        [DataTestMethod]
        [DataRow("XYZ", "XYZ", "XYZ", "912564785", "XYZ@x.x", "123456789", "XYZ")]
        public void VaiAdicionarComSucesso(string firstName, string lastname, string address, string phoneNumber, string email, string nif, string jobTitle)
        {
            // Arrange
            var container = BootStrapDI.Bootstrap();
            ClientService clientService = new ClientService(container.GetInstance<ClientDomainService>());
            ClientDto client = new ClientDto()
            {
                Address = address,
                Email = email,
                FirstName = firstName,
                Id = Guid.NewGuid(),
                JobTitle = jobTitle,
                LastName = lastname,
                NIF = nif,
                PhoneNumber = phoneNumber
            };

            // Act
            List<string> result = clientService.Create(client);

            // Assert
            Assert.IsTrue(result.Count == 0);
        }
    }
}
