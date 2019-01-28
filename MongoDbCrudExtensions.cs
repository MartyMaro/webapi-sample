using System.Collections.Generic;
using WebApiSample.Models;
using MongoDB.Driver;

namespace WebApiSample
{
	public static class MongoDbCrudExtensions
	{
		/// <summary>
		/// CRUD extension method to get all items from the collection.
		/// </summary>
		/// <typeparam name="T">Collection type</typeparam>
		/// <returns>IEnumerable of all items in this collection.</returns>
		public static IEnumerable<T> Get<T>(this IMongoCollection<T> _this)
		{
			return _this.Find(o => true).ToEnumerable();
		}

		/// <summary>
		/// CRUD extension method to get one item from the collection.
		/// </summary>
		/// <param name="id">ID of the item.</param>
		/// <typeparam name="T">Collection type.</typeparam>
		/// <returns>The item with the given ID from this collection.</returns>
		public static T Get<T>(this IMongoCollection<T> _this, string id) where T : DbItem
		{
			return _this.Find<T>(o => o.Id == id).SingleOrDefault();
		}

		/// <summary>
		/// CRUD extension method to add one item into the collection.
		/// </summary>
		/// <param name="item">Item to add.</param>
		/// <typeparam name="T">Collection type.</typeparam>
		public static void Create<T>(this IMongoCollection<T> _this, T item)
		{
			_this.InsertOne(item);
		}

		/// <summary>
		/// CRUD extension method to update one item in the collection.
		/// </summary>
		/// <param name="item">Item to update. Its ID will determine the item that will be updated.</param>
		/// <typeparam name="T">Collection type.</typeparam>
		public static void Update<T>(this IMongoCollection<T> _this, T item) where T : DbItem
		{
			_this.ReplaceOne<T>(o => o.Id == item.Id, item);
		}

		/// <summary>
		/// CRUD extension method to delete one item from the collection.
		/// </summary>
		/// <param name="item">Item to delete.</param>
		/// <typeparam name="T">Collection type.</typeparam>
		public static void Delete<T>(this IMongoCollection<T> _this, T item) where T : DbItem
		{
			_this.Delete(item.Id);
		}

		/// <summary>
		/// CRUD extension method to delete one item from the collection.
		/// </summary>
		/// <param name="id">ID of the item to delete.</param>
		/// <typeparam name="T">Collection type.</typeparam>
		public static void Delete<T>(this IMongoCollection<T> _this, string id) where T : DbItem
		{
			_this.DeleteOne<T>(o => o.Id == id);
		}
	}
}