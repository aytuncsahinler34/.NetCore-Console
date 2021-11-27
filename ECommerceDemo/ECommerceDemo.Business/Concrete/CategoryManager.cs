using ECommerceDemo.Business.Abstract;
using ECommerceDemo.DataAccess.Abstract;
using ECommerceDemo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceDemo.Business.Concrete
{
	public class CategoryManager : ICategoryService
	{
		private ICategoryDal _categoryDal;

		public CategoryManager(ICategoryDal categoryDal) {
			_categoryDal = categoryDal;
		}
		public void Create(Category entity) 
		{
			_categoryDal.Create(entity);
		}

		public void Delete(Category entity) 
		{
			_categoryDal.Delete(entity);
		}

		public List<Category> GetAll() {
			return _categoryDal.GetAll().ToList();
		}

		public Category GetById(int id) {
			return _categoryDal.GetById(id);
		}

		public void Update(Category entity) {
			_categoryDal.Update(entity);
		}
	}
}
