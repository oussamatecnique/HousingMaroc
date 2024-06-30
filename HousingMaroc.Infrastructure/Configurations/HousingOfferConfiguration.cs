using HousingMaroc.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HousingMaroc.Infrastructure.Configurations;

public class HousingOfferConfiguration: IEntityTypeConfiguration<HousingOffer>
{
    public void Configure(EntityTypeBuilder<HousingOffer> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.HasOne(x => x.House)
            .WithMany()
            .HasForeignKey(x => x.Id);
        
        builder.Property(x => x.Price).HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(x => x.HousingOfferType).HasConversion(new EnumToStringConverter<HousingOfferType>())
            .IsRequired();
    }
}
