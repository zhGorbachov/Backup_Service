using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.EntityConfigurations;

public class BackupConfiguration : IEntityTypeConfiguration<Backup>
{
    public void Configure(EntityTypeBuilder<Backup> builder)
    {
        builder.HasIndex(x => x.Id);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
        builder.Property(x => x.TarrifType).IsRequired();
        builder.Property(x => x.CreationTime).IsRequired();
        builder.Property(x => x.Size).IsRequired();
        
        builder
            .HasOne(x => x.Storage)
            .WithMany(x => x.Backups)
            .HasForeignKey(x => x.IdStorage)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.NoAction);
    }
}