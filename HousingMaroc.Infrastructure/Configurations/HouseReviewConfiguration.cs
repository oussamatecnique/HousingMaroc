using HousingMaroc.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HousingMaroc.Infrastructure.Configurations;

public class ReviewConfiguration: IEntityTypeConfiguration<HouseReview>
{
    public void Configure(EntityTypeBuilder<HouseReview> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        
        builder.Property(x => x.Comment).HasColumnType("nvarchar(max)");
        
        builder.HasOne(x => x.House)
            .WithMany()
            .HasForeignKey(x => x.HouseId);
        
        builder.HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId);

        builder.Property(x => x.Rating)
            .IsRequired();

        builder.ToTable("HouseReview",
            t => t.HasCheckConstraint("CK_Review_Rating", "[Rating] >= 1 AND [Rating] <= 5"));
    }
}
