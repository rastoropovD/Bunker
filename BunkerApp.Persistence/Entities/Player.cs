using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace BunkerApp.Persistence.Entities;

[Serializable]
[DataContract]
[Table("players")]
public sealed class Player
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string DisplayName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime LastActiveAt { get; set; }
}