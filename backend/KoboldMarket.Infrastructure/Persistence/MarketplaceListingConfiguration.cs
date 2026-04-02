using KoboldMarket.Domain.Entities.Marketplace;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KoboldMarket.Infrastructure.Persistence.Configurations;

public sealed class MarketplaceListingConfiguration : IEntityTypeConfiguration<MarketplaceListing>
{
    public void Configure(EntityTypeBuilder<MarketplaceListing> builder)
    {
        builder.ToTable("MarketplaceListings");

        builder.HasKey(listing => listing.Id);

        builder.Property(listing => listing.Title)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(listing => listing.Description)
            .HasMaxLength(2000);

        builder.Property(listing => listing.Price)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(listing => listing.IsActive)
            .IsRequired();

        builder.Property(listing => listing.DateCreated)
            .IsRequired();

        builder.HasOne(listing => listing.User)
            .WithMany(user => user.MarketplaceListings)
            .HasForeignKey(listing => listing.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}