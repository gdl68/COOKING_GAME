using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COOKING_GAME
{
    class SellFood
    {
        public static void Customer(ref stat stats)
        {
            Random WaitTime = new Random();
            Random CustomerType = new Random();

            Console.WriteLine("Вы ждете покупателя");
            System.Threading.Thread.Sleep(WaitTime.Next(3000, 8000));
            Console.Clear();
            switch (CustomerType.Next(1, 3))
            {
                case 1:
                    SeriousCustomer(ref stats);
                    break;
                case 2:
                    GoodCustomer(ref stats);
                    break;
                case 3:
                    BadCustomer(ref stats);
                    break;
            }
            Console.WriteLine("");

        }

        private static void BadCustomer(ref stat stats)
        {
            Random ThingChoice = new Random();
            int choice = 0;
            string ItemName = "";
            switch (ThingChoice.Next(1, 3))
            {
                case 1:
                    ItemName = "Доширак";
                    break;
                case 2:
                    ItemName = "Вода";
                    break;
                case 3:
                    ItemName = "Заваренный доширак";
                    break;


            }
            Console.WriteLine($"Здравствуйте, а можно поинтересоваться, сколько у вас стоит {ItemName}?");

        }

        private static void GoodCustomer(ref stat stats)
        {
           
        }

        private static void SeriousCustomer(ref stat stats)
        {
         
        }

        public static void Menu(ref stat stats)
        {
            char c;
            while (true)
            {
                var holodilnik = new StringBuilder();
                holodilnik.AppendLine("Ты пришел на рынок,");
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
                holodilnik.AppendLine("s. Ождиать покупателя");
                holodilnik.AppendLine("q. Идти домой");


                Console.WriteLine(holodilnik);
                c = Support.WaitChar();
                if (c == 'q')
                {
                    break;
                }
                else if (c == 's')
                {
                    Customer();
                }
            }
        }
    }
}
