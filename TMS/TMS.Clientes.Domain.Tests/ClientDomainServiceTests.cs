using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using TMS.Client.Domain.Interfaces;
using TMS.Client.Domain.Model;
using TMS.Client.Domain.Services;

namespace TMS.Client.Domain.Tests
{
    [TestClass]
    public class ClientDomainService_Tests
    {
        [DataTestMethod]
        [DataRow(null, "XYZ", "XYZ", 912564785, "XYZ", 123456789, "XYZ")]
        [DataRow("XYZ", "XYZ", "XYZ", 912564785, "XYZ", 123456789, "")]
        [DataRow("XYZ", "XYZ", "XYZ", 912564785, "XYZ", 1234567898, "xyz")]
        public void ClientDomainService_Post_VaiFalharDevidoaErrosdeValidacaodeDominio(string firstName, string lastname, string address, int phoneNumber, string email, int nif, string jobTitle)
        {
            // Arrange
            var _clienteRepository = new Mock<IClientRepository>();
            ClientDomainService ClientDomainService = new ClientDomainService(_clienteRepository.Object);
            ClientModel cliente = new ClientModel(Guid.NewGuid(), firstName, lastname, address, phoneNumber, email, nif, jobTitle);

            // Act
            IList<string> result = ClientDomainService.Post(cliente);

            // Assert
            Assert.IsTrue(result.Count > 0);
        }

        [DataTestMethod]
        [DataRow("XYZ", "XYZ", "XYZ", 912564785, "XYZ@x.x", 123456789, "XYZ")]
        [DataRow("XYZ", "XYZ", "XYZ", 912564785, "XYZ@x.x", 123456789, "XYZ")]
        [DataRow("XYZ", "XYZ", "XYZ", 912564785, "XYZ@x.x", 123456789, "xyz")]
        public void ClientDomainService_Post_VaiFalharNoInsertNaDb(string firstName, string lastname, string address, int phoneNumber, string email, int nif, string jobTitle)
        {
            // Arrange
            var _clienteRepository = new Mock<IClientRepository>();
            _clienteRepository.Setup(x => x.Post(It.IsAny<ClientModel>())).Returns(false);
            ClientDomainService ClientDomainService = new ClientDomainService(_clienteRepository.Object);
            ClientModel client = new ClientModel(Guid.NewGuid(), firstName, lastname, address, phoneNumber, email, nif, jobTitle);

            // Act
            IList<string> result = ClientDomainService.Post(client);

            // Assert
            Assert.IsTrue(result.Count > 0);
        }

        [DataTestMethod]
        [DataRow("XYZ", "XYZ", "XYZ", 912564785, "XYZ@x.x", 123456789, "XYZ")]
        public void ClientDomainService_Post_VaiDarSucesso(string firstName, string lastname, string address, int phoneNumber, string email, int nif, string jobTitle)
        {
            // Arrange
            var _clienteRepository = new Mock<IClientRepository>();
            _clienteRepository.Setup(x => x.Post(It.IsAny<ClientModel>())).Returns(true);
            ClientDomainService ClientDomainService = new ClientDomainService(_clienteRepository.Object);
            ClientModel cliente = new ClientModel(Guid.NewGuid(), firstName, lastname, address, phoneNumber, email, nif, jobTitle);

            // Act
            IList<string> result = ClientDomainService.Post(cliente);

            // Assert
            Assert.IsTrue(result.Count == 0);
        }

        [DataTestMethod]
        [DataRow(null, "XYZ", "XYZ", 912564785, "XYZ", 123456789, "XYZ")]
        [DataRow("XYZ", "XYZ", "XYZ", 912564785, "XYZ", 123456789, "")]
        [DataRow("XYZ", "XYZ", "XYZ", 912564785, "XYZ", 1234567898, "xyz")]
        public void ClientDomainService_Put_VaiFalharDevidoaErrosdeValidacaodeDominio(string firstName, string lastname, string address, int phoneNumber, string email, int nif, string jobTitle)
        {
            // Arrange
            var _clienteRepository = new Mock<IClientRepository>();
            ClientDomainService ClientDomainService = new ClientDomainService(_clienteRepository.Object);
            ClientModel cliente = new ClientModel(Guid.NewGuid(), firstName, lastname, address, phoneNumber, email, nif, jobTitle);

            // Act
            IList<string> result = ClientDomainService.Put(cliente);

            // Assert
            Assert.IsTrue(result.Count > 0);
        }

