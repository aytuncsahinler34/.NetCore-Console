using ECommerceDemo.Core.Entities;

namespace ECommerceDemo.Entities.Concrete
{
	public class Customer : DbObjectBase, IEntity
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Address { get; set; }
	}
}
