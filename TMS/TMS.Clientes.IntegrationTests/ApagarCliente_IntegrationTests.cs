using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TMS.Client.DI;
using TMS.Client.Domain.Services;
using TMS.Clientes.Service.Model;

namespace TMS.Client.IntegrationTests
{
    [TestClass]
    public class ApagarCliente_IntegrationTests
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
            ClientService ClientService = new ClientService(container.GetInstance<ClientDomainService>());
            Guid userId = Guid.NewGuid();
            ClientDto cliente = new ClientDto(userId, "XYZ", "XYZ", "XYZ", 912564785, "XYZ@x.x", 123456789, "XYZ");

            // Act
            IList<string> result = ClientService.Post(cliente);
            bool clienteResult = ClientService.Delete(userId);

            // Assert
            Assert.IsTrue(result.Count == 0);
            Assert.IsTrue(clienteResult);
        }
    }
}
