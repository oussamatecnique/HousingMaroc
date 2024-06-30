using HousingMaroc.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HousingMaroc.Infrastructure.Configurations;

public class UserConfiguration: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Email).HasColumnType("nvarchar(450)")
            .IsRequired();

        builder.HasIndex(x => x.Email).IsUnique();
        
        builder.Property(x => x.FirstName).HasColumnType("nvarchar(max)")
            .IsRequired();
        
        builder.Property(x => x.LastName).HasColumnType("nvarchar(max)")
            .IsRequired();
        
        builder.Property(x => x.Password).HasColumnType("nvarchar(max)")
            .IsRequired();
        
        builder.Property(x => x.PhoneNumber).HasColumnType("nvarchar(max)")
            .IsRequired();
        
        builder.Property(x => x.UserRole).HasConversion(new EnumToStringConverter<UserRole>())
            .IsRequired();
    }
}
