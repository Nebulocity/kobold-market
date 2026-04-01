using KoboldMarket.Domain.Entities.Users;

namespace KoboldMarket.Domain.Entities.BuildShares;

public sealed class BuildShare
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }

    public string Title { get; set; } = string.Empty;
    public string SystemName { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;

    public DateTime DateCreated { get; set; } = DateTime.Now;

    public User? User { get; set; }
}