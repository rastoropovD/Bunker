using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace BunkerApp.Persistence.Entities;

[Serializable]
[DataContract]
[Table("votes")]
public sealed class Vote
{
    public Guid Id { get; set; }
    public Guid GameSessionId { get; set; }
    public GameSession GameSession { get; set; }
    public Guid VoterPlayerId { get; set; }
    public Player VoterPlayer { get; set; }
    public Guid VotedForPlayerId { get; set; }
    public Player VotedForPlayer { get; set; }
    public DateTime VoteTime { get; set; }
    public int Round { get; set; }
}