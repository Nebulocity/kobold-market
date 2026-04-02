using KoboldMarket.Domain.Entities.Users;

namespace KoboldMarket.Domain.Entities.Marketplace;

public sealed class MarketplaceListing
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }

    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public bool IsActive { get; set; } = true;

    public DateTime DateCreated { get; set; } = DateTime.Now;

    public User? User { get; set; }
}