using KoboldMarket.Domain.Entities.Sessions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KoboldMarket.Infrastructure.Persistence.Configurations;

public sealed class SessionConfiguration : IEntityTypeConfiguration<Session>
{
    public void Configure(EntityTypeBuilder<Session> builder)
    {
        builder.ToTable("Sessions");

        builder.HasKey(sessionEntity => sessionEntity.Id);

        builder.Property(sessionEntity => sessionEntity.Title)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(sessionEntity => sessionEntity.SessionDate)
            .IsRequired();

        builder.Property(sessionEntity => sessionEntity.Notes)
            .HasMaxLength(4000);

        builder.HasOne(sessionEntity => sessionEntity.Campaign)
            .WithMany(campaign => campaign.Sessions)
            .HasForeignKey(sessionEntity => sessionEntity.CampaignId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}