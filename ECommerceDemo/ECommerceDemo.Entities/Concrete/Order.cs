using ECommerceDemo.Core.Entities;
using System;
using System.Collections.Generic;

namespace ECommerceDemo.Entities
{
	public class Order : DbObjectBase, IEntity
	{
		public string OrderNumber { get; set; }
		public DateTime OrderDate { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		public byte OrderState { get; set; }
		public byte PaymentTypes { get; set; }
		public List<OrderItems> OrderItems { get; set; }
	}
}
