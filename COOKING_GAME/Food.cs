using System;
namespace COOKING_GAME
{
	//abstract class iFood
	//{
	//	protected string Name { get; set; }
	//	protected int ShopCost { get; set; }
	//	protected int SellCost { get; set; } 
	//	//public int Starvation { get; set; }

	//}
	//class Doshirak : iFood
	//{
	//       Doshirak(string Name, int ShopCost, int SellCost = 0)
	//	{
	//		this.Name = Name;
	//		this.ShopCost = ShopCost;
	//		this.SellCost = SellCost;
	//	}
	//}
	//class Water : iFood
	//{
	//	Water(string Name, int ShopCost, int SellCost = 0)
	//	{
	//		this.Name = Name;
	//		this.ShopCost = ShopCost;
	//		this.SellCost = SellCost;
	//	}
	//}
	//class Bread : iFood
	//{
	//	Bread(string Name, int ShopCost, int SellCost = 0)
	//	{
	//           this.Name = Name;
	//		this.ShopCost = ShopCost;
	//		this.SellCost = SellCost;
	//	}
	//}
	class Food
	{
		public string Name;
		public int SellCost = 0;
		public int ShopCost;

		public Food(string Name, int ShopCost, int Sellcost = 0)
		{
            this.Name = Name;
			this.ShopCost = ShopCost;
			this.SellCost = SellCost;
		}
	}


}
