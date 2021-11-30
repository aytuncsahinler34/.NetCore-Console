using ECommerceDemo.Business.Abstract;
using ECommerceDemo.DataAccess.Abstract;
using ECommerceDemo.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceDemo.Business.Concrete
{
	public class ProductService : IProductService
	{
		private IProductDal _productDal;

		public ProductService(IProductDal productDal) {
			_productDal = productDal;
		}

		public Product GetById(int id) {
			return _productDal.GetById(id);
		}

		public List<Product> GetAll() 
		{
			return _productDal.GetAll().ToList();
		}

		public Product Add(Product entity) {
			return _productDal.Add(entity);
		}

		public void Delete(Product entity) {
			_productDal.Delete(entity);
		}

		public Product Update(Product entity) {
			return _productDal.Update(entity);
		}
	}
}
