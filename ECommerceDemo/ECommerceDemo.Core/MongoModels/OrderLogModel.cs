using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ECommerceDemo.Core.MongoModels
{
	public class OrderLogModel
	{
		[BsonId]
		public ObjectId _Id { get; set; }
		public int OrderId { get; set; }
		public string Message { get; set; }

	}
}
