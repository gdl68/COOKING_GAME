using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COOKING_GAME
{
    class Inventory
    {
        public static void Menu(ref stat stats)
        {
            char c;
            while (true)
            {
                var holodilnik = new StringBuilder();
                holodilnik.AppendLine("Вот что у тебя в холодильнике");
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
                holodilnik.AppendLine("d. Выкинуть продукты");
                holodilnik.AppendLine("h. Почитать справку");

                Console.WriteLine(holodilnik);
                c = Support.WaitChar();
                if (c == 'q')
                {
                    break;
                }
                else
                {
                    Check(c, ref stats);
                }
            }
        }


        public static void Check(char gen, ref stat stats)
        {
            switch (gen)
            {
                case 'h':
                    Console.WriteLine("Вы сейчас смотрите в свой холодильник.\n" +
                    "Вы можете выкинуть определённые продукты нажав d \n" +
                    "Чтобы из него выйти, нажмите q");
                    Support.Wait();
                    break;

                case 'd':
                    //HERE
                    DropFood(ref stats);
                    break;
            }
        }

        public static void DropFood(ref stat stats)
        {
            char c;
            while (true)
            {
                var holodilnik = new StringBuilder();
                holodilnik.AppendLine("Вот что у тебя в холодильнике");
                holodilnik.AppendLine("+--------------------+");

                //PUT ANOTHER FOOD AMOUNT HERE
                //
                //FOOD LIKE THAT holodilnik.AppendLine($"1. Вода: {stats.WaterAmount} л");
                //
                holodilnik.AppendLine($"1. Вода: {stats.WaterAmount} л");
                holodilnik.AppendLine($"2. Доширак: {stats.DoshirakAmount} шт.");
                holodilnik.AppendLine("+--------------------+");

                //ACTIONS
                holodilnik.AppendLine("q. Выйти из меню выбрасывания");
                holodilnik.AppendLine("r. Выбрать предмет для выбрасывания");


                Console.WriteLine(holodilnik);
                c = Support.WaitChar();
                if (c == 'q')
                {
                    break;
                }
                else if (c == 'r')
                {
                    DelFood(ref stats);
                }
                else
                {
                    continue;
                }



            }
        }

        public static void DelFood(ref stat stats)
        {
            int delnum;
            while (true)
            {
                var holodilnik = new StringBuilder();
                holodilnik.AppendLine("Вот что у тебя в холодильнике");
                holodilnik.AppendLine("+--------------------+");

                //PUT ANOTHER FOOD AMOUNT HERE
                //
                //FOOD LIKE THAT holodilnik.AppendLine($"1. Вода: {stats.WaterAmount} л");
                //
                if (stats.WaterAmount != 0) { holodilnik.AppendLine($"Вода: {stats.WaterAmount} л"); }
                if (stats.DoshirakAmount != 0) { holodilnik.AppendLine($"Доширак: {stats.DoshirakAmount} шт."); }
                if (stats.HotDoshirakAmount != 0) { holodilnik.AppendLine($"Заваренный доширак: {stats.HotDoshirakAmount} шт."); }




                holodilnik.AppendLine("+--------------------+");
                holodilnik.AppendLine("Введите номер предмета, который хотите выбросить");
                Console.WriteLine(holodilnik);
                //ITEM NUMBER

                try
                {
                    delnum = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.Clear();
                    continue;
                }
            }
            Console.Clear();

            //ITEM NUMBER END
            double DelAmount;
            switch (delnum)
            {
                case 1:
                    DelAmount = HowMuch(stats);

                    if (DelAmount <= stats.WaterAmount)
                    {
                        Console.WriteLine($"Ты выкинул {DelAmount} л воды");
                        stats.WaterAmount -= DelAmount;
                        Support.Wait();

                    }
                    else
                    {
                        Console.WriteLine("Ты не можешь выкинуть больше, чем у тебя есть!");
                        Support.Wait();

                    }
                    DropFood(ref stats);
                    break;
                case 2:
                    DelAmount = HowMuch(stats);

                    if (DelAmount <= stats.DoshirakAmount)
                    {
                        Console.WriteLine($"Ты выкинул {DelAmount} дошираков");
                        stats.DoshirakAmount -= DelAmount;
                        Support.Wait();
                    }
                    else
                    {
                        Console.WriteLine("Ты не можешь выкинуть больше, чем у тебя есть!");
                        Support.Wait();

                    }
                    DropFood(ref stats);
                    break;


                default:
                    Console.WriteLine("Упс, такого продукта не существует");
                    Support.Wait();
                    DropFood(ref stats);
                    break;

            }

           
        }

        public static int HowMuch(stat stats)
        {
            int c;
            while (true)
            {
                var holodilnik = new StringBuilder();
            holodilnik.AppendLine("Вот что у тебя в холодильнике");
            holodilnik.AppendLine("+--------------------+");

            //PUT ANOTHER FOOD AMOUNT HERE
            //
            //FOOD LIKE THAT holodilnik.AppendLine($"1. Вода: {stats.WaterAmount} л");
            //
            holodilnik.AppendLine($"1. Вода: {stats.WaterAmount} л");
            holodilnik.AppendLine($"2. Доширак: {stats.DoshirakAmount} шт.");
            holodilnik.AppendLine("+--------------------+");
            Console.WriteLine(holodilnik);

            Console.WriteLine("Сколько вы хотите выбросить?");
            
                try
                {
                    c = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.Clear();
                    continue;
                }  
            }
            Console.Clear();
            return c;
         } 
    }
}
