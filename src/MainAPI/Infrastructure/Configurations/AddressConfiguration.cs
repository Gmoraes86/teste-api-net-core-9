using MainAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MainAPI.Infrastructure.Configurations;

public class AddressConfiguration: IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("Address"); 
        builder.HasKey(da => da.Id); 
        builder.Property(da => da.Addressinfo)
            .IsRequired()
            .HasMaxLength(500); 
        builder.HasOne(da => da.Distributor) 
            .WithMany(d => d.Addresses)
            .HasForeignKey(da => da.DistributorId)
            .OnDelete(DeleteBehavior.Cascade); 
    }
}