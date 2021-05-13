using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.VisualBasic;

namespace NETPROJECT
{
    public abstract class User
    {
        public int Id { get; set; }

        public string Nickname
        {
	        get;
	        set;
        }

        public DateTime RegistrationDate { get; set; }
        public double Rating { get; set; }

        public static bool operator ==(User u1, User u2) =>
	        u1.Id == u2.Id;
        

        public static bool operator !=(User u1, User u2)
        {
	        return !(u1 == u2);
        }

        public static User operator !(User user)
        {
	        Console.WriteLine("Викликаний унарний оператор ! для користувача");
	        return new CommonUser(user)
	        {
		        Authorized = false
	        };
        }
        
        
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public bool Authorized { get; set; }

        public User(int id, string nickname,
            DateTime registrationDate, double rating,
            string number,string emailAddress,List<Order> orders,bool authorized)
        {
            Id = id;
            Nickname = nickname;
            RegistrationDate = registrationDate;
            Rating = rating;
            PhoneNumber = number;
            EmailAddress = emailAddress;
            Orders = orders;
            Authorized = authorized;
        }

        public User(User copiedUser)
        {
            Id = copiedUser.Id;
            Nickname = copiedUser.Nickname;
            RegistrationDate = copiedUser.RegistrationDate;
            Rating = copiedUser.Rating;
            PhoneNumber = copiedUser.PhoneNumber;
            EmailAddress = copiedUser.EmailAddress;
            Orders = copiedUser.Orders;
        }
        
        public User()
        {
            Id = 0;
            Nickname = "";
            RegistrationDate = DateTime.Now;
            Rating = 0;
            PhoneNumber = "";
            EmailAddress = "";
            Orders = new List<Order>();
        }
        
        public List<Order> Orders { get; set; }

        public List<Order> GetOrders()
        {
            return Orders;
        }
        


        public void SelectCategory(int categoryId) { }
        public abstract void RemoveOrder(int orderId);
        public abstract void EditOrder(int orderId);
        public abstract Order CreateOrder(DateTime timeOfCreation, int sellerId, uint watchCount, int categoryId,OrderInfo orderInfo);

        public override string ToString()
        {
	        return "\nId: " +
	               Id +
	               "\nIм'я користувача: " +
	               Nickname +
	               "\nРейтинг: " +
	               Rating +
	               "\nАвторизований: " +
				Authorized;
        }
        
    }
}