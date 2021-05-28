using System;
using System.Collections.Generic;
using System.Threading;

namespace NETPROJECT
{
    public class Administrator:User
    {
	    public delegate void MessageHandler(Administrator administrator,Order order);

	    private event MessageHandler _notifyUser;
	    public event MessageHandler NotifyUser
	    {
		    add
		    {
			    _notifyUser += value;
			    Console.WriteLine("Massage handler added;");
		    }
		    remove
		    {
			    _notifyUser -= value;
			    Console.WriteLine("Massage handler removed;");
		    }
	    }
	    
        public override void RemoveOrder(int orderId) { }
        public override void EditOrder(int orderId) { }

        public override Order CreateOrder(DateTime timeOfCreation, int sellerId, uint watchCount, int categoryId,
	        OrderInfo orderInfo)
        {
	        Console.WriteLine("Створення замовлення для адмiнiстратора...");
	        Thread.Sleep(2000);
	        var order = new Order
	        {
		        CategoryId = categoryId,
		        DateOfCreation = timeOfCreation,
		        OrderInfo = orderInfo,
		        SellerId = sellerId,
		        WatchCount = watchCount
	        };
	        Console.WriteLine("Замовлення створено!");
	        
	        return order;
        }


        public Administrator(int id, string nickname, DateTime registrationDate,
            double rating,string number,string email, List<Order> orders) :
            base(id, nickname, registrationDate, rating, number, email, orders,false)
        { }

        public Administrator(User copiedUser) : base(copiedUser)
        { }

        public Administrator()
        { }

        public void AcceptOrder(Order order)
        {
	        _notifyUser?.Invoke(this, order);
        }
        public void BAN(int userId,string banInfo) { }
        public void WarnUser(int userId, string warnMessage) { }
    }
}