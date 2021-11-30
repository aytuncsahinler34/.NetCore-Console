using ECommerceDemo.Core.Entities;

namespace ECommerceDemo.Entities
{
	public class OrderItems : DbObjectBase, IEntity
	{
		public int OrderId { get; set; }
		public Order Order { get; set; }
		public int ProductId { get; set; }
		public Product Product { get; set; }
	}
}
