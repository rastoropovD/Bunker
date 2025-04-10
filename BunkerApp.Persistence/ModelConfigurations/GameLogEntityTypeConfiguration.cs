using BunkerApp.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BunkerApp.Persistence.ModelConfigurations;

public sealed class GameLogEntityTypeConfiguration : IEntityTypeConfiguration<GameLog>
{
    public void Configure(EntityTypeBuilder<GameLog> builder)
    {
        builder.HasKey(gl => gl.Id);
        builder.HasOne(gl => gl.GameSession)
            .WithMany()
            .HasForeignKey(gl => gl.GameSessionId);
        builder.HasOne(gl => gl.Player)
            .WithMany()
            .HasForeignKey(gl => gl.PlayerId);
    }
}