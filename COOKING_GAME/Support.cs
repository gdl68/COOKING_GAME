using System;
using System.Text;
namespace COOKING_GAME
{
	public class Support
	{
		public static void Way(ref stat stats)
		{
			stats.Time++;
			Random i = new Random();
			int y = i.Next(1, 10);
					System.Threading.Thread.Sleep(3000);
			
			if (y == 1)
			{
				Console.Clear();
				Console.WriteLine("По пути вы встречаете красивого кота");
				System.Threading.Thread.Sleep(1000);
				Console.WriteLine("Смотря на это милое создание, вы не можете упустить возможность погладить его");
				Console.WriteLine("Нажмите любую клавишу чтобы погладить");
				Wait();
				Console.WriteLine("Вы гладите кота");
				Wait();
				Console.WriteLine("Пока вы гладили кота, его кошка взяла у вас из кармана 10 рублей (-10 рублей)");
				stats.Money -= 10;
			}

					System.Threading.Thread.Sleep(3000);
			Console.Clear();	
		}
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




		public static void GetStats(ref stat stat)
		{
			if (stat.Cooking >= 2 && stat.FirstLevelUpMsgCheck == 0)
				{
					stat.msg = "You improved your cooking skills! (+1000 Score)";
					stat.Score += 1000;
					stat.FirstLevelUpMsgCheck++;
				}
				else if (stat.Cooking >= 2)
				{
					stat.FirstLevelUpMsgCheck++;
				}
				else
				{
					stat.msg = "";
				}
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
			StatsOut.AppendLine($"Имя: {stat.Name}");
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

		public static void General_check(char gen,ref stat stats)
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
					Console.WriteLine("Вы идете в магазин");

					Way(ref stats);

					Shop.Menu(ref stats.Money, ref stats);
					break;

					//Inventory
                case 't':
                    Inventory.Menu(ref stats);
                    break;

					case 'w':
					Cook.Menu(ref stats);
					break;
				
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
				GetStats(ref stat);
				char General = WaitChar();
				General_check(General,ref stat);
				if (stat.Cooking >= 2 && stat.FirstLevelUpMsgCheck == 0)
				{
					stat.msg = "Вы улучшили свои навыки готовки (+1000 очков)";
					stat.Score += 1000;
					stat.FirstLevelUpMsgCheck++;
				}
				else
				{
					stat.msg = "";
				}
			}
		}

	}
}

