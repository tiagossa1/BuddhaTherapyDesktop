using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TherapyManagementSystem.Domain.Entities;

namespace TherapyManagementSystem.Infrastructure.Data.Mapping
{
    public class InvoiceMap : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("Invoice");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.ClientId)
                .IsRequired()
                .HasColumnName("ClientId");

            builder.Property(c => c.Price)
                .IsRequired()
                .HasColumnName("Price");

            builder.Property(c => c.Date)
                .IsRequired()
                .HasColumnName("Date");
        }
    }
}
