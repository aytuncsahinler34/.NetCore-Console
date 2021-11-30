namespace ECommerceDemo.Core.RabbitMQModels
{
	public class OrderInfoModel
	{
		public int ProductId { get; set; }
		public string CustomerName { get; set; }
		public string CustomerLastName { get; set; }
		public string CustomerAddress { get; set; }
		public int Quantity { get; set; }
	}
}
