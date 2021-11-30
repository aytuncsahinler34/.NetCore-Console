using ECommerceDemo.Entities;
using System.Collections.Generic;

namespace ECommerceDemo.Business.Abstract
{
	public interface IOrderService
	{
		Order GetById(int id);
		List<Order> GetAll();
		Order Add(Order entity);
		Order Update(Order entity);
		void Delete(Order entity);
	}
}
