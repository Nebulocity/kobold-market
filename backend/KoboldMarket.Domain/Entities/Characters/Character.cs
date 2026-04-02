using KoboldMarket.Domain.Entities.Campaigns;
using KoboldMarket.Domain.Entities.Sessions;
using KoboldMarket.Domain.Entities.Users;

namespace KoboldMarket.Domain.Entities.Characters;

public sealed class Character
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }

    public string Name { get; set; } = string.Empty;
    public string Class { get; set; } = string.Empty;
    public string Race { get; set; } = string.Empty;
    public int Level { get; set; }

    public DateTime DateCreated { get; set; } = DateTime.Now;

    public User? User { get; set; }
    public ICollection<CampaignMember> CampaignMemberships { get; set; } = new List<CampaignMember>();
    public ICollection<LootEntry> LootEntries { get; set; } = new List<LootEntry>();
}