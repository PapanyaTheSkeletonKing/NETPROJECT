using System;
using System.Collections.Generic;

namespace NETPROJECT
{
    public class OrderSystem
    {
        public List<Profile> Profiles { get; set; } = new List<Profile>();

        public List<User> Users { get; set; } = new List<User>();
        public List<Administrator> Administrators { get; set; } = new List<Administrator>();
        public List<Category> Categories { get; set; } = new List<Category>();
        public List<Order> Orders { get; set; } = new List<Order>();

        public OrderSystem()
        {
            InitData();
        }
        
        private void InitData()
        {
            InitCategories();
            InitOrders();
            InitProfiles();
        }
        
        private void InitCategories()
        {
            Category category1 = new Category(0,1,"Goods",Orders);
            
            
            Categories.Add(category1);
            

            Categories.Add(new Category
            {
	            Id = 1,
	            Name = "Apples",
	            ParentCategory = category1,
	            ParentCategoryId = category1.Id,
	            SubCategoryId = 2 
            });

            category1.SubCategory = Categories[1];
            
            Categories.Add(new Category
            {
	            Id = 2,
	            Name = "Groceries",
	            ParentCategoryId = 1,
	            ParentCategory = Categories[1],
	            SubCategory = new Category(),
	            SubCategoryId = 3
            });
            Categories[1].SubCategory = Categories[2];
        }
        
        private void InitProfiles()
        {
            User user1 = new CommonUser(0,"X",DateTime.Now,5,
                "+380*********","@gmail",Orders,true);
            Users.Add(user1);
            Profile prof1 = new Profile(0, user1, "url", Orders);
            Administrator user2 = new Administrator(1,"Ozon",DateTime.Now,4.5,
	            "+380*********","@gmail",new List<Order>());
            Administrators.Add(user2);

            Profile prof2 = new Profile(1, user2, "url1", Orders);
            
            Profiles.Add(prof1);
            prof1.User.Nickname = "12";
            prof1.User.Nickname = "Sephiroth";
            prof1.User.Nickname = "Sdsdsdsdsdssdsdsdsdsdsdsdssdsd";
            
            Profiles.Add(new Profile(prof1));
            
            Profiles.Add(new Profile());
            user1.CreateOrder(DateTime.Now,
	            user1.Id,
	            0,
	            0,
	            new OrderInfo {Description = "order", ImageUrl = "url", Naming = "Apples", Price = 100, Validated = false});
            user2.CreateOrder(DateTime.Now,
	            user2.Id,
	            0,
	            1,
	            new OrderInfo {Description = "order1", ImageUrl = "image", Naming = "Telephone", Price = 5000, Validated = false});


        }

        private void InitOrders()
        {
	        Order order1 = new Order(0, 0, 0, 0, DateTime.Now, 2)
	        {
		        OrderInfo = new OrderInfo(0, 100, "first order", "desc", "url")
	        };
	        PremiumOrder prmOrder  = new PremiumOrder(1, 0, 0, 0, DateTime.Today, 5)
	        {
		        OrderInfo = new OrderInfo(1, 200, "second order", "", "url")
	        };

	        Orders.Add(order1);
            
            Orders.Add(new Order
            {
	            Id = 1,
	            CategoryId = 1,
	            DateOfCreation = DateTime.Now - new TimeSpan(0,1,3,0),
	            OrderInfo = new OrderInfo(1,2,"3","dsds","url"),
	            SellerId = 0,
	            WatchCount = 0 
            });
        }
        
        
    }
}