using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using TMS.Client.DI;
using TMS.Client.Domain.Services;
using TMS.Clientes.Service.Model;

namespace TMS.Client.IntegrationTests
{
    [TestClass]
    public class ObterClientes
    {
        [TestMethod]
        public void VaiRetornarUmClienteVazio()
        {
            // Arrange
            var container = BootStrapDi.Bootstrap();
            ClientService ClientService = new ClientService(container.GetInstance<ClientDomainService>());

            // Act
            ClientDto cliente = ClientService.Get(Guid.NewGuid());

            // Assert
            Assert.IsTrue(cliente.Equals(new ClientDto()));
        }

        [TestMethod]
        public void VaiRetornarUmCliente()
        {
            // Arrange
            var container = BootStrapDi.Bootstrap();
            ClientService ClientService = new ClientService(container.GetInstance<ClientDomainService>());
            Guid userId = Guid.NewGuid();
            // Act
            ClientDto cliente = new ClientDto()
            {
                Id = userId,
                Address = "xyz",
                Email = "xyz",
                FirstName = "xyz",
                JobTitle = "xyz",
                LastName = "xyz",
                NIF = "123456789",
                PhoneNumber = "123456789"
            };

            List<string> postResult = ClientService.Create(cliente);
            ClientDto clienteResult = ClientService.Get(userId);

            // Assert
            Assert.IsTrue(postResult.Count == 0);
            Assert.IsTrue(clienteResult.Equals(cliente));
        }

        [TestMethod]
        public void VaiRetornarTodosOsClientes()
        {
            // Arrange
            var container = BootStrapDi.Bootstrap();
            ClientService ClientService = new ClientService(container.GetInstance<ClientDomainService>());
            Guid userId = Guid.NewGuid();

            // Act
            ClientDto cliente = new ClientDto()
            {
                Address = "xyz",
                PhoneNumber = "123456789",
                NIF = "123456789",
                LastName = "xyz",
                JobTitle = "xyz",
                FirstName = "xyz",
                Email = "xyz",
                Id = userId
            };
            IList<string> postResult = ClientService.Create(cliente);
            List<ClientDto> clienteResult = ClientService.GetAll().ToList();

            // Assert
            Assert.IsTrue(postResult.Count == 0);
            Assert.IsTrue(clienteResult.Contains(cliente));
        }
    }
}
