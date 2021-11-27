using ECommerceDemo.DataAccess.Abstract;
using ECommerceDemo.Entities;
using System.Collections.Generic;

namespace ECommerceDemo.DataAccess.Concrete.EfCore
{
	public class EfCoreProductDal : EfCoreGenericRepository<Product, ShoppingContext>, IProductDal
	{
		public IEnumerable<Product> GetPopularProducts() {
			throw new System.NotImplementedException();
		}
	}
}
