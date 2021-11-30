using ECommerceDemo.Core.RabbitMQModels;

namespace ECommerceDemo.RMQShared
{
	public interface IMessage
	{
		public OrderInfoModel OrderInfoModels { get; set; }
		string Text { get; set; }
	}
}
