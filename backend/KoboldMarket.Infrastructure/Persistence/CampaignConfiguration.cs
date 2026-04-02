using KoboldMarket.Domain.Entities.Campaigns;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KoboldMarket.Infrastructure.Persistence.Configurations;

public sealed class CampaignConfiguration : IEntityTypeConfiguration<Campaign>
{
    public void Configure(EntityTypeBuilder<Campaign> builder)
    {
        builder.ToTable("Campaigns");

        builder.HasKey(campaign => campaign.Id);

        builder.Property(campaign => campaign.Name)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(campaign => campaign.SettingName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(campaign => campaign.Description)
            .HasMaxLength(2000);

        builder.Property(campaign => campaign.DateCreated)
            .IsRequired();

        builder.HasOne(campaign => campaign.OwnerUser)
            .WithMany(user => user.OwnedCampaigns)
            .HasForeignKey(campaign => campaign.OwnerUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}