using System;

namespace NETPROJECT
{
	public class PremiumOrder : Order
	{
		
		public PremiumOrder(int id, int orderInfoId, int sellerId, int categoryId,
			DateTime dateOfCreation, uint watchCount) : base(id, orderInfoId, sellerId, categoryId, dateOfCreation, watchCount)
		{
			Console.WriteLine();
		}
		
		public override void PrintOrder()
		{
			Console.ForegroundColor = ConsoleColor.Magenta;
			Console.WriteLine(ToString());
			Console.ForegroundColor = ConsoleColor.White;

		}

		public override void AddDescription(string description)
		{
			OrderInfo.Description = "VIP: " + description;
			Console.WriteLine("Premium order overriden method to add description");
		}
	}
}