using System.Collections.Generic;
using WebApiSample;
using WebApiSample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using MongoDB.Driver;

namespace WebApiSample.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BooksController : RestControllerBase<Book>
	{
		public BooksController(MongoDbContext database) : base(database.Books)
		{
		}
	}
}