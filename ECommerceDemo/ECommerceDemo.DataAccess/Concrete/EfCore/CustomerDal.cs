using ECommerceDemo.Core.DataAccess.EntityFrameworkCore;
using ECommerceDemo.DataAccess.Abstract;
using ECommerceDemo.Entities.Concrete;

namespace ECommerceDemo.DataAccess.Concrete.EfCore
{
	public class CustomerDal : EfEntityRepositoryBase<Customer, ShoppingContext>, ICustomerDal
	{
	}
}
