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
            var container = BootStrapDI.Bootstrap();
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
            var container = BootStrapDI.Bootstrap();
            ClientService ClientService = new ClientService(container.GetInstance<ClientDomainService>());
            Guid userId = Guid.NewGuid();
            // Act
            ClientDto cliente = new ClientDto(userId, "XYZ", "XYZ", "XYZ", 912564785, "XYZ@x.x", 123456789, "XYZ");

            IList<string> postResult = ClientService.Post(cliente);
            ClientDto clienteResult = ClientService.Get(userId);

            // Assert
            Assert.IsTrue(postResult.Count == 0);
            Assert.IsTrue(clienteResult.Equals(cliente));
        }

        [TestMethod]
        public void VaiRetornarTodosOsClientes()
        {
            // Arrange
            var container = BootStrapDI.Bootstrap();
            ClientService ClientService = new ClientService(container.GetInstance<ClientDomainService>());
            Guid userId = Guid.NewGuid();

            // Act
            ClientDto cliente = new ClientDto(userId, "XYZ", "XYZ", "XYZ", 912564785, "XYZ@x.x", 123456789, "XYZ");
            IList<string> postResult = ClientService.Post(cliente);
            List<ClientDto> clienteResult = ClientService.GetAll().ToList();

            // Assert
            Assert.IsTrue(postResult.Count == 0);
            Assert.IsTrue(clienteResult.Contains(cliente));
        }
    }
}
