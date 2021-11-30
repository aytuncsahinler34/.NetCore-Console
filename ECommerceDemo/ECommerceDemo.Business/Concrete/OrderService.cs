using ECommerceDemo.Business.Abstract;
using ECommerceDemo.DataAccess.Abstract;
using ECommerceDemo.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceDemo.Business.Concrete
{
	public class OrderService : IOrderService
	{
		private IOrderDal _orderDal;

		public OrderService(IOrderDal orderDal) {
			_orderDal = orderDal;
		}

		public Order GetById(int id) {
			return _orderDal.GetById(id);
		}

		public List<Order> GetAll() {
			return _orderDal.GetAll().ToList();
		}

		public Order Add(Order entity) {
			return _orderDal.Add(entity);
		}

		public void Delete(Order entity) {
			_orderDal.Delete(entity);
		}

		public Order Update(Order entity) {
			return _orderDal.Update(entity);
		}
	}
}
