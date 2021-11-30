using ECommerceDemo.Entities.Concrete;
using System.Collections.Generic;

namespace ECommerceDemo.Business.Abstract
{
	public interface ICustomerService
	{
		Customer GetById(int id);
		List<Customer> GetAll();
		Customer Add(Customer entity);
		Customer Update(Customer entity);
		void Delete(Customer entity);
	}
}
