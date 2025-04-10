using BunkerApp.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BunkerApp.Persistence.ModelConfigurations;

public sealed class VoteEntityTypeConfiguration : IEntityTypeConfiguration<Vote>
{
    public void Configure(EntityTypeBuilder<Vote> builder)
    {
        builder.HasKey(v => v.Id);
        builder.HasOne(v => v.GameSession)
            .WithMany()
            .HasForeignKey(v => v.GameSessionId);
        builder.HasOne(v => v.VoterPlayer)
            .WithMany()
            .HasForeignKey(v => v.VoterPlayerId);
        builder.HasOne(v => v.VotedForPlayer)
            .WithMany()
            .HasForeignKey(v => v.VotedForPlayerId);
    }
}