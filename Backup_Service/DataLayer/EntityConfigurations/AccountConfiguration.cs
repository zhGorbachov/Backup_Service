﻿using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.EntityConfigurations;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.HasIndex(x => x.Id);
        builder.Property(x => x.Login)
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(x => x.Password)
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(x => x.TariffType)
            .IsRequired(false);
        
        
        
        // builder
        //     .HasOne(x => x.Tariff)
        //     .WithMany(x => x.Accounts)
        //     .HasForeignKey(x => x.TariffType)
        //     .HasPrincipalKey(x => x.Id)
        //     .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasMany(x => x.Backups)
            .WithOne(x => x.Account)
            .HasForeignKey(x => x.IdAccount)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.SetNull);

        builder
            .HasOne(x => x.Storage)
            .WithMany(x => x.Accounts)
            .HasForeignKey(x => x.IdStorage)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.SetNull);
    }
}