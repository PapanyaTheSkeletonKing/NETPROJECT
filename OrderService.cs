using System;

namespace NETPROJECT
{
	public class OrderService
	{
		private readonly OrderSystem _dataStorage;

		public OrderService(OrderSystem orderSystem)
		{
			_dataStorage = orderSystem;
		}

		public void AddOrder(Order order)
		{
			_dataStorage.Orders.Add(order);
			
		}

	}
}