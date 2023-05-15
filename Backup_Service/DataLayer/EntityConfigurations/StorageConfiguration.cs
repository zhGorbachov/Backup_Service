using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.EntityConfigurations;

public class StorageConfiguration : IEntityTypeConfiguration<Storage>
{
    public void Configure(EntityTypeBuilder<Storage> builder)
    {
        builder.HasIndex(x => x.Id);
        builder.Property(x => x.Path).IsRequired();

        builder.Property(x => x.TotalSize).IsRequired();
        
        builder.Property(x => x.UsedSize).IsRequired();

        // builder
        //     .HasMany(x => x.Backups)
        //     .WithOne(x => x.Storage)
        //     .HasForeignKey(x => x.IdStorage)
        //     .HasPrincipalKey(x => x.Id);
    }
}