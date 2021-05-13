using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Net.Mime;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace NETPROJECT
{
    public class Profile
    {
        public int Id { get; set; }
        public User User { get; set; }

        public string ImageUrl { get; set; }

        public List<Order> UserOrders { get; }

        public Profile(int id,User user,string imageUrl,List<Order> userOrders)
        {
            Id = id;
            User = user;
            ImageUrl = imageUrl;
            UserOrders = userOrders; 
        }

        public Profile(Profile profile)
        {
            Id = profile.Id;
            User = new CommonUser(profile.User);
            ImageUrl = profile.ImageUrl;
            UserOrders = profile.UserOrders;
        }

        public Profile()
        {
            Id = 0;
            User = new CommonUser();
            ImageUrl = "";
            UserOrders = new List<Order>();
        }
        
        

    }
}