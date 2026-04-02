using KoboldMarket.Domain.Entities.Sessions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KoboldMarket.Infrastructure.Persistence.Configurations;

public sealed class LootEntryConfiguration : IEntityTypeConfiguration<LootEntry>
{
    public void Configure(EntityTypeBuilder<LootEntry> builder)
    {
        builder.ToTable("LootEntries");

        builder.HasKey(lootEntry => lootEntry.Id);

        builder.Property(lootEntry => lootEntry.ItemName)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(lootEntry => lootEntry.Quantity)
            .IsRequired();

        builder.Property(lootEntry => lootEntry.Notes)
            .HasMaxLength(1000);

        builder.HasOne(lootEntry => lootEntry.Session)
            .WithMany(sessionEntity => sessionEntity.LootEntries)
            .HasForeignKey(lootEntry => lootEntry.SessionId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(lootEntry => lootEntry.Character)
            .WithMany(character => character.LootEntries)
            .HasForeignKey(lootEntry => lootEntry.CharacterId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}