using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasIndex(x => x.Id);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(40);
        builder.Property(x => x.Surname).IsRequired().HasMaxLength(65);
        builder.Property(x => x.PhoneNumber).IsRequired();
        builder.Property(x => x.Email).IsRequired();
        
        builder
            .HasMany(x => x.Accounts)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.IdUser)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.SetNull);
    }
}