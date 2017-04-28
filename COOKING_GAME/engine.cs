using System;
using System.Collections.Generic;
namespace COOKING_GAME
{
	class MainClass
	{
		public static void Main()
		{
			Console.Title = "Дошимперия";
			stat config = new stat();
			Shop Shop = new Shop();
			int i = 0; //Game parametres from config
			Console.WriteLine("Добро пожаловать в игру про готовку, вы начинающий повар и вам каким то образом необходимо\n" +
							  "прожить на свои 100 рублей. Зарабатывайте деньги продавая готовую еду, развивайте свои навыки\n" +
							  "покупая кулинарные книги за деньги, зарабатывайте деньги, и кто знает, может в один день вам\n" +
							  "удастся открыть свой ресторан?\nНажми любую клавишу как будешь готов.");
			Support.Wait();
			

			while (i == 0)
			{
				Console.WriteLine("Начать игру? y/n");
				switch (Support.WaitChar())
				{
					case 'y':
						i++;
						break;
					case 'n':
						break;
				}
			}
			Console.Clear();

			//
			// MAIN GAME START
			//

			//
			//NAME OF USER
			//
			Console.WriteLine("Как тебя зовут?");
			config.Name = Console.ReadLine();
			Console.Clear();
			Console.WriteLine("Привет, " + config.Name);
			System.Threading.Thread.Sleep(1000);
			Console.Clear();
			//
			//NAME OF USER END
			//
			Support.Main_act(ref config);

			Console.ReadKey();



		}
	}
}