        [DataTestMethod]
        [DataRow("XYZ", "XYZ", "XYZ", 912564785, "XYZ@x.x", 123456789, "XYZ")]
        [DataRow("XYZ", "XYZ", "XYZ", 912564785, "XYZ@x.x", 123456789, "XYZ")]
        [DataRow("XYZ", "XYZ", "XYZ", 912564785, "XYZ@x.x", 123456789, "xyz")]
        public void ClientDomainService_Put_VaiFalharNoInsertNaDb(string firstName, string lastname, string address, int phoneNumber, string email, int nif, string jobTitle)
        {
            // Arrange
            var _clienteRepository = new Mock<IClientRepository>();
            _clienteRepository.Setup(x => x.Put(It.IsAny<ClientModel>())).Returns(false);
            ClientDomainService ClientDomainService = new ClientDomainService(_clienteRepository.Object);
            ClientModel cliente = new ClientModel(Guid.NewGuid(), firstName, lastname, address, phoneNumber, email, nif, jobTitle);

            // Act
            IList<string> result = ClientDomainService.Put(cliente);

            // Assert
            Assert.IsTrue(result.Count > 0);
        }

        [DataTestMethod]
        [DataRow("XYZ", "XYZ", "XYZ", 912564785, "XYZ@x.x", 123456789, "XYZ")]
        public void ClientDomainService_Put_VaiDarSucesso(string firstName, string lastname, string address, int phoneNumber, string email, int nif, string jobTitle)
        {
            // Arrange
            var _clientRepository = new Mock<IClientRepository>();
            _clientRepository.Setup(x => x.Put(It.IsAny<ClientModel>())).Returns(true);
            ClientDomainService ClientDomainService = new ClientDomainService(_clientRepository.Object);
            ClientModel client = new ClientModel(Guid.NewGuid(), firstName, lastname, address, phoneNumber, email, nif, jobTitle);

            // Act
            IList<string> result = ClientDomainService.Put(client);

            // Assert
            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void ClientDomainService_Delete_VaiDarSucessoEApagar()
        {
            // Arrange
            var _clienteRepository = new Mock<IClientRepository>();
            _clienteRepository.Setup(x => x.Delete(It.IsAny<Guid>())).Returns(true);
            ClientDomainService ClientDomainService = new ClientDomainService(_clienteRepository.Object);

            // Act
            bool result = ClientDomainService.Delete(Guid.NewGuid());

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ClientDomainService_Get_VaiRetornarOCliente()
        {
            // Arrange
            Guid clientGuid = Guid.NewGuid();
            var _clienteRepository = new Mock<IClientRepository>();
            _clienteRepository.Setup(x => x.Get(It.IsAny<Guid>())).Returns(new ClientModel(clientGuid, "XYZ", "XYZ", "XYZ", 912564785, "XYZ@x.x", 123456789, "XYZ"));
            ClientDomainService ClientDomainService = new ClientDomainService(_clienteRepository.Object);

            // Act
            ClientModel result = ClientDomainService.Get(Guid.NewGuid());

            // Assert
            Assert.AreEqual(result.GetType(), typeof(ClientModel));
        }

        [TestMethod]
        public void ClientDomainService_GetAll_VaiRetornarOsClientes()
        {
            // Arrange
            var clientes = new List<ClientModel>() { new ClientModel(Guid.NewGuid(), "XYZ", "XYZ", "XYZ", 912564785, "XYZ@x.x", 123456789, "XYZ") };
            var _clienteRepository = new Mock<IClientRepository>();
            _clienteRepository.Setup(x => x.GetAll()).Returns(clientes);
            ClientDomainService ClientDomainService = new ClientDomainService(_clienteRepository.Object);

            // Act
            IList<ClientModel> result = ClientDomainService.GetAll();

            // Assert
            Assert.AreEqual(clientes, result);
        }
    }
}
