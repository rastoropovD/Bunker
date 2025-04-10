using BunkerApp.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BunkerApp.Persistence.ModelConfigurations;

public sealed class DisasterEntityTypeConfiguration : IEntityTypeConfiguration<Disaster>
{
    public void Configure(EntityTypeBuilder<Disaster> builder)
    {
        builder.HasKey(d => d.Id);
    }
}