using HousingMaroc.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HousingMaroc.Infrastructure.Configurations;

public class HouseBookingConfiguration: IEntityTypeConfiguration<HouseBooking>
{
    public void Configure(EntityTypeBuilder<HouseBooking> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.HasOne(x => x.House)
            .WithMany()
            .HasForeignKey(x => x.HouseId);
        
        builder.HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId);
        
        builder.Property(x => x.TotalPrice).HasColumnType("decimal(18,2)");

        builder.Property(x => x.StartDate)
            .IsRequired();

        builder.Property(x => x.EndDate)
            .IsRequired();
    }
}
