using DistributorAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DistributorAPI.Infrastructure.Configurations;

public class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.ToTable("Contact");
        builder.HasKey(cn => cn.Id);
        builder.Property(cn => cn.Name)
            .IsRequired()
            .HasMaxLength(255);
        builder.HasOne(cn => cn.Customer)
            .WithMany(d => d.Contacts)
            .HasForeignKey(cn => cn.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}