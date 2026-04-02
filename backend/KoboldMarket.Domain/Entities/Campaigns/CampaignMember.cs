using KoboldMarket.Domain.Entities.Characters;

namespace KoboldMarket.Domain.Entities.Campaigns;

public sealed class CampaignMember
{
    public Guid Id { get; set; }
    public Guid CampaignId { get; set; }
    public Guid CharacterId { get; set; }

    public string Role { get; set; } = string.Empty;
    public DateTime DateJoined { get; set; } = DateTime.Now;

    public Campaign? Campaign { get; set; }
    public Character? Character { get; set; }
}