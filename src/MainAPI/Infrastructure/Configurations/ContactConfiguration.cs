using MainAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MainAPI.Infrastructure.Configurations;

public class ContactConfiguration: IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.ToTable("Contact"); 
        builder.HasKey(cn => cn.Id); 
        builder.Property(cn => cn.Name)
            .IsRequired()
            .HasMaxLength(255); 
        builder.HasOne(cn => cn.Distributor) 
            .WithMany(d => d.Contacts)
            .HasForeignKey(cn => cn.DistributorId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}