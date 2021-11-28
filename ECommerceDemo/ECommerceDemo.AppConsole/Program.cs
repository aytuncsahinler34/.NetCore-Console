using ECommerceDemo.Business.Abstract;
using ECommerceDemo.Business.Concrete;
using ECommerceDemo.Core.MongoModels;
using ECommerceDemo.DataAccess.Abstract;
using ECommerceDemo.DataAccess.Concrete.EfCore;
using ECommerceDemo.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Bson;
using MongoDB.Driver;
using Serilog;
using System;
using System.IO;

namespace ECommerceDemo.AppConsole
{
	class Program
	{
		static void Main(string[] args) {
			var builder = new ConfigurationBuilder();
			BuildConfig(builder);

			Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Build())
			.Enrich.FromLogContext()
			.WriteTo.Console()
			.WriteTo.Seq("http://localhost:5341/")
			.CreateLogger();

			Log.Logger.Information("Application Starting");
			var host = Host.CreateDefaultBuilder()
				.ConfigureServices((context, services) => {
					services.AddScoped<IProductService,ProductService>();
					services.AddScoped<IProductDal, ProductDal>();
				})
				.UseSerilog()
				.Build();

			var svc = ActivatorUtilities.CreateInstance<ProductService>(host.Services);
			var insertedOrder = svc.Add(new Product {
				Name="Test1",
				ImageUrl="",
				Price = 50,
				CreatedDate = DateTimeOffset.Now,
				Creator = 0
			});

			var settings = MongoClientSettings.FromConnectionString("mongodb+srv://aytuncsahinler:Gs123456@ecommercedemo.pwbe9.mongodb.net/ECommerceDB?retryWrites=true&w=majority");
			var client = new MongoClient(settings);
			var database = client.GetDatabase("ECommerceDB");
			var collection = database.GetCollection<OrderLogModel>("OrderLogModel");

			var orderLogModel = new OrderLogModel() {

				_Id = ObjectId.GenerateNewId(),
				Message = "Sipariş eklendi.",
				OrderId = insertedOrder.Id
			};
			collection.InsertOne(orderLogModel);
			Console.ReadKey();
		}

		static void BuildConfig(IConfigurationBuilder builder) 
		{
			builder.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional:true)
				.AddEnvironmentVariables();
		}
	}
}
