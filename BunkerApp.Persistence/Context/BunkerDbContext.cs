using System.Data;
using BunkerApp.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace BunkerApp.Persistence;

public sealed class BunkerDbContext : DbContext
{
    public DbSet<PlayerEntity> Players { get; set; }

    public BunkerDbContext(DbContextOptions<BunkerDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseIdentityColumns();
        modelBuilder.HasDefaultSchema("public");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BunkerDbContext).Assembly);
        
        base.OnModelCreating(modelBuilder);
    }
}