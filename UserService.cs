using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace NETPROJECT
{
	public class UserService
	{
		private readonly OrderSystem _dataStorage;

		public UserService(OrderSystem orderSystem)
		{
			_dataStorage = orderSystem;
		}

		public void PrintOrders(List<Order> orders) =>
			orders.ForEach(order => order.PrintOrder());
		public List<Order> GetUserOrders(User user, Predicate<Order> criteria) =>
			_dataStorage.Orders
				.Where(order => order.SellerId == user.Id && criteria.Invoke(order))
				.ToList();

		public Administrator GetAvailableAdministrator() =>
			_dataStorage.Administrators.First();

		private static void Message(Administrator administrator,Order order) => 
			Console.WriteLine("Адмiнiстратор " + administrator.Nickname +
			                  " пiдтвердив ваше оголошення" + " №" + order.Id);

		public void SendOrderToValidation(Order order)
		{
			Administrator administrator = GetAvailableAdministrator();
			
			Console.WriteLine("Замовлення вiдправлене на обробку");
			Thread.Sleep(2000);
			
			administrator.NotifyUser += Message;
			order.OrderInfo.Validated = true;
		}
	}
}