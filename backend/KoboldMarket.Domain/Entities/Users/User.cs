using KoboldMarket.Domain.Entities.Campaigns;
using KoboldMarket.Domain.Entities.Characters;
using KoboldMarket.Domain.Entities.PaintProjects;
using KoboldMarket.Domain.Entities.Marketplace;
using KoboldMarket.Domain.Entities.BuildShares;

namespace KoboldMarket.Domain.Entities.Users;

public sealed class User
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public DateTime DateCreated { get; set; } = DateTime.Now;


    public ICollection<Character> Characters { get; set; } = new List<Character>();
    public ICollection<Campaign> OwnedCampaigns { get; set; } = new List<Campaign>();
    public ICollection<PaintProject> PaintProjects { get; set; } = new List<PaintProject>();
    public ICollection<MarketplaceListing> MarketplaceListings { get; set; } = new List<MarketplaceListing>();
    public ICollection<BuildShare> BuildShares { get; set; } = new List<BuildShare>();


}