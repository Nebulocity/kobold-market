using KoboldMarket.Domain.Entities.Characters;

namespace KoboldMarket.Domain.Entities.Sessions;

public sealed class LootEntry
{
    public Guid Id { get; set; }
    public Guid SessionId { get; set; }
    public Guid CharacterId { get; set; }

    public string ItemName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public string? Notes { get; set; }

    public Session? Session { get; set; }
    public Character? Character { get; set; }
}