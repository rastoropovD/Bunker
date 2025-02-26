using BunkerApp.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BunkerApp.Persistence.ModelConfigurations;

public sealed class PlayerEntityTypeConfiguration : IEntityTypeConfiguration<PlayerEntity>
{
    public void Configure(EntityTypeBuilder<PlayerEntity> builder)
    {
        
    }
}