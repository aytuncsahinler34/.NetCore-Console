using ECommerceDemo.Entities;
using System.Collections.Generic;

namespace ECommerceDemo.Business.Abstract
{
	public interface ICategoryService
	{
		Category GetById(int id);
		List<Category> GetAll();
		Category Add(Category entity);
		Category Update(Category entity);
		void Delete(Category entity);
	}
}
