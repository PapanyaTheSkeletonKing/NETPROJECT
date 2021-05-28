using System;
using System.Globalization;
using System.Reflection;

namespace NETPROJECT
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Бригада №2");
            Console.WriteLine("Project theme: Платформа онлайн оголошень");
            Console.WriteLine("Учасники: \n" +
                              "1)Євгенiй Букур.\n" +
                              "2)Назар Ярощенко.\n" +
                              "3)Денис Восколуп.\n" +
                              "4)Вiталiй Жуковець.\n");
            OrderSystem system = new OrderSystem();
            UserService userService = new UserService(system);
            OrderService orderService = new OrderService(system);
            Administrator administrator = userService.GetAvailableAdministrator();
            Order order = system.Orders[0];
            User user = system.Users[0];
            
            userService.SendOrderToValidation(order);
            administrator.AcceptOrder(order);

            userService.PrintOrders(userService.GetUserOrders(user, ord => !ord.Watched));

            orderService.AddOrder(new Order());

            try
            {
	            PremiumOrder a = (PremiumOrder) new Order();
            }
            catch (Exception e)
            {
	            Console.WriteLine(e.Message);
            }
            
            Console.ReadKey();
            

        }
    }
}
