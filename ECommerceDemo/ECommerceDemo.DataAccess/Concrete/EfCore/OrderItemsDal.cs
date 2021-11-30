using ECommerceDemo.Core.DataAccess.EntityFrameworkCore;
using ECommerceDemo.DataAccess.Abstract;
using ECommerceDemo.Entities;

namespace ECommerceDemo.DataAccess.Concrete.EfCore
{
	public class OrderItemsDal : EfEntityRepositoryBase<OrderItems, ShoppingContext>, IOrderItemsDal
	{
	}
}
