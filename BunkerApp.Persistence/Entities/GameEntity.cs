using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace BunkerApp.Persistence.Entities;

[Serializable]
[DataContract]
[Table("games")]
public sealed class GameEntity
{
    public string EventType { get; set; }
    public string EventDescription { get; set; }
    public int StartMembersCount { get; set; }
    public int RequiredMembersCount { get; set; }
}