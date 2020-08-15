using Castle.DynamicProxy.Generators.Emitters;
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
        [DataRow(null, "XYZ", "XYZ", "912564785", "XYZ", "123456789", "XYZ")]
        [DataRow("XYZ", "XYZ", "XYZ", "912564785", "XYZ", "123456789", "")]
        [DataRow("XYZ", "XYZ", "XYZ", "912564785", "XYZ", "1234567898", "xyz")]
        public void ClientDomainService_Post_VaiFalharDevidoaErrosdeValidacaodeDominio(string firstName, string lastname, string address, string phoneNumber, string email, string nif, string jobTitle)
        {
            // Arrange
            var clientRepository = new Mock<IClientRepository>();
            ClientDomainService clientDomainService = new ClientDomainService(clientRepository.Object);
            ClientModel cliente = new ClientModel()
            {
                Address = address,
                Email = email,
                PhoneNumber = phoneNumber,
                FirstName = firstName,
                Id = Guid.NewGuid(),
                JobTitle = jobTitle,
                LastName = lastname,
                NIF = nif
            };

            // Act
            List<string> result = clientDomainService.Create(cliente);

            // Assert
            Assert.IsTrue(result.Count > 0);
        }

        [DataTestMethod]
        [DataRow("XYZ", "XYZ", "XYZ", "912564785", "XYZ@x.x", "123456789", "XYZ")]
        [DataRow("XYZ", "XYZ", "XYZ", "912564785", "XYZ@x.x", "123456789", "XYZ")]
        [DataRow("XYZ", "XYZ", "XYZ", "912564785", "XYZ@x.x", "123456789", "xyz")]
        public void ClientDomainService_Post_VaiFalharNoInsertNaDb(string firstName, string lastname, string address, string phoneNumber, string email, string nif, string jobTitle)
        {
            // Arrange
            var clientRepository = new Mock<IClientRepository>();
            clientRepository.Setup(x => x.Create(It.IsAny<ClientModel>())).Returns(false);
            ClientDomainService ClientDomainService = new ClientDomainService(clientRepository.Object);

            ClientModel client = new ClientModel()
            {
                Address = address,
                Email = email,
                PhoneNumber = phoneNumber,
                FirstName = firstName,
                Id = Guid.NewGuid(),
                JobTitle = jobTitle,
                LastName = lastname,
                NIF = nif
            };

            // Act
            List<string> result = ClientDomainService.Create(client);

            // Assert
            Assert.IsTrue(result.Count > 0);
        }

        [DataTestMethod]
        [DataRow("XYZ", "XYZ", "XYZ", "912564785", "XYZ@x.x", "123456789", "XYZ")]
        public void ClientDomainService_Post_VaiDarSucesso(string firstName, string lastname, string address, string phoneNumber, string email, string nif, string jobTitle)
        {
            // Arrange
            var clientRepository = new Mock<IClientRepository>();
            clientRepository.Setup(x => x.Create(It.IsAny<ClientModel>())).Returns(true);
            ClientDomainService clientDomainService = new ClientDomainService(clientRepository.Object);

            ClientModel client = new ClientModel()
            {
                Address = address,
                Email = email,
                PhoneNumber = phoneNumber,
                FirstName = firstName,
                Id = Guid.NewGuid(),
                JobTitle = jobTitle,
                LastName = lastname,
                NIF = nif
            };

            // Act
            List<string> result = clientDomainService.Create(client);

            // Assert
            Assert.IsTrue(result.Count == 0);
        }

        [DataTestMethod]
        [DataRow(null, "XYZ", "XYZ", "912564785", "XYZ", "123456789", "XYZ")]
        [DataRow("XYZ", "XYZ", "XYZ", "912564785", "XYZ", "123456789", "")]
        [DataRow("XYZ", "XYZ", "XYZ", "912564785", "XYZ", "1234567898", "xyz")]
        public void ClientDomainService_Put_VaiFalharDevidoaErrosdeValidacaodeDominio(string firstName, string lastname, string address, string phoneNumber, string email, string nif, string jobTitle)
        {
            // Arrange
            var clientRepository = new Mock<IClientRepository>();
            ClientDomainService clientDomainService = new ClientDomainService(clientRepository.Object);

            ClientModel client = new ClientModel()
            {
                Address = address,
                Email = email,
                PhoneNumber = phoneNumber,
                FirstName = firstName,
                Id = Guid.NewGuid(),
                JobTitle = jobTitle,
                LastName = lastname,
                NIF = nif
            };

            // Act
            List<string> result = clientDomainService.Edit(client);

            // Assert
            Assert.IsTrue(result.Count > 0);
        }

        [DataTestMethod]
        [DataRow("XYZ", "XYZ", "XYZ", "912564785", "XYZ@x.x", "123456789", "XYZ")]
        [DataRow("XYZ", "XYZ", "XYZ", "912564785", "XYZ@x.x", "123456789", "XYZ")]
        [DataRow("XYZ", "XYZ", "XYZ", "912564785", "XYZ@x.x", "123456789", "xyz")]
        public void ClientDomainService_Put_VaiFalharNoInsertNaDb(string firstName, string lastname, string address, string phoneNumber, string email, string nif, string jobTitle)
        {
            // Arrange
            var clientRepository = new Mock<IClientRepository>();
            clientRepository.Setup(x => x.Edit(It.IsAny<ClientModel>())).Returns(false);
            ClientDomainService clientDomainService = new ClientDomainService(clientRepository.Object);

            ClientModel client = new ClientModel()
            {
                Address = address,
                Email = email,
                PhoneNumber = phoneNumber,
                FirstName = firstName,
                Id = Guid.NewGuid(),
                JobTitle = jobTitle,
                LastName = lastname,
                NIF = nif
            };

            // Act
            List<string> result = clientDomainService.Edit(client);

            // Assert
            Assert.IsTrue(result.Count > 0);
        }

        [DataTestMethod]
        [DataRow("XYZ", "XYZ", "XYZ", "912564785", "XYZ@x.x", "123456789", "XYZ")]
        public void ClientDomainService_Put_VaiDarSucesso(string firstName, string lastname, string address, string phoneNumber, string email, string nif, string jobTitle)
        {
            // Arrange
            var clientRepository = new Mock<IClientRepository>();
            clientRepository.Setup(x => x.Edit(It.IsAny<ClientModel>())).Returns(true);
            ClientDomainService ClientDomainService = new ClientDomainService(clientRepository.Object);

            ClientModel client = new ClientModel()
            {
                Address = address,
                Email = email,
                PhoneNumber = phoneNumber,
                FirstName = firstName,
                Id = Guid.NewGuid(),
                JobTitle = jobTitle,
                LastName = lastname,
                NIF = nif
            };

            // Act
            List<string> result = ClientDomainService.Edit(client);

            // Assert
            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void ClientDomainService_Delete_VaiDarSucessoEApagar()
        {
            // Arrange
            var clientRepository = new Mock<IClientRepository>();
            clientRepository.Setup(x => x.Delete(It.IsAny<Guid>())).Returns(true);
            ClientDomainService clientDomainService = new ClientDomainService(clientRepository.Object);

            // Act
            bool result = clientDomainService.Delete(Guid.NewGuid());

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ClientDomainService_Get_VaiRetornarOCliente()
        {
            // Arrange
            Guid clientGuid = Guid.NewGuid();
            var clientRepository = new Mock<IClientRepository>();
            clientRepository.Setup(x => x.Get(It.IsAny<Guid>())).Returns(new ClientModel()
            {
                Address = "xyz",
                PhoneNumber = "123456789",
                NIF = "123456789",
                LastName = "xyz",
                JobTitle = "xyz",
                Id = clientGuid,
                Email = "xyz",
                FirstName = "xyz"
            });

            ClientDomainService clientDomainService = new ClientDomainService(clientRepository.Object);

            // Act
            ClientModel result = clientDomainService.Get(Guid.NewGuid());

            // Assert
            Assert.AreEqual(result.GetType(), typeof(ClientModel));
        }

        [TestMethod]
        public void ClientDomainService_GetAll_VaiRetornarOsClientes()
        {
            // Arrange
            var clients = new List<ClientModel>() {new ClientModel()
            {
                Address = "xyz",
                PhoneNumber = "123456789",
                NIF = "123456789",
                LastName = "xyz",
                JobTitle = "xyz",
                Id = Guid.NewGuid(),
                Email = "xyz",
                FirstName = "xyz"
            } };

            var clientRepository = new Mock<IClientRepository>();
            clientRepository.Setup(x => x.GetAll()).Returns(clients);
            ClientDomainService clientDomainService = new ClientDomainService(clientRepository.Object);

            // Act
            List<ClientModel> result = clientDomainService.GetAll();

            // Assert
            Assert.AreEqual(clients, result);
        }
    }
}
