using KoboldMarket.Domain.Entities.Sessions;
using KoboldMarket.Domain.Entities.Users;

namespace KoboldMarket.Domain.Entities.Campaigns;

public sealed class Campaign
{
    public Guid Id { get; set; }
    public Guid OwnerUserId { get; set; }

    public string Name { get; set; } = string.Empty;
    public string SettingName { get; set; } = string.Empty;
    public string? Description { get; set; }

    public DateTime DateCreated { get; set; } = DateTime.Now;

    public User? OwnerUser { get; set; }
    public ICollection<CampaignMember> Members { get; set; } = new List<CampaignMember>();
    public ICollection<Session> Sessions { get; set; } = new List<Session>();
}