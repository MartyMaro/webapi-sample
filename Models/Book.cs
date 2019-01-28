using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApiSample.Models
{
	public class Book : DbItem
	{
		[BsonElement("Name")]
		public string BookName { get; set; }

		[BsonElement("Price")]
		public decimal Price { get; set; }

		[BsonElement("Category")]
		public string Category { get; set; }

		[BsonElement("Author")]
		public string Author { get; set; }
	}
}