using ECommerceDemo.Core.Entities;

namespace ECommerceDemo.Entities
{
	public class ProductCategory : DbObjectBase, IEntity //junction table many to many 
	{
		public int CategoryId { get; set; }
		public Category  Category { get; set; }
		public int ProductId { get; set; }
		public Product Product { get; set; }
	}
}
