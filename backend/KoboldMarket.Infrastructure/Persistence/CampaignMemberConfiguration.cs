using KoboldMarket.Domain.Entities.Campaigns;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KoboldMarket.Infrastructure.Persistence.Configurations;

public sealed class CampaignMemberConfiguration : IEntityTypeConfiguration<CampaignMember>
{
    public void Configure(EntityTypeBuilder<CampaignMember> builder)
    {
        builder.ToTable("CampaignMembers");

        builder.HasKey(campaignMember => campaignMember.Id);

        builder.Property(campaignMember => campaignMember.Role)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(campaignMember => campaignMember.DateJoined)
            .IsRequired();

        builder.HasOne(campaignMember => campaignMember.Campaign)
            .WithMany(campaign => campaign.Members)
            .HasForeignKey(campaignMember => campaignMember.CampaignId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(campaignMember => campaignMember.Character)
            .WithMany(character => character.CampaignMemberships)
            .HasForeignKey(campaignMember => campaignMember.CharacterId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(campaignMember => new
        {
            campaignMember.CampaignId,
            campaignMember.CharacterId
        }).IsUnique();
    }
}