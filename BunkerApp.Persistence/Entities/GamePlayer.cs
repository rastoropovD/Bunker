using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace BunkerApp.Persistence.Entities;

[Serializable]
[DataContract]
[Table("game_players")]
public sealed class GamePlayer
{
    public Guid Id { get; set; }
    public Guid GameSessionId { get; set; }
    public GameSession GameSession { get; set; }
    public Guid PlayerId { get; set; }
    public Player Player { get; set; }
    public Guid CharacterId { get; set; }
    public Character Character { get; set; }
    public DateTime JoinTime { get; set; }
    public bool IsAlive { get; set; }
    public DateTime? VotedOutAt { get; set; }
    public string Role { get; set; }
}