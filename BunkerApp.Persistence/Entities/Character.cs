using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace BunkerApp.Persistence.Entities;

[Serializable]
[DataContract]
[Table("characters")]
public sealed class Character
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
    public string Profession { get; set; }
    public string Health { get; set; }
    public string Phobia { get; set; }
    public string Hobby { get; set; }
    public string AdditionalInfo { get; set; }
    public bool CreatedByAI { get; set; }
    public DateTime CreatedAt { get; set; }
}