using HousingMaroc.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HousingMaroc.Infrastructure.Configurations;

public class HouseConfiguration: IEntityTypeConfiguration<House>
{
    public void Configure(EntityTypeBuilder<House> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Description).HasColumnType("nvarchar(max)");
        
        builder.Property(x => x.Address).HasColumnType("nvarchar(max)")
            .IsRequired();
        
        builder.Property(x => x.City).HasColumnType("nvarchar(max)")
            .IsRequired();

        builder.Property(x => x.Type).HasConversion(new EnumToStringConverter<HouseType>())
            .IsRequired();
        
        builder.HasOne(x => x.Owner)
            .WithMany()
            .HasForeignKey(x => x.OwnerId);

        builder.Property(x => x.Longitude).HasColumnType("decimal(18,2)");
        
        builder.Property(x => x.Latitude).HasColumnType("decimal(18,2)");
    }
}
