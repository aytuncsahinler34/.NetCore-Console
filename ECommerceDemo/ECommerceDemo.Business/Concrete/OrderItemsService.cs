using ECommerceDemo.Business.Abstract;
using ECommerceDemo.DataAccess.Abstract;
using ECommerceDemo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDemo.Business.Concrete
{
	public class OrderItemsService : IOrderItemsService
	{
		private IOrderItemsDal _orderItemsDal;

		public OrderItemsService(IOrderItemsDal orderItemsDal) {
			_orderItemsDal = orderItemsDal;
		}

		public OrderItems GetById(int id) {
			return _orderItemsDal.GetById(id);
		}

		public List<OrderItems> GetAll() {
			return _orderItemsDal.GetAll().ToList();
		}

		public OrderItems Add(OrderItems entity) {
			return _orderItemsDal.Add(entity);
		}

		public void Delete(OrderItems entity) {
			_orderItemsDal.Delete(entity);
		}

		public OrderItems Update(OrderItems entity) {
			return _orderItemsDal.Update(entity);
		}
	}
}
