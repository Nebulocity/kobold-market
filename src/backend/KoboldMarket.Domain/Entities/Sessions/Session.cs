using KoboldMarket.Domain.Entities.Campaigns;

namespace KoboldMarket.Domain.Entities.Sessions;

public sealed class Session
{
    public Guid Id { get; set; }
    public Guid CampaignId { get; set; }

    public string Title { get; set; } = string.Empty;
    public DateTime SessionDate { get; set; }
    public string? Notes { get; set; }

    public Campaign? Campaign { get; set; }
    public ICollection<LootEntry> LootEntries { get; set; } = new List<LootEntry>();
}