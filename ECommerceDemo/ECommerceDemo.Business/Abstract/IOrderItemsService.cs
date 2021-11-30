using ECommerceDemo.Entities;
using System.Collections.Generic;

namespace ECommerceDemo.Business.Abstract
{
	public interface IOrderItemsService
	{
		OrderItems GetById(int id);
		List<OrderItems> GetAll();
		OrderItems Add(OrderItems entity);
		OrderItems Update(OrderItems entity);
		void Delete(OrderItems entity);
	}
}
