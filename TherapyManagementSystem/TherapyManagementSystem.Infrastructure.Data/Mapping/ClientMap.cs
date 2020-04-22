using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TherapyManagementSystem.Domain.Entities;

namespace TherapyManagementSystem.Infrastructure.Data.Mapping
{
    public class ClientMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.FirstName)
                .IsRequired()
                .HasColumnName("FirstName");

            builder.Property(c => c.LastName)
                .IsRequired()
                .HasColumnName("LastName");

            builder.Property(c => c.Address)
                .IsRequired()
                .HasColumnName("Address");

            builder.Property(c => c.PhoneNumber)
                .IsRequired()
                .HasColumnName("PhoneNumber");

            builder.Property(c => c.NIF)
                .IsRequired()
                .HasColumnName("NIF");

            builder.Property(c => c.JobTitle)
                .IsRequired()
                .HasColumnName("JobTitle");
        }
    }
}
