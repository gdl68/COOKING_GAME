using System;
using System.Collections.Generic;
using System.Text;
namespace COOKING_GAME
{
	public class Shop
	{
		public static void buy_food(ref int Money, int Cost, string Name )
		{
					if (Money < Cost)
					{
						Console.WriteLine($"Недостаточно денег ({Money} рублей)");
					}
					else
					{
						Money -= Cost;
						Console.WriteLine($"Ты купил {Name} за {Cost} рублей.");
						Console.WriteLine($"У тебя осталось {Money} рублей.");
					}
		}
		
		public static void Menu(ref int Money, ref stat stats)
		{
			char c;
			List<Food> FoodList = new List<Food>();
			Food Doshirak = new Food("Доширак", 25);
			Food WaterHalf = new Food("Вода 0.5л", 10);
			FoodList.Add(Doshirak);
			FoodList.Add(WaterHalf);

			while (true)
			{
				int i = 1;
				Console.WriteLine("+--------------------+");
				Console.WriteLine("Вот что есть в Пятёрочке");
				Console.WriteLine("+--------------------+");
				var foodline = new StringBuilder();
				foreach (Food item in FoodList)
				{
					foodline.Append($"{i}. {item.Name}, стоит {item.ShopCost} рублей\n");
					i++;
				}
				Console.WriteLine(foodline);
				Console.WriteLine("+--------------------+");
				Console.WriteLine("q. Выйти из магазина");
				Console.WriteLine("h. Почитать справку");
				c = Support.WaitChar();
				if (c == 'h')
				{
					Console.WriteLine("Магазин - место где можно купить продукты. \n" +
					                  "Покупай продукты, нажимая на клавиатуре номер продукта.");
					Support.Wait();
				}
				if (c == 'q')
				{
					break;
				}
				Check(ref Money, c,ref stats);

			}
		}
		public static void Check(ref int Money, char gen, ref stat stats)
		{
			switch (gen)
			{
				case '1':
					buy_food(ref Money, 25, "Доширак");
                    stats.DoshirakAmount++;
					Support.Wait();
					break;
				
				
				
				case '2':
					buy_food(ref Money, 10, "Воду 0.5л");
                    stats.WaterAmount += 0.5;
					Support.Wait();
					break;
			}
		}
	}
}
