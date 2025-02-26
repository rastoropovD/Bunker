using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace BunkerApp.Persistence.Entities;

[Serializable]
[DataContract]
[Table("players")]
public sealed class PlayerEntity
{
    
}