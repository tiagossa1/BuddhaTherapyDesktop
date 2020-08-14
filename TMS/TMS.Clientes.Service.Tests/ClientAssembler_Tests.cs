using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using TMS.Client.Domain.Interfaces;
using TMS.Client.Domain.Model;
using TMS.Client.Domain.Services;
using TMS.Clientes.Service.Mapping;
using TMS.Clientes.Service.Model;

namespace TMS.Client.Domain.Tests
{
    [TestClass]
    public class ClientService_Tests
    {
        [DataTestMethod]
        [DataRow("XYZ", "XYZ", "XYZ", "912564785", "XYZ@x.x", "123456789", "XYZ")]
        public void ClientAssembler_ConverterDeDtoToEntity(string firstName, string lastname, string address, string phoneNumber, string email, string nif, string jobTitle)
        {
            // Arrange
            Guid newGuid = Guid.NewGuid();
            ClientDto clientDto = new ClientDto()
            {
                Address = address,
                Id = newGuid,
                FirstName = firstName,
                Email = email,
                JobTitle = jobTitle,
                LastName = lastname,
                NIF = nif,
                PhoneNumber = phoneNumber
            };

            Model.ClientModel client = new Model.ClientModel()
            {
                Address = address,
                PhoneNumber = phoneNumber,
                NIF = nif,
                LastName = lastname,
                Email = email,
                FirstName = firstName,
                Id = newGuid,
                JobTitle = jobTitle
            };

            // Act
            Model.ClientModel result = ClientAssembler.DtoToEntity(clientDto);

            // Assert
            Assert.IsTrue(result.Equals(client));
        }

        [TestMethod]
        public void ClientAssembler_ConverterDeEntityParaDto_DeveRetornarUmObjectoVazioDevioAoValorNull()
        {
            // Arrange, Act 
            ClientDto result = ClientAssembler.EntityToDto(null);
            // Assert
            Assert.IsTrue(result.Equals(new ClientDto()));
        }

        [DataTestMethod]
        [DataRow("XYZ", "XYZ", "XYZ", "912564785", "XYZ@x.x", "123456789", "XYZ")]
        public void ClientAssembler_ConverterDeEntityParaDto(string firstName, string lastname, string address, string phoneNumber, string email, string nif, string jobTitle)
        {
            // Arrange
            Guid newGuid = Guid.NewGuid();

            ClientDto clientDto = new ClientDto()
            {
                Address = address,
                Id = newGuid,
                FirstName = firstName,
                Email = email,
                JobTitle = jobTitle,
                LastName = lastname,
                NIF = nif,
                PhoneNumber = phoneNumber
            };

            Model.ClientModel client = new Model.ClientModel()
            {
                Address = address,
                PhoneNumber = phoneNumber,
                NIF = nif,
                LastName = lastname,
                Email = email,
                FirstName = firstName,
                Id = newGuid,
                JobTitle = jobTitle
            };

            // Act
            ClientDto result = ClientAssembler.EntityToDto(client);

            // Assert
            Assert.IsTrue(result.Equals(clientDto));
        }

        [DataTestMethod]
        [DataRow("XYZ", "XYZ", "XYZ", "912564785", "XYZ@x.x", "123456789", "XYZ")]
        public void ClientAssembler_ConverterDeEntitiesParaDtos(string firstName, string lastname, string address, string phoneNumber, string email, string nif, string jobTitle)
        {
            // Arrange
            Guid newGuid = Guid.NewGuid();
            List<ClientDto> clientDtos = new List<ClientDto>() { new ClientDto()
            {
                Address = address,
                Id = newGuid,
                FirstName = firstName,
                Email = email,
                JobTitle = jobTitle,
                LastName = lastname,
                NIF = nif,
                PhoneNumber = phoneNumber
            } };

            List<Model.ClientModel> clients = new List<Model.ClientModel>() { new Model.ClientModel() {
                Address = address,
                PhoneNumber = phoneNumber,
                NIF = nif,
                LastName = lastname,
                Email = email,
                FirstName = firstName,
                Id = newGuid,
                JobTitle = jobTitle
            } };

            // Act
            List<ClientDto> result = ClientAssembler.EntitiesToDto(clients);

            // Assert
            Assert.IsTrue(result.SequenceEqual(clientDtos));
        }

        [DataTestMethod]
        [DataRow("XYZ", "XYZ", "XYZ", "912564785", "XYZ@x.x", "123456789", "XYZ")]
        public void ClientAssembler_ConverterDeDtosParaEntities(string firstName, string lastname, string address, string phoneNumber, string email, string nif, string jobTitle)
        {
            // Arrange
            Guid newGuid = Guid.NewGuid();
            List<ClientDto> clientDtos = new List<ClientDto>() { new ClientDto()
            {
                Address = address,
                Id = newGuid,
                FirstName = firstName,
                Email = email,
                JobTitle = jobTitle,
                LastName = lastname,
                NIF = nif,
                PhoneNumber = phoneNumber
            } };

            List<Model.ClientModel> clients = new List<Model.ClientModel>() { new Model.ClientModel() {
                Address = address,
                PhoneNumber = phoneNumber,
                NIF = nif,
                LastName = lastname,
                Email = email,
                FirstName = firstName,
                Id = newGuid,
                JobTitle = jobTitle
            } };

            // Act
            List<Model.ClientModel> result = ClientAssembler.DtosToEntities(clientDtos);

            // Assert
            Assert.IsTrue(result.SequenceEqual(clients));
        }

        [TestMethod]
        public void ClientAssembler_ConverterDeEntitiesParaDtos_MasasEntitieSaoNull()
        {
            // Arrange, Act 
            List<ClientDto> result = ClientAssembler.EntitiesToDto(null);
            // Assert
            Assert.IsTrue(result.SequenceEqual(new List<ClientDto>()));
        }

        [TestMethod]
        public void ClientAssembler_ConverterDeDtosParEntities_MasoDtoEstaVazio()
        {
            // Arrange, Act 
            Model.ClientModel result = ClientAssembler.DtoToEntity(null);
            // Assert
            Assert.IsTrue(result.Equals(new Model.ClientModel()));
        }
    }
}
