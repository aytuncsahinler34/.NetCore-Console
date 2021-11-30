using ECommerceDemo.Core.Entities;
using ECommerceDemo.Entities.Concrete;
using System;

namespace ECommerceDemo.Entities
{
	public class Order : DbObjectBase, IEntity
	{
		public int CustomerId  { get; set; }
		public Customer Customer { get; set; }
		public DateTimeOffset OrderDate { get; set; }
		public byte OrderState { get; set; }
		public int Quantity { get; set; }
	}
}
