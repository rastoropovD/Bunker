using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace BunkerApp.Persistence.Entities;

[Serializable]
[DataContract]
[Table("game_sessions")]
public sealed class GameSession
{
    public Guid Id { get; set; }
    public Guid HostPlayerId { get; set; }
    public Player HostPlayer { get; set; }
    public string InviteCode { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? StartedAt { get; set; }
    public DateTime? EndedAt { get; set; }
    public Guid? DisasterId { get; set; }
    public Disaster Disaster { get; set; }
    public bool IsFinished { get; set; }
    public List<GamePlayer> GamePlayers { get; set; }
}