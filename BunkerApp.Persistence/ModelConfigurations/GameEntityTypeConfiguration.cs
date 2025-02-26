using BunkerApp.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BunkerApp.Persistence.ModelConfigurations;

public sealed class GameEntityTypeConfiguration : IEntityTypeConfiguration<GameEntity>
{
    public void Configure(EntityTypeBuilder<GameEntity> builder)
    {
        
    }
}