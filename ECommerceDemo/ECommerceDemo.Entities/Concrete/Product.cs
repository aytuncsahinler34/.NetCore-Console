using ECommerceDemo.Core.Entities;

namespace ECommerceDemo.Entities
{
	public class Product : DbObjectBase , IEntity
	{
		public string Name { get; set; }
		public string ImageUrl { get; set; }
		public decimal Price { get; set; }
	}
}
