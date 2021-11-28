using ECommerceDemo.UILayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceDemo.UILayer.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly MongoClient client;

		public HomeController(ILogger<HomeController> logger) {
			_logger = logger;
			client = new MongoClient("mongodb+srv://aytuncsahinler:Gs123456@ecommercedemo.pwbe9.mongodb.net/ECommerceDB?retryWrites=true&w=majority");
		}

		public IActionResult Index() {

			//var customer = new Customer {
			//	Id = 1,
			//	Age = 26,
			//	NameSurname = "Aytunç Şahinler"
			//};

			//_logger.LogError("Hatalı Log  {@customer}", customer); //serilog kullanarak customer nesnesini loglamak.
			
			//var database = client.GetDatabase("ECommerceDB");
			//var collection = database.GetCollection<Test>("Test");  //relational tablodaki test tabloma 

			//var test = new Test() {
			//	_Id = ObjectId.GenerateNewId(),
			//	NameSurname = "Berkay Şahinler",
			//	Age = 26
			//};
			//collection.InsertOne(test);

			return View();
		}

		public IActionResult Privacy() {
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error() {
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
