using ECommerceDemo.Business.Abstract;
using ECommerceDemo.DataAccess.Abstract;
using ECommerceDemo.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceDemo.Business.Concrete
{
	public class CustomerService : ICustomerService
	{
		private ICustomerDal _customerDal;

		public CustomerService(ICustomerDal customerDal) {
			_customerDal = customerDal;
		}

		public Customer GetById(int id) {
			return _customerDal.GetById(id);
		}

		public List<Customer> GetAll() {
			return _customerDal.GetAll().ToList();
		}

		public Customer Add(Customer entity) {
			return _customerDal.Add(entity);
		}

		public void Delete(Customer entity) {
			_customerDal.Delete(entity);
		}

		public Customer Update(Customer entity) {
			return _customerDal.Update(entity);
		}
	}
}
