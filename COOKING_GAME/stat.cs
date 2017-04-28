using System;
namespace COOKING_GAME
{
	public class stat
	{
		public string Name { get; set; } //Just name
		public int Score { get; set; } //Just score
		public int Money = 100; //IN ROUBLES
		public int Time { get; set; } //IN HOURS
		public int Coolness { get; set; } //IN lv
 		public int Cooking { get; set; } //IN lv

		public bool Restaurant { get; set; } = false;
	

		public string msg { get; set; } //Just message

		public int FoodAmount { get; set; }
	
	
	}
}
