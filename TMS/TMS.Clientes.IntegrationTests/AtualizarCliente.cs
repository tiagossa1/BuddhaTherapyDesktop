using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TMS.Client.DI;
using TMS.Client.Domain.Services;
using TMS.Clientes.Service.Model;

namespace TMS.Client.IntegrationTests
{
    [TestClass]
    public class AtualizarCliente
    {
        [TestMethod]
        public void VaiAtualizarComSucesso()
        {
            // Arrange
            var container = BootStrapDI.Bootstrap();
            ClientService ClientService = new ClientService(container.GetInstance<ClientDomainService>());
            Guid userId = Guid.NewGuid();
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

            ClientDto clienteNewResult = new ClientDto()
            {
                Id = userId,
                Address = "xyz",
                Email = "xyz",
                FirstName = "Carlos",
                JobTitle = "xyz",
                LastName = "xyz",
                NIF = "123456789",
                PhoneNumber = "123456789"
            };

            // Act
            IList<string> insertResult = ClientService.Create(cliente);
            cliente.FirstName = "Carlos";
            IList<string> updateResult = ClientService.Edit(cliente);
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

            List<string> updateResult = ClientService.Edit(null);
            // Assert
            Assert.IsTrue(updateResult.Count > 0);
        }
    }
}
