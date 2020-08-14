using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TMS.Invoice.Domain.Models;
using TMS.Invoice.Service.Mapping;
using TMS.Invoice.Service.Model;

namespace TMS.Invoice.Service.Tests
{
    [TestClass]
    public class InvoiceAssemblerTest
    {
        [TestMethod]
        public void ConverterDeDtoToEntity()
        {
            // Arrange
            Guid newGuid = Guid.NewGuid();

            InvoiceDto invoiceDto = new InvoiceDto()
            {
                AppointmentID = Guid.NewGuid(),
                ClientID = Guid.NewGuid(),
                Id = newGuid,
                InvoiceDate = DateTime.Now,
                Price = decimal.One
            };

            InvoiceModel invoice = new InvoiceModel()
            {
                AppointmentID = Guid.NewGuid(),
                ClientID = Guid.NewGuid(),
                Id = newGuid,
                InvoiceDate = DateTime.Now,
                Price = decimal.One
            };

            // Act
            InvoiceModel result = InvoiceAssembler.DtoToEntity(invoiceDto);

            // Assert
            Assert.IsTrue(result.Equals(invoice));
        }

        [TestMethod]
        public void ConverterDeEntityParaDto_DeveRetornarUmObjectoVazioDevioAoValorNull()
        {
            // Arrange, Act 
            InvoiceDto result = InvoiceAssembler.EntityToDto(null);

            // Assert
            Assert.IsTrue(result.Equals(new InvoiceDto()));
        }

        [TestMethod]
        public void ConverterDeEntityParaDto()
        {
            // Arrange
            Guid newGuid = Guid.NewGuid();

            InvoiceDto invoiceDto = new InvoiceDto()
            {
                AppointmentID = Guid.NewGuid(),
                ClientID = Guid.NewGuid(),
                Id = newGuid,
                InvoiceDate = DateTime.Now,
                Price = decimal.One
            };

            InvoiceModel invoice = new InvoiceModel()
            {
                AppointmentID = Guid.NewGuid(),
                ClientID = Guid.NewGuid(),
                Id = newGuid,
                InvoiceDate = DateTime.Now,
                Price = decimal.One
            };

            // Act
            InvoiceDto result = InvoiceAssembler.EntityToDto(invoice);

            // Assert
            Assert.IsTrue(result.Equals(invoiceDto));
        }

        [TestMethod]
        public void ConverterDeEntitiesParaDtos()
        {
            // Arrange
            Guid newGuid = Guid.NewGuid();

            List<InvoiceDto> invoiceDtos = new List<InvoiceDto>() { new InvoiceDto()
            {
                AppointmentID = Guid.NewGuid(),
                ClientID = Guid.NewGuid(),
                Id = newGuid,
                InvoiceDate = DateTime.Now,
                Price = decimal.One
            } };

            List<InvoiceModel> invoices = new List<InvoiceModel>() { new InvoiceModel()
            {
                AppointmentID = Guid.NewGuid(),
                ClientID = Guid.NewGuid(),
                Id = newGuid,
                InvoiceDate = DateTime.Now,
                Price = decimal.One
            } };

            // Act
            List<InvoiceDto> result = InvoiceAssembler.EntitiesToDto(invoices);

            // Assert
            Assert.IsTrue(result.SequenceEqual(invoiceDtos));
        }

        [TestMethod]
        public void ConverterDeDtosParaEntities()
        {
            // Arrange
            Guid newGuid = Guid.NewGuid();

            List<InvoiceDto> invoiceDtos = new List<InvoiceDto>() { new InvoiceDto()
            {
                AppointmentID = Guid.NewGuid(),
                ClientID = Guid.NewGuid(),
                Id = newGuid,
                InvoiceDate = DateTime.Now,
                Price = decimal.One
            } };

            List<InvoiceModel> cliente = new List<InvoiceModel>() { new InvoiceModel()
            {
                AppointmentID = Guid.NewGuid(),
                ClientID = Guid.NewGuid(),
                Id = newGuid,
                InvoiceDate = DateTime.Now,
                Price = decimal.One
            } };

            // Act
            List<InvoiceModel> result = InvoiceAssembler.DtosToEntities(invoiceDtos);

            // Assert
            Assert.IsTrue(result.SequenceEqual(cliente));
        }

        [TestMethod]
        public void ConverterDeEntitiesParaDtos_MasAsEntitiesSaoNull()
        {
            // Arrange, Act 
            List<InvoiceDto> result = InvoiceAssembler.EntitiesToDto(null);
            // Assert
            Assert.IsTrue(result.SequenceEqual(new List<InvoiceDto>()));
        }

        [TestMethod]
        public void ConverterDeDtosParaEntities_MasODtoEstaVazio()
        {
            // Arrange, Act 
            InvoiceModel result = InvoiceAssembler.DtoToEntity(null);
            // Assert
            Assert.IsTrue(result.Equals(new InvoiceModel()));
        }
    }
}
