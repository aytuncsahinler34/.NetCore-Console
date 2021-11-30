using ECommerceDemo.Business.Abstract;
using ECommerceDemo.Business.Concrete;
using ECommerceDemo.Core.Enums;
using ECommerceDemo.Core.MongoModels;
using ECommerceDemo.Core.RabbitMQModels;
using ECommerceDemo.DataAccess.Abstract;
using ECommerceDemo.DataAccess.Concrete.EfCore;
using ECommerceDemo.Entities;
using ECommerceDemo.Entities.Concrete;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Bson;
using MongoDB.Driver;
using Serilog;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ECommerceDemo.RMQConsumer
{
    class Program
	{
        
		static async Task Main(string[] args) {
            try {
                var builder = new ConfigurationBuilder();
                BuildConfig(builder);

                Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Build())
                .Enrich.FromLogContext()
                .WriteTo.Seq(SeriLogConsts.SeriLogUri)
                .CreateLogger();

                Log.Logger.Information("Consumer Starting"); //serilog

                var bus = Bus.Factory.CreateUsingRabbitMq(factory => {
                    factory.Host(RabbitMqConsts.RabbitmqUri, configurator => {
                        configurator.Username(RabbitMqConsts.Username);
                        configurator.Password(RabbitMqConsts.Password);
                    });
                    factory.ReceiveEndpoint(RabbitMqConsts.Queue, endpoint => endpoint.Consumer<MessageConsumer>());
                });

                await bus.StartAsync();
                Log.Logger.Information("Consumer Stop"); //serilog
                await bus.StopAsync();
                Console.ReadLine();
            }
			catch (Exception) {
                Log.Logger.Error("Application Failed"); //serilog
                throw;
			}
        }

        static void BuildConfig(IConfigurationBuilder builder) {
            builder.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                .AddEnvironmentVariables();
        }
    }
    
    public class MessageConsumer : IConsumer<Message>
    {
        public  Task Consume(ConsumeContext<Message> context) 
        {
            var host = Host.CreateDefaultBuilder()
                        .ConfigureServices((context, services) => {
                            services.AddScoped<IProductService, ProductService>();
                            services.AddScoped<IProductDal, ProductDal>();
                            services.AddScoped<IOrderService, OrderService>();
                            services.AddScoped<IOrderDal, OrderDal>();
                            services.AddScoped<ICustomerService, CustomerService>();
                            services.AddScoped<ICustomerDal, CustomerDal>();
                            services.AddScoped<IOrderItemsService, OrderItemsService>();
                            services.AddScoped<IOrderItemsDal, OrderItemsDal>();
                        })
                        .UseSerilog()
                        .Build();

            var customerSvc = ActivatorUtilities.CreateInstance<CustomerService>(host.Services);
            var orderSvc = ActivatorUtilities.CreateInstance<OrderService>(host.Services);
            var orderItemsSvc = ActivatorUtilities.CreateInstance<OrderItemsService>(host.Services);
            var productSvc = ActivatorUtilities.CreateInstance<ProductService>(host.Services);

            var message = context.Message;
            var insertedCustomer = customerSvc.Add(new Customer {
                FirstName = message.OrderInfoModels.CustomerName,
                LastName = message.OrderInfoModels.CustomerLastName,
                Address = message.OrderInfoModels.CustomerAddress,
                CreatedDate = DateTimeOffset.Now,
                Creator = 0
            });

            var insertedOrder = orderSvc.Add(new Order {
                OrderDate = DateTimeOffset.Now,
                OrderState = (byte) OrderState.New,
                CustomerId = insertedCustomer.Id,
                Customer = insertedCustomer,
                Quantity = message.OrderInfoModels.Quantity,
                CreatedDate = DateTimeOffset.Now,
                Creator = 0
            });

            var productItem = productSvc.GetById(message.OrderInfoModels.ProductId);

            var insertedOrderItems = orderItemsSvc.Add(new  OrderItems {
                Order = insertedOrder,
                OrderId = insertedOrder.Id,
                Product = productItem,
                ProductId = productItem.Id,
                CreatedDate = DateTimeOffset.Now,
                Creator = 0
            });

			var settings = MongoClientSettings.FromConnectionString(MongoDBConsts.MongoDBUri);
			var client = new MongoClient(settings);
			var database = client.GetDatabase("ECommerceDB");
			var collection = database.GetCollection<OrderLogModel>("OrderLogModel");

			var orderLogModel = new OrderLogModel() {

				_Id = ObjectId.GenerateNewId(),
				Message = "Sipariş eklendi.",
				OrderId = insertedOrder.Id
			};
			collection.InsertOne(orderLogModel);
            return context.ConsumeCompleted;
        }
    }

    //appsettings.json a da yazılabilirdi.
    public class RabbitMqConsts
    {
        public const string RabbitmqUri = "amqp://guest:guest@localhost:5672";
        public const string Queue = "test-queue";
        public const string Username = "guest";
        public const string Password = "guest";
    }
    public class MongoDBConsts
    {
        public const string MongoDBUri = "mongodb+srv://aytuncsahinler:Gs123456@ecommercedemo.pwbe9.mongodb.net/ECommerceDB?retryWrites=true&w=majority";
    }
    public class SeriLogConsts
    {
        public const string SeriLogUri = "http://localhost:5341/";
    }
    public class Message
    {
        public OrderInfoModel OrderInfoModels { get; set; }
        public string Text { get; set; }
    }
}
