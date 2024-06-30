using HousingMaroc.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HousingMaroc.Infrastructure.Configurations;

public class HouseAmenityConfiguration: IEntityTypeConfiguration<HouseAmenity>
{
    public void Configure(EntityTypeBuilder<HouseAmenity> builder)
    {
        builder.HasKey(x => new { x.HouseId, x.AmenityId });
        
   
        builder
            .HasOne(ha => ha.House)
            .WithMany(h => h.HouseAmenities)
            .HasForeignKey(ha => ha.HouseId);

        builder
            .HasOne(ha => ha.Amenity)
            .WithMany(a => a.HouseAmenities)
            .HasForeignKey(ha => ha.AmenityId);
    }
}
