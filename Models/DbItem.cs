using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApiSample.Models
{
	public class DbItem
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }
	}
}