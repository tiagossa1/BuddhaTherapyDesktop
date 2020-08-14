using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TMS.Client.DI;
using TMS.Client.Domain.Services;
using TMS.Clientes.Service.Model;

namespace TMS.Client.IntegrationTests
{
    [TestClass]
    public class ApagarCliente
    {
        [TestMethod]
        public void VaiApagarUmClienteQueNaoExiste()
        {
            // Arrange
            var container = BootStrapDI.Bootstrap();
            ClientService ClientService = new ClientService(container.GetInstance<ClientDomainService>());
            // Act
            bool clienteResult = ClientService.Delete(Guid.NewGuid());

            // Assert
            Assert.IsFalse(clienteResult);
        }

        [TestMethod]
        public void VaiApagarUmCliente()
        {
            // Arrange
            var container = BootStrapDI.Bootstrap();
            ClientService clientService = new ClientService(container.GetInstance<ClientDomainService>());
            Guid clientId = Guid.NewGuid();

            ClientDto client = new ClientDto()
            {
                Address = "xyz",
                PhoneNumber = "123456789",
                NIF = "123456789",
                LastName = "xyz",
                Email = "xyz",
                FirstName = "xyz",
                JobTitle = "xyz",
                Id = clientId
            };

            // Act
            List<string> result = clientService.Create(client);
            bool clientResult = clientService.Delete(clientId);

            // Assert
            Assert.IsTrue(result.Count == 0);
            Assert.IsTrue(clientResult);
        }
    }
}
