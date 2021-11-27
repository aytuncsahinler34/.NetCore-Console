using ECommerceDemo.DataAccess.Abstract;
using ECommerceDemo.Entities;

namespace ECommerceDemo.DataAccess.Concrete.EfCore
{
	public class EfCoreCategoryDal : EfCoreGenericRepository<Category,ShoppingContext>, ICategoryDal
	{
		
	}
}
