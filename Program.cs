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
            Console.ReadKey();
            

        }
    }
}
