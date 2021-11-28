using ECommerceDemo.Core.Entities;

namespace ECommerceDemo.Entities
{
	public class Category : DbObjectBase, IEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
}
