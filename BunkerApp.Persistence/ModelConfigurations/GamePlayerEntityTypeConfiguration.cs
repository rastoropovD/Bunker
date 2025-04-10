using BunkerApp.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BunkerApp.Persistence.ModelConfigurations;

public sealed class GamePlayerEntityTypeConfiguration : IEntityTypeConfiguration<GamePlayer>
{
    public void Configure(EntityTypeBuilder<GamePlayer> builder)
    {
        builder.HasKey(gp => gp.Id);
        builder.HasOne(gp => gp.GameSession)
            .WithMany(gs => gs.GamePlayers)
            .HasForeignKey(gp => gp.GameSessionId);
        builder.HasOne(gp => gp.Player)
            .WithMany()
            .HasForeignKey(gp => gp.PlayerId);
        builder.HasOne(gp => gp.Character)
            .WithMany()
            .HasForeignKey(gp => gp.CharacterId);
    }
}