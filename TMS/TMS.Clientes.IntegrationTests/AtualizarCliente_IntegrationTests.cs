using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TMS.Client.DI;
using TMS.Client.Domain.Services;
using TMS.Clientes.Service.Model;

namespace TMS.Client.IntegrationTests
{
    [TestClass]
    public class AtualizarCliente_IntegrationTests
    {
        [TestMethod]
        public void VaiAtualizarComSucesso()
        {
            // Arrange
            var container = BootStrapDI.Bootstrap();
            ClientService ClientService = new ClientService(container.GetInstance<ClientDomainService>());
            Guid userId = Guid.NewGuid();
            ClientDto cliente = new ClientDto(userId, "XYZ", "XYZ", "XYZ", 912564785, "XYZ@x.x", 123456789, "XYZ");
            ClientDto clienteNewResult = new ClientDto(userId, "Carlos", "XYZ", "XYZ", 912564785, "XYZ@x.x", 123456789, "XYZ");

            // Act
            IList<string> insertResult = ClientService.Post(cliente);
            cliente.FirstName = "Carlos";
            IList<string> updateResult = ClientService.Put(cliente);
            ClientDto clienteResult = ClientService.Get(userId);

            // Assert
            Assert.IsTrue(insertResult.Count == 0);
            Assert.IsTrue(updateResult.Count == 0);
            Assert.IsTrue(clienteResult.Equals(clienteNewResult));
        }

        [TestMethod]
        public void NãoAtualizaComValorNull()
        {
            // Arrange
            var container = BootStrapDI.Bootstrap();
            ClientService ClientService = new ClientService(container.GetInstance<ClientDomainService>());

            IList<string> updateResult = ClientService.Put(null);
            // Assert
            Assert.IsTrue(updateResult.Count > 0);
        }
    }
}
