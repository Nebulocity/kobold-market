using KoboldMarket.Domain.Entities.BuildShares;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KoboldMarket.Infrastructure.Persistence.Configurations;

public sealed class BuildShareConfiguration : IEntityTypeConfiguration<BuildShare>
{
    public void Configure(EntityTypeBuilder<BuildShare> builder)
    {
        builder.ToTable("BuildShares");

        builder.HasKey(buildShare => buildShare.Id);

        builder.Property(buildShare => buildShare.Title)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(buildShare => buildShare.SystemName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(buildShare => buildShare.Content)
            .HasMaxLength(10000)
            .IsRequired();

        builder.Property(buildShare => buildShare.DateCreated)
            .IsRequired();

        builder.HasOne(buildShare => buildShare.User)
            .WithMany(user => user.BuildShares)
            .HasForeignKey(buildShare => buildShare.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}