using System;
using System.Text;

namespace COOKING_GAME
{
	class Cook
	{
		public static void Menu(ref stat stats)
		{
			char c;
			while (true)
			{
				var holodilnik = new StringBuilder();
				holodilnik.AppendLine("Ты пришел на кухню,");
				holodilnik.AppendLine("Вот что у тебя есть");
				holodilnik.AppendLine("+--------------------+");
				holodilnik.AppendLine("");



				//PUT ANOTHER FOOD AMOUNT HERE
				if (stats.WaterAmount != 0) { holodilnik.AppendLine($"Вода: {stats.WaterAmount} л"); }
				if (stats.DoshirakAmount != 0) { holodilnik.AppendLine($"Доширак: {stats.DoshirakAmount} шт."); }
				if (stats.HotDoshirakAmount != 0) { holodilnik.AppendLine($"Заваренный доширак: {stats.HotDoshirakAmount} шт."); }





				holodilnik.AppendLine("");
				holodilnik.AppendLine("+--------------------+");


				//Here goes actions
				holodilnik.AppendLine("q. Выйти из холодильника");
				holodilnik.AppendLine("d. Открыть меню готовки");
				holodilnik.AppendLine("h. Почитать справку");

				Console.WriteLine(holodilnik);
				c = Support.WaitChar();
				if (c == 'q')
				{
					break;
				}
				switch (c)
				{
					case 'h':
						{
							Console.WriteLine("Ты пришел на кухню, место где ты можешь сделать еду из еды\n" +
											  "q. - выход в главное меню\n" +
											  "d. - начать готовить\n" +
											  "h. - вызвать справку\n");
							Support.Wait();
							break;
						}

					case 'd':
						{
							Cook.Start(ref stats);
							break;
						}
				}





			}
		}

		public static void Start(ref stat stats)
		{
			char c;

			int p = 0;
			while (true)
			{
				var holodilnik = new StringBuilder();
				if (p == 0)
				{
					holodilnik.AppendLine("Вы чувствуете, что готовы создать шедевр");
				}
				else
				{
					holodilnik.AppendLine("Вы готовы сделать еду");
				}


				holodilnik.AppendLine("Вот что у тебя есть");
				holodilnik.AppendLine("+--------------------+");
				holodilnik.AppendLine("");



				//PUT ANOTHER FOOD AMOUNT HERE
				if (stats.WaterAmount != 0) { holodilnik.AppendLine($"Вода: {stats.WaterAmount} л"); }
				if (stats.DoshirakAmount != 0) { holodilnik.AppendLine($"Доширак: {stats.DoshirakAmount} шт."); }
				if (stats.HotDoshirakAmount != 0) { holodilnik.AppendLine($"Заваренный доширак: {stats.HotDoshirakAmount} шт."); }





				holodilnik.AppendLine("");
				holodilnik.AppendLine("+--------------------+");


				//Here goes actions
				if (p == 0)
				{
					holodilnik.AppendLine("q. Отказаться от создания шедевра ");
					p++;
				}
				else
				{
					holodilnik.AppendLine("q. Выйти из меню готовки ");
				}
					
				holodilnik.AppendLine("a. Заварить доширак. (-0.5 л воды, -1 Доширак)");

				Console.WriteLine(holodilnik);
				c = Support.WaitChar();
				if (c == 'q')
				{
					break;
				}
				switch (c)
				{
					case 'a':
						if (stats.WaterAmount >= 0.5 && stats.DoshirakAmount >= 1)
						{

							Random i = new Random();
							int k = 0;

							stats.WaterAmount -= 0.5;
							stats.DoshirakAmount -= 1;



							if (stats.WaterAmount > 0.5)
							{
								if (stats.Cooking == 1)
								{
									int y = i.Next(1, 2);
									if (y == 1)
									{

										Console.WriteLine("Из-за своей неопытности вы пролили воду (-0.5л воды)\n" +
										                  "Вам приходится усердно вытерать пол целый час для того чтобы он стал сухим.");
										stats.Time++;
										stats.WaterAmount -= 0.5;
										k++;

									}
								}
								else if (stats.Cooking > 1)
								{
									int y = i.Next(1, 4);
									if (y == 1)
									{

										Console.WriteLine("Вы чуть было не пролили воду, но из-за жизненного опыта вы избежали этой ситуации (+100 Очков, + 1 Крутости) ");
										stats.Coolness++;
										stats.Score += 100;
										k++;

									}
								}
								System.Threading.Thread.Sleep(2000);
							}

							if (k == 0)
							{
								Console.WriteLine("Вы заварили Доширак (+1 Заваренный доширак)");

							}
							else
							{
								Console.WriteLine("Вам все же удалось заварить доширак (+1 Заваренный доширак)");
							}
							Console.WriteLine("Вы чувствуете как пространство наполняется запахом доширака.");
							if (stats.FirstLevelUpMsgCheck == 0)
							{
								stats.Cooking++;

							}
							stats.HotDoshirakAmount++;
							stats.FoodAmount++;
							stats.Time++;
							Support.Wait();

						}
						break;
				}
			}
		}
	}
}