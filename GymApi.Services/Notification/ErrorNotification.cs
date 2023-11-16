using MediatR;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GymApi.UseCases.Notification;

public class ErrorNotification : INotification
{
	[BsonId]
	[BsonRepresentation(BsonType.ObjectId)]
	public string? ErrorId { get; set; }
	public string Exception { get; set; }
	public string StackTracer { get; set; }
	public string Class { get; set; }
}