using System;

namespace NETPROJECT
{
    public class Order
    {
	    public delegate void PrintHandler(string message);
	    public int Id { get; set; }
        public OrderInfo OrderInfo { get; set; }
        public int SellerId { get; set; }
        public int CategoryId { get; set; }

        public DateTime DateOfCreation { get; set; }
        public uint WatchCount { get; set; }

        public bool Watched => WatchCount != 0;

        
        public virtual void PrintOrder()
        {
	        PrintHandler handler = delegate(string message) 
		        { Console.WriteLine("Делегат класу замовлення викликаний з результатом: " + message); };
	        handler(ToString());
        }
        public virtual void AddDescription(string description)
        {
	        OrderInfo.Description = description;
	        Console.WriteLine("Order virtual method to add image");
        }

        public Order(int id, int orderInfoId, int sellerId, int categoryId,
            DateTime dateOfCreation, uint watchCount)
        {
            Id = id;
            OrderInfo = new OrderInfo(id,10,"name","something","url");
            SellerId = sellerId;
            CategoryId = categoryId;
            DateOfCreation = dateOfCreation;
            WatchCount = watchCount;

        }

        public static Order operator +(Order order1,Order order2)
        {
	        Console.WriteLine("Викликаний бінарний оператор додавання замовлення");
	        return new Order
	        {
		        Id = order1.Id,
		        SellerId = order1.Id,
		        WatchCount = order1.WatchCount + order2.WatchCount,
		        CategoryId = order1.CategoryId,
		        DateOfCreation = new DateTime(Math.Min(order1.DateOfCreation.Ticks, order2.DateOfCreation.Ticks)),
		        OrderInfo = order1.OrderInfo + order2.OrderInfo
	        };
        }

        public Order(Order order)
        {
            Id = order.Id;
            OrderInfo = new OrderInfo(order.OrderInfo);
            SellerId = order.SellerId;
            CategoryId = order.CategoryId;
            DateOfCreation = order.DateOfCreation;
            WatchCount = order.WatchCount;
        }

        public Order()
        {
            Id = 0;
            OrderInfo = new OrderInfo();
            SellerId = 0;
            CategoryId = 0;
            DateOfCreation = DateTime.Now;
            WatchCount = 0;
        }

        public OrderInfo GetOrderInfo() => new OrderInfo();

        public override string ToString()
        {
	        return "\nId: " +
	               Id +
	               "\nДата створення: " +
	               DateOfCreation +
	               "\nКількість переглядів: " +
	               WatchCount +
	               "\nНазва: " +
	               OrderInfo.Naming;
        }

    }
}