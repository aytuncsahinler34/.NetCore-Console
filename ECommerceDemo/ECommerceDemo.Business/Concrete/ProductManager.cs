﻿using ECommerceDemo.Business.Abstract;
using ECommerceDemo.DataAccess.Abstract;
using ECommerceDemo.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceDemo.Business.Concrete
{
	public class ProductManager : IProductService
	{
		private IProductDal _productDal;

		public ProductManager(IProductDal productDal) 
		{
			_productDal = productDal;
		}

		public void Create(Product entity) {
			_productDal.Create(entity);
		}

		public void Delete(Product entity) {
			_productDal.Delete(entity);
		}

		public List<Product> GetAll() 
		{
			return _productDal.GetAll().ToList();
		}

		public Product GetById(int id) 
		{
			return _productDal.GetById(id);
		}

		public void Update(Product entity) {
			_productDal.Update(entity);
		}
	}
}
