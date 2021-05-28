using System;
using System.Collections.Generic;
using System.Threading;

namespace NETPROJECT
{
	public class CommonUser : User
	{
		public override void EditOrder(int orderId) { }
		public override void RemoveOrder(int orderId) { }

		public override Order CreateOrder(DateTime timeOfCreation, int sellerId, uint watchCount, int categoryId,
			OrderInfo orderInfo)
		{
			Console.WriteLine("Створення замовлення для користвувача...");
			Thread.Sleep(1000);
			var order = new Order
			{
				CategoryId = categoryId,
				DateOfCreation = timeOfCreation,
				OrderInfo = orderInfo,
				SellerId = sellerId,
				WatchCount = watchCount
			};
			
			Console.WriteLine("Замовлення створено!\n");
			return order;
		}

		public CommonUser(int id, string nickname, DateTime registrationDate,
			double rating, string phone, string email, List<Order> orders,bool authorized) :
			base(id, nickname, registrationDate, rating, phone, email, orders,authorized)
		{ }

		public static CommonUser operator ++(CommonUser user)
		{
			Console.WriteLine("Викликаний унарний оператор інкременту для користувача");
			return new CommonUser(user)
			{
				Rating = user.Rating + 1
			};
		}
		

		public CommonUser(User copiedUser) : base(copiedUser)
        {
        }

        public CommonUser()
        {
        }
    }
}