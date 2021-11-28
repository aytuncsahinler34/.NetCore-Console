using ECommerceDemo.Core.DataAccess;
using ECommerceDemo.Entities;
using System.Collections.Generic;

namespace ECommerceDemo.DataAccess.Abstract
{
	public interface IProductDal: IBaseRepository<Product>
	{
		IEnumerable<Product> GetPopularProducts(); //private method
	}
}
