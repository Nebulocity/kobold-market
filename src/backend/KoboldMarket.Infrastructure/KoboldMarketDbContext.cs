/***************************************************************
*             My lazy EF Core migration cheat sheet            *
***************************************************************/
//
// New migration:
//      dotnet ef migrations add <MigrationName> --project KoboldMarket.Infrastructure --startup-project KoboldMarket.Api
//
// Apply pending migrations:
//      dotnet ef database update --project KoboldMarket.Infrastructure --startup-project KoboldMarket.Api
//
// List all migrations:
//      dotnet ef migrations list --project KoboldMarket.Infrastructure --startup-project KoboldMarket.Api
//
// Roll back to a previously applied migration:
//      dotnet ef database update <PreviousMigrationName --project KoboldMarket.Infrastructure --startup-project KoboldMarket.Api
//
// To remove a migration script:
//      dotnet ef migrations remove --project KoboldMarket.Infrastructure --startup-project KoboldMarket.Api
//
// To nuke the Db and start fresh:
//      dotnet ef database update 0 --project KoboldMarket.Infrastructure --startup-project KoboldMarket.Api


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
