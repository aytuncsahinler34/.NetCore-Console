using ECommerceDemo.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.Controllers
{
	public class HomeController : Controller
	{
		IProductService _productService;

		public HomeController(IProductService productService) 
		{
			_productService = productService;
		}

		public IActionResult Index() 
		{
			return View(_productService.GetAll());
		}
	}
}
