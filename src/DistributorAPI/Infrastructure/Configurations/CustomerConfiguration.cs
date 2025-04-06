using DistributorAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DistributorAPI.Infrastructure.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customer");
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Document) // Renomeado de Cnpj para Document
            .IsRequired()
            .HasMaxLength(14);
        builder.Property(d => d.FullName) // Renomeado de CorporateName para FullName
            .IsRequired()
            .HasMaxLength(255);
        builder.Property(d => d.TradeName)
            .HasMaxLength(255); // Tornado opcional
        builder.Property(d => d.Email)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(d => d.Phone)
            .HasMaxLength(20);
        builder.Property(d => d.CustomerType)
            .IsRequired()
            .HasConversion<string>(); // Store as string in the database
    }
}