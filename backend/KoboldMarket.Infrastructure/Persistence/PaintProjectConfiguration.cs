using KoboldMarket.Domain.Entities.PaintProjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KoboldMarket.Infrastructure.Persistence.Configurations;

public sealed class PaintProjectConfiguration : IEntityTypeConfiguration<PaintProject>
{
    public void Configure(EntityTypeBuilder<PaintProject> builder)
    {
        builder.ToTable("PaintProjects");

        builder.HasKey(paintProject => paintProject.Id);

        builder.Property(paintProject => paintProject.Name)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(paintProject => paintProject.Description)
            .HasMaxLength(2000);

        builder.Property(paintProject => paintProject.Status)
            .IsRequired();

        builder.Property(paintProject => paintProject.DateCreated)
            .IsRequired();

        builder.HasOne(paintProject => paintProject.User)
            .WithMany(user => user.PaintProjects)
            .HasForeignKey(paintProject => paintProject.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}