using System;
namespace COOKING_GAME
{
	class Quit
	{
		public static void Exit()
		{
            while (true)
            {
                char c = Support.WaitChar();
                Console.WriteLine("Хочешь выйти? y/n");
                switch (c)
                {
                    case 'y':
                        Console.WriteLine("До скорых встреч!\n" +
                                          "Нажмите любую клавишу для выхода...");
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;
                    case 'n':
                        break;
                }
                if (c == 'n')
                {
                    break;
                }
            }
		}
	}
}