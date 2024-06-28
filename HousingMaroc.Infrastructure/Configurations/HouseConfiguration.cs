using HousingMaroc.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HousingMaroc.Infrastructure.Configurations;

public class HouseConfiguration: IEntityTypeConfiguration<House>
{
    public void Configure(EntityTypeBuilder<House> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Description).HasMaxLength(maxLength: 500);
    }
}
