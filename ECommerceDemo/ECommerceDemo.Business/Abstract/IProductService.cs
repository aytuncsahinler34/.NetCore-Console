using ECommerceDemo.Entities;
using System.Collections.Generic;

namespace ECommerceDemo.Business.Abstract
{
	public interface IProductService
	{
		Product GetById(int id);
		List<Product> GetAll();
		Product Add(Product entity);
		Product Update(Product entity);
		void Delete(Product entity);
	}
}
