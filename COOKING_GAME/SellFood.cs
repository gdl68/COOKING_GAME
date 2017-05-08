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
            Console.WriteLine("К вам подошел покупатель");
            CustomeAppear(ref stats);
            

        }

        private static void CustomeAppear(ref stat stats)
        {
            Random ThingChoice = new Random();
            Random RealPriceRAN = new Random();
            int choice = 0;
            string ItemName = "";
            int ItemChoice = ThingChoice.Next(1, 3);
            int RealPrice = 0;
            switch (ItemChoice)
            {
                case 1:
                    ItemName = "Доширак";
                    RealPrice = RealPriceRAN.Next(19, 33);

                    break;
                case 2:
                    ItemName = "Вода 0.5";
                    RealPrice = RealPriceRAN.Next(7,14);
                    break;
                case 3:
                    ItemName = "Заваренный доширак";
                    RealPrice = RealPriceRAN.Next(20, 39);
                    break;
            }
            Console.WriteLine($"Здравствуйте, а можно поинтересоваться, сколько у вас стоит {ItemName}?");
            int Price;
            while (true)
            {
                try
                {
                    Price = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    continue;
                }
                Console.Clear();
                break;
            }

            char YesNo;
            if (Price > RealPrice)
            {
                while (true)
                {
                    Console.WriteLine($"Это слишком много, я возьму его у вас за {RealPrice} рублей, не больше");
                    Console.WriteLine($"Продать {ItemName} за {RealPrice} рублей?");
                    Console.WriteLine("y. Продать");
                    Console.WriteLine("n. Отказать");
                    YesNo = Support.WaitChar();
                    switch (YesNo)
                    {
                        case 'y':
                            if (ItemName == "Доширак")
                            {
                                if (stats.DoshirakAmount >= 1)
                                {
                                    stats.Money += RealPrice;
                                    stats.DoshirakAmount -= 1;
                                    Console.WriteLine($"Спасибо за {ItemName}, вот ваши {RealPrice} рублей.");
                                    Console.ReadKey();
                                    Menu(ref stats);
                                }
                                else
                                {
                                    Console.WriteLine("Ты не можешь продать то, чего у тебя нет");
                                    Console.ReadKey();
                                    Customer(ref stats);
                                }
                            }
                            if (ItemName == "Вода 0.5")
                            {
                                if (stats.WaterAmount >= 0.5)
                                {
                                    stats.Money += RealPrice;
                                    stats.WaterAmount -= 0.5;
                                    Console.WriteLine($"Спасибо за {ItemName}, вот ваши {RealPrice} рублей.");
                                    Console.ReadKey();
                                    Menu(ref stats);
                                }
                                else
                                {
                                    Console.WriteLine("Ты не можешь продать то, чего у тебя нет");
                                    Console.ReadKey();
                                    Customer(ref stats);
                                }
                            }
                            if (ItemName == "Заваренный доширак")
                            {
                                if (stats.HotDoshirakAmount >= 1)
                                {
                                    stats.Money += RealPrice;
                                    stats.HotDoshirakAmount -= 1;
                                    Console.WriteLine($"Спасибо за {ItemName}, вот ваши {RealPrice} рублей.");
                                    Console.ReadKey();
                                    Menu(ref stats);
                                }
                                else
                                {
                                    Console.WriteLine("Ты не можешь продать то, чего у тебя нет");
                                    Console.ReadKey();
                                    Customer(ref stats);
                                }
                            }
                            

                            break;
                        case 'n':
                            Console.WriteLine("Ну и ладно...");
                            Support.Wait();
                            Menu(ref stats);
                            break;
                    }
                    break;
                }
            }
            else
            {
                Console.WriteLine($"Я готов купить {ItemName} за {Price} рублей");
                Console.WriteLine($"Продать доширак за {RealPrice} рублей?");
                Console.WriteLine("y. Продать");
                Console.WriteLine("n. Отказать");
                YesNo = Support.WaitChar();
                switch (YesNo)
                {
                    case 'y':
                        if (ItemName == "Доширак")
                        {
                            if (stats.DoshirakAmount >= 1)
                            {
                                stats.Money += Price;
                                stats.DoshirakAmount -= 1;
                                Console.WriteLine($"Спасибо за {ItemName}, вот ваши {RealPrice} рублей.");
                                Console.ReadKey();
                                Menu(ref stats);
                            }
                            else
                            {
                                Console.WriteLine("Ты не можешь продать то, чего у тебя нет");
                                Console.ReadKey();
                                Customer(ref stats);
                            }
                        }
                        if (ItemName == "Вода 0.5")
                        {
                            if (stats.WaterAmount >= 0.5)
                            {
                                stats.Money += Price;
                                stats.WaterAmount -= 0.5;
                                Console.WriteLine($"Спасибо за {ItemName}, вот ваши {RealPrice} рублей.");
                                Console.ReadKey();
                                Menu(ref stats);
                            }
                            else
                            {
                                Console.WriteLine("Ты не можешь продать то, чего у тебя нет");
                                Console.ReadKey();
                                Customer(ref stats);
                            }
                        }
                        if (ItemName == "Заваренный доширак")
                        {
                            if (stats.HotDoshirakAmount >= 1)
                            {
                                stats.Money += Price;
                                stats.HotDoshirakAmount -= 1;
                                Console.WriteLine($"Спасибо за {ItemName}, вот ваши {RealPrice} рублей.");
                                Console.ReadKey();
                                Menu(ref stats);
                            }
                            else
                            {
                                Console.WriteLine("Ты не можешь продать то, чего у тебя нет");
                                Console.ReadKey();
                                Customer(ref stats);
                            }
                        }
                            break;



                            case 'n':
                        Console.WriteLine("Ну и ладно...");
                        Console.WriteLine("Покупатель ушел");
                        Support.Wait();
                        Menu(ref stats);
                        break;
                }
            } 
        }

        public static void Menu(ref stat stats)
        {
            char c;
            while (true)
            {
                var holodilnik = new StringBuilder();
                holodilnik.AppendLine("Ты на рынке,");
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
                    Customer(ref stats);
                }
            }
        }
    }
}
