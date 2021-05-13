using System;

namespace NETPROJECT
{
    public class UserContactInfo
    {
        public int Id { get; set; }
        

        public UserContactInfo(int id, string phoneNumber, string emailAddress)
        {
            Id = id;
            PhoneNumber = phoneNumber;
            EmailAddress = emailAddress;
            Console.WriteLine("User constructor with parameters loaded;"); 
        }
        public UserContactInfo(UserContactInfo userContactInfo)
        {
            Id = userContactInfo.Id;
            PhoneNumber = userContactInfo.PhoneNumber;
            EmailAddress = userContactInfo.EmailAddress;
            Console.WriteLine("User copy constructor loaded;"); 
        }

        public UserContactInfo()
        {
            Id = 0;
            PhoneNumber = "";
            EmailAddress = "";
            Console.WriteLine("User default constructor loaded;"); 
        }
    }
}