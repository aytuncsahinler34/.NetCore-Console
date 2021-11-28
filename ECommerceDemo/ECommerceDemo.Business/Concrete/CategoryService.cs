using ECommerceDemo.Business.Abstract;
using ECommerceDemo.DataAccess.Abstract;
using ECommerceDemo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceDemo.Business.Concrete
{
	public class CategoryService : ICategoryService
	{
		private ICategoryDal _categoryDal;

		public CategoryService(ICategoryDal categoryDal) {
			_categoryDal = categoryDal;
		}

		public List<Category> GetAll() {
			return _categoryDal.GetAll().ToList();
		}

		public Category GetById(int id) {
			return _categoryDal.GetById(id);
		}

		public Category Add(Category entity) {
			return _categoryDal.Add(entity);
		}

		public Category Update(Category entity) {
			return _categoryDal.Update(entity);
		}

		public void Delete(Category entity) {
			_categoryDal.Delete(entity);
		}
	}
}
