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
        builder.Property(d => d.Cnpj)
            .IsRequired()
            .HasMaxLength(14);
        builder.Property(d => d.CorporateName)
            .IsRequired()
            .HasMaxLength(255);
        builder.Property(d => d.TradeName)
            .IsRequired()
            .HasMaxLength(255);
        builder.Property(d => d.Email)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(d => d.Phone)
            .HasMaxLength(20);
    }
}