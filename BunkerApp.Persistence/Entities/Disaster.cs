using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace BunkerApp.Persistence.Entities;

[Serializable]
[DataContract]
[Table("disasters")]
public sealed class Disaster
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int SeverityLevel { get; set; }
    public bool GeneratedByAI { get; set; }
    public DateTime CreatedAt { get; set; }
}