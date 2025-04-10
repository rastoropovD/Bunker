using System.Data;
using BunkerApp.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace BunkerApp.Persistence;

public sealed class BunkerDbContext : DbContext
{
    public DbSet<Player> Players { get; set; }
    public DbSet<GameSession> GameSessions { get; set; }
    public DbSet<GamePlayer> GamePlayers { get; set; }
    public DbSet<Character> Characters { get; set; }
    public DbSet<Disaster> Disasters { get; set; }
    public DbSet<Vote> Votes { get; set; }
    public DbSet<GameLog> GameLogs { get; set; }

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