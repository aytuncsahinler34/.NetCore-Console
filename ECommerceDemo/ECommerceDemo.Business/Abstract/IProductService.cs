using ECommerceDemo.Entities;
using System.Collections.Generic;

namespace ECommerceDemo.Business.Abstract
{
	public interface IProductService
	{
		Product GetById(int id);
		List<Product> GetAll();
		void Create(Product entity);
		void Delete(Product entity);
		void Update(Product entity);
	}
}
