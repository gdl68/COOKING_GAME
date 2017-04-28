using System;
using System.Text;
namespace COOKING_GAME
{
	public class Support
	{
		public static char WaitChar()
		{
			char c = (Console.ReadKey()).KeyChar;
			Console.Clear();
			return c;
		}
		public static void Wait()
		{
			Console.ReadKey();
			Console.Clear();
		}


		public static void GetStats(stat stat)
		{
			int hours;
			int days = stat.Time / 24;
			try
			{
				hours = stat.Time % (days * 24);
			}
			catch (System.DivideByZeroException)
			{
				hours = 0;
			}
				var StatsOut = new StringBuilder();

			//STATS
			StatsOut.AppendLine("+--------------------+");
			StatsOut.AppendLine($"Ты живешь: {days} дней и {hours} часов");
			StatsOut.AppendLine($"Ваш баланс: {stat.Money} рублей");
			StatsOut.AppendLine($"Уровень крутости: {stat.Coolness} lv");
			StatsOut.AppendLine($"Уровень готовки: {stat.Cooking} lv");
			StatsOut.AppendLine($"Очки: {stat.Score}");
			StatsOut.AppendLine($"+--------------------+");
			StatsOut.AppendLine($"{stat.msg}");
			StatsOut.AppendLine($"+--------------------+");
			//STATS end


			//here starts Actions
			StatsOut.AppendLine($"b. В магазин");
			StatsOut.AppendLine($"t. В холодильник");
			StatsOut.AppendLine($"w. На кухню");
			if (stat.Restaurant == true)
			{
				StatsOut.AppendLine($"r. Отправиться в ресторан");
			}
			StatsOut.AppendLine($"q. Выйти из игры");
			StatsOut.ToString();
			Console.WriteLine(StatsOut);
		}

		public static void General_check(char gen,stat stats)
		{
			char c;
			switch (gen)
			{                   //ADD MORE CASES HERE ON EVERY ACTION

                //EXIT
				case 'q':

					while (true)
					{
						Console.WriteLine("Хотите выйти? y/n");
						c = WaitChar();
						if (c == 'y')
						{
							Console.Write("До скорой встречи!\n" +
										  "Press any key to exit...");
							Console.ReadKey();
							Environment.Exit(0);
						}
						else if (c == 'n')
						{
							break;
						}

						else
						{
							continue;
						}
					}
					break;
				
				
				
				//SHOP
				case 'b':
					Shop.Menu(ref stats.Money, ref stats);
					break;


                case 't':
                    Inventory.ShowInventory(ref stats);
                    break;
					
					
				
				
				
				
				//INSTANT EXIT IF SOMETHING WRONG DAFUK
				
			}
			Main_act(ref stats);
		}





		public static void Main_act(ref stat stat)
		{
			while (true)
			{
				//
				//PUT SPECIAL EVENTS HERE
				//
				GetStats(stat);
				char General = WaitChar();
				General_check(General, stat);
			}
		}

	}
}

