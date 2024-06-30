using HousingMaroc.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HousingMaroc.Infrastructure.Configurations;

public class HouseImageConfiguration: IEntityTypeConfiguration<HouseImage>
{
    public void Configure(EntityTypeBuilder<HouseImage> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        
        builder.Property(x => x.ImageUrl).HasColumnType("nvarchar(max)")
            .IsRequired();
        
        builder.HasOne(x => x.House)
            .WithMany()
            .HasForeignKey(x => x.HouseId);
    }
}
