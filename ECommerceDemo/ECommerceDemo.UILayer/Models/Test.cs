using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ECommerceDemo.UILayer.Models
{
	public class Test
	{
		[BsonId]
		public ObjectId _Id { get; set; }
		public string NameSurname { get; set; }
		public int Age { get; set; }
	}
}
