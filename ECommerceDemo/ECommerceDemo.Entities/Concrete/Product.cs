using ECommerceDemo.Core.Entities;

namespace ECommerceDemo.Entities
{
	public class Product : DbObjectBase , IEntity
	{
		public string ProductName { get; set; }
		public decimal Price { get; set; }
	}
}
