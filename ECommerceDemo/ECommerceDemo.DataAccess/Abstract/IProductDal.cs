using ECommerceDemo.Entities;
using System.Collections.Generic;

namespace ECommerceDemo.DataAccess.Abstract
{
	public interface IProductDal:IRepository<Product>
	{
		IEnumerable<Product> GetPopularProducts(); //private method
	}
}
