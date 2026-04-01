
using KoboldMarket.Domain.Entities.Users;
using KoboldMarket.Domain.Enums;

namespace KoboldMarket.Domain.Entities.PaintProjects;

public sealed class PaintProject
{
    public Guid Id { get; set; }
    
    public Guid UserId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public PaintProjectStatus Status { get; set; } = PaintProjectStatus.NotStarted;
    
    public DateTime DateCreated { get; set; } = DateTime.Now;

    public User? User { get; set; }    
}