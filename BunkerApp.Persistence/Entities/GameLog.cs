using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace BunkerApp.Persistence.Entities;

[Serializable]
[DataContract]
[Table("game_logs")]
public sealed class GameLog
{
    public Guid Id { get; set; }
    public Guid GameSessionId { get; set; }
    public GameSession GameSession { get; set; }
    public Guid? PlayerId { get; set; }
    public Player Player { get; set; }
    public string ActionType { get; set; }
    public string Details { get; set; }
    public DateTime Timestamp { get; set; }
}