using BunkerApp.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BunkerApp.Persistence.ModelConfigurations;

public sealed class GameSessionEntityTypeConfiguration : IEntityTypeConfiguration<GameSession>
{
    public void Configure(EntityTypeBuilder<GameSession> builder)
    {
        builder.HasKey(gs => gs.Id);
        builder.HasIndex(gs => gs.InviteCode).IsUnique();
        builder.HasOne(gs => gs.HostPlayer)
            .WithMany()
            .HasForeignKey(gs => gs.HostPlayerId);
        builder.HasOne(gs => gs.Disaster)
            .WithMany()
            .HasForeignKey(gs => gs.DisasterId);
    }
}