using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.EntityConfigurations;

public class TariffConfiguration : IEntityTypeConfiguration<Tariff>
{
    public void Configure(EntityTypeBuilder<Tariff> builder)
    {
        builder.HasIndex(x => x.Id);
        builder.Property(x => x.TariffName).IsRequired();
        builder.Property(x => x.Price).IsRequired();
        builder.Property(x => x.BackupSize).IsRequired();

    }
}