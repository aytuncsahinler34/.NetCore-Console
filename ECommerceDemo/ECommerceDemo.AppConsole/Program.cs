using ECommerceDemo.Core.Common.ECommerceDemo.Core.Common.Extensions.Primitive;
using ECommerceDemo.Core.RabbitMQModels;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ECommerceDemo.AppConsole
{
	class Program
	{
	   static async Task Main(string[] args) {

			try {

				string name,surname,address,quantity,productId;
				Console.Write("Enter Name: ");
				name = Console.ReadLine();
				Console.Write("Enter Surname: ");
				surname = Console.ReadLine();
				Console.Write("Address: ");
				address = Console.ReadLine();
				Console.Write("Quantity: ");
				quantity = Console.ReadLine();
				Console.Write("Product: ");
				productId = Console.ReadLine();


				var builder = new ConfigurationBuilder();
				BuildConfig(builder);

				Log.Logger = new LoggerConfiguration()
				.ReadFrom.Configuration(builder.Build())
				.Enrich.FromLogContext()
				.WriteTo.Seq(SeriLogConsts.SeriLogUri)
				.CreateLogger();

				Log.Logger.Information("Application Starting"); //serilog

				

				var bus = Bus.Factory.CreateUsingRabbitMq(factory => {
					factory.Host(RabbitMqConsts.RabbitmqUri, configurator => {
						configurator.Username(RabbitMqConsts.Username);
						configurator.Password(RabbitMqConsts.Password);
					});
				});

				var sendToUri = new Uri($"{RabbitMqConsts.RabbitmqUri}/{RabbitMqConsts.Queue}");
				var endpoint = await bus.GetSendEndpoint(sendToUri);

				await Task.Run(async () => {
						Message message = new Message {
							Text = "Publish",
							OrderInfoModels = new OrderInfoModel() {
								CustomerAddress = address,
								CustomerLastName = surname,
								CustomerName = name,
								ProductId = productId.AsInt(),
								Quantity = quantity.AsInt()
							}
					};

					await endpoint.Send<Message>(message);
				});
				Log.Logger.Information("Application Finish");  //serilog
				Console.ReadLine();
			}
			catch(Exception) {
				Log.Logger.Error("Application Failed"); //serilog
				throw;
			}
		}

		static void BuildConfig(IConfigurationBuilder builder) 
		{
			builder.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional:true)
				.AddEnvironmentVariables();
		}
	}

	public class Message
	{
		public OrderInfoModel OrderInfoModels { get; set; }
		public string Text { get; set; }
	}

	//appsettings.json a da yazılabilirdi.
	public class RabbitMqConsts
	{
		public const string RabbitmqUri = "amqp://guest:guest@localhost:5672";
		public const string Queue = "test-queue";
		public const string Username = "guest";
		public const string Password = "guest";
	}

	public class SeriLogConsts
	{
		public const string SeriLogUri = "http://localhost:5341/";
	}
}
