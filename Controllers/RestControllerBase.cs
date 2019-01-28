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
	public class RestControllerBase<T> : ControllerBase where T : DbItem
	{
		private readonly IMongoCollection<T> _collection;

		public RestControllerBase(IMongoCollection<T> collection)
		{
			this._collection = collection;
		}

		[HttpGet]
		public virtual ActionResult<List<T>> Get()
		{
			return this._collection.Get().ToList();
		}

		[HttpGet("{id:length(24)}")]
		public virtual ActionResult<T> Get(string id)
		{
			T obj = this._collection.Get(id);
			if (obj == null)
			{
				return NotFound();
			}
			return obj;
		}

		[HttpPost]
		public virtual ActionResult Create(T obj)
		{
			this._collection.Create(obj);
			return Ok();
		}

		[HttpPut("{id:length(24)}")]
		public virtual IActionResult Update(T obj)
		{
			if (this._collection.Get(obj.Id) == null)
			{
				return NotFound();
			}
			this._collection.ReplaceOne<T>(o => o.Id == obj.Id, obj);
			return Ok();
		}

		[HttpDelete("{id:length(24)}")]
		public virtual IActionResult Delete(string id)
		{
			T obj = this._collection.Get(id);
			if (obj == null)
			{
				return NotFound();
			}
			this._collection.Delete(id);
			return Ok();
		}
	}
}