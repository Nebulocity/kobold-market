// EF Cheat Sheet
//
// Create migration: 
//      dotnet ef migrations add InitialCreate --project KoboldMarket.Infrastructure --startup-project KoboldMarket.Api
// Update db:
//      dotnet ef database update --project KoboldMarket.Infrastructure --startup-project KoboldMarket.Api
//

using KoboldMarket.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace KoboldMarket.Infrastructure.Persistence;

public sealed class KoboldMarketDbContext : DbContext
{
    public KoboldMarketDbContext(DbContextOptions<KoboldMarketDbContext> options) : base(options)
    {
        // Stuff will go here
    }

    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(KoboldMarketDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}