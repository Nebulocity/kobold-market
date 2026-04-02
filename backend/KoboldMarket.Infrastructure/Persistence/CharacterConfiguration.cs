using KoboldMarket.Domain.Entities.Characters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KoboldMarket.Infrastructure.Persistence.Configurations;

public sealed class CharacterConfiguration : IEntityTypeConfiguration<Character>
{
    public void Configure(EntityTypeBuilder<Character> builder)
    {
        builder.ToTable("Characters");

        builder.HasKey(character => character.Id);

        builder.Property(character => character.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(character => character.Class)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(character => character.Race)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(character => character.Level)
            .IsRequired();

        builder.Property(character => character.DateCreated)
            .IsRequired();

        builder.HasOne(character => character.User)
            .WithMany(user => user.Characters)
            .HasForeignKey(character => character.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}