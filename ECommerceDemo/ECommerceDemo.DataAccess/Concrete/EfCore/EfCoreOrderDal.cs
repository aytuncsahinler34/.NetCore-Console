using ECommerceDemo.DataAccess.Abstract;
using ECommerceDemo.Entities;

namespace ECommerceDemo.DataAccess.Concrete.EfCore
{
	public class EfCoreOrderDal : EfCoreGenericRepository<Order, ShoppingContext>, IOrderDal
	{

	}
}
