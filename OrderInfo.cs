using System;
using System.Collections.Generic;

namespace NETPROJECT
{
    public class OrderInfo
    {
        public int Id { get; set; }
        public bool Validated { get; set; }
        public double Price { get; set; }
        public string Naming { get; set; }

        public string Description { get; set; }
        public string ImageUrl { get; set; }
        
        public static OrderInfo operator +(OrderInfo orderInfo1,OrderInfo orderInfo2)
        {
	        Console.WriteLine("Викликаний бінарний оператор додавання інформації про замовлення");
	        return new OrderInfo
	        {
		        Id = orderInfo1.Id,
		        Naming = orderInfo1.Naming + orderInfo2.Naming,
		        Description = orderInfo1.Description + "\n" + orderInfo2.Description,
		        ImageUrl = orderInfo1.ImageUrl,
		        Price = orderInfo1.Price + orderInfo2.Price
	        };
        }

        public static bool operator &(OrderInfo orderInfo1,OrderInfo orderInfo2)
        {
	        Console.WriteLine("Викликаний бiнарний логiчний оператор && для iнформації про замовлення");
	        return orderInfo1 == orderInfo2;
        }
        
        public OrderInfo(int id,double price,string name,string description,string imageUrl)
        {
            Id = id;
            Price = price;
            Naming = name;
            Description = description;
            ImageUrl = imageUrl;
        }

        public OrderInfo(OrderInfo orderInfo)
        {
            Id = orderInfo.Id;
            Price = orderInfo.Price;
            Naming = orderInfo.Naming;
            Description = orderInfo.Naming;
            ImageUrl = orderInfo.ImageUrl;
        }

        public OrderInfo()
        {
            Id = 0;
            Price = 0;
            Naming = "";
            Description = Description;
            ImageUrl = "";
        }

        public override string ToString()
        {
	        return "\nId: " +
	               Id +
	               "\nPrice: " +
	               Price +
	               "\nTitle: " +
	               Naming +
	               "\nDescription: " +
	               Description;
        }

    }
}