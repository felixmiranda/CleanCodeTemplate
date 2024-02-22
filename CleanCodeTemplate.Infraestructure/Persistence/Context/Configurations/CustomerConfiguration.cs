﻿using CleanCodeTemplate.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanCodeTemplate.Infraestructure;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
                .HasColumnName("CustomerId");

        builder.Property(x => x.Name)
                .HasMaxLength(50);

        builder.HasIndex(x => x.Name)
                .IsUnique();

        builder.Property(x => x.LastName)
                .HasMaxLength(50);

        builder.Property(x => x.Address)
                .HasMaxLength(255);

        builder.Property(x => x.City)
        .HasMaxLength(200);
    }
}
