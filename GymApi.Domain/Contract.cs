using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GymApi.Domain;

public class Contract
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? ContractId { get; set; }
    public Guid UserId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string UsedPlan { get; set; }
    public ICollection<string> Terms { get; set; }
}