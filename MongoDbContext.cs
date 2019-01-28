using System.Collections.Generic;
using System.Linq;
using WebApiSample.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace WebApiSample
{
	public class MongoDbContext
	{
		public IMongoCollection<Book> Books { get; private set; }

		public MongoDbContext(IConfiguration config)
		{
			var client = new MongoClient(config.GetConnectionString("BookstoreDb"));
			var database = client.GetDatabase("BookstoreDb");
			this.Books = database.GetCollection<Book>("Books");
		}
	}
}