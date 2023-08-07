using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание2_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float rub = 100000;
            float usd = 500;
            float kzt = 200000;
            float amountToConvert;
            string currencyToConvert;
            string currencyDesired;
            float rubToUsd = 96.5f;
            float rubToKzt = 0.2177f;
            float usdToRub = 0.0107f;
            float usdToKzt = 0.0022f;
            float kztToUsd = 453.9f;
            float kztToRub = 4.7778f;
            

            while (true)
            {
                Console.WriteLine("Ваш баланс:");
                Console.WriteLine($"{rub} рублей");
                Console.WriteLine($"{usd} долларов");
                Console.WriteLine($"{kzt} тенге");
                Console.WriteLine();
                Console.WriteLine("Введите валюту для обмена:");
                Console.WriteLine("rub-рубли");
                Console.WriteLine("usd-доллары");
                Console.WriteLine("kzt-тенге");
                currencyToConvert = Console.ReadLine();

                    if(currencyToConvert == "rub")
                    {
                        while (true)
                        {
                            Console.WriteLine("Введите валюту на которую вы хотите совершить обмен:");
                            Console.WriteLine("usd-доллары");
                            Console.WriteLine("kzt-тенге");
                            currencyDesired = Console.ReadLine();

                            if (currencyDesired == "usd")
                            {
                                while (true)
                                {
                                    Console.WriteLine("Введите сумму в рублях для обмена:");
                                    amountToConvert = Convert.ToSingle(Console.ReadLine());

                                    if (amountToConvert <= rub)
                                    {
                                        rub -= amountToConvert;
                                        usd += amountToConvert / rubToUsd;
                                        Console.WriteLine();
                                        break;
                                    }

                                    if (amountToConvert > rub)
                                    {
                                        Console.WriteLine("Недоcтаточно средств.");
                                        Console.WriteLine();
                                    }

                                }
                            }
                            if (currencyDesired == "kzt")
                            {
                                while (true)
                                {
                                    Console.WriteLine("Введите сумму в рублях для обмена:");
                                    amountToConvert = Convert.ToSingle(Console.ReadLine());

                                    if (amountToConvert <= rub)
                                    {
                                        rub -= amountToConvert;
                                        kzt += amountToConvert / rubToKzt;
                                        Console.WriteLine();
                                        break;
                                    }

                                    if (amountToConvert > rub)
                                    {
                                        Console.WriteLine("Недоcтаточно средств.");
                                        Console.WriteLine();
                                    }

                                }
                            }

                        if (currencyDesired == "exit")
                        {
                            break;
                        }

                        if (currencyDesired != "usd" && currencyDesired != "kzt" && currencyDesired != "exit")
                        {
                            Console.WriteLine("Недопустимое значение.");
                            Console.WriteLine();
                        }
                            break;
                        }
                    }

                    if(currencyToConvert == "usd")
                    {
                        while (true)
                        {
                            Console.WriteLine("Введите валюту на которую вы хотите совершить обмен:");
                            Console.WriteLine("rub-рубли");
                            Console.WriteLine("kzt-тенге");
                            currencyDesired = Console.ReadLine();

                            if (currencyDesired == "rub")
                            {
                                while (true)
                                {
                                    Console.WriteLine("Введите сумму в долларах для обмена:");
                                    amountToConvert = Convert.ToSingle(Console.ReadLine());

                                    if (amountToConvert <= usd)
                                    {
                                        usd -= amountToConvert;
                                        rub += amountToConvert / usdToRub;
                                        Console.WriteLine();
                                        break;
                                    }

                                    if (amountToConvert > usd)
                                    {
                                        Console.WriteLine("Недоcтаточно средств.");
                                        Console.WriteLine();
                                    }

                                }
                            }
                            if (currencyDesired == "kzt")
                            {
                                while (true)
                                {
                                    Console.WriteLine("Введите сумму в долларах для обмена:");
                                    amountToConvert = Convert.ToSingle(Console.ReadLine());

                                    if (amountToConvert <= usd)
                                    {
                                        usd -= amountToConvert;
                                        kzt += amountToConvert / usdToKzt;
                                        Console.WriteLine();
                                        break;
                                    }

                                    if (amountToConvert > usd)
                                    {
                                        Console.WriteLine("Недоcтаточно средств.");
                                        Console.WriteLine();
                                    }

                                }
                            }

                        if (currencyDesired == "exit")
                        {
                            break;
                        }

                        if (currencyDesired != "rub" && currencyDesired != "kzt" && currencyDesired != "exit")
                        {
                            Console.WriteLine("Недопустимое значение.");
                            Console.WriteLine();
                        }
                            break;
                        }
                    }

                    if(currencyToConvert == "kzt")
                    {
                        while (true)
                        {
                            Console.WriteLine("Введите валюту на которую вы хотите совершить обмен:");
                            Console.WriteLine("usd-доллары");
                            Console.WriteLine("rub-рубли");
                            currencyDesired = Console.ReadLine();

                            if (currencyDesired == "usd")
                            {
                                while (true)
                                {
                                    Console.WriteLine("Введите сумму в тенге для обмена:");
                                    amountToConvert = Convert.ToSingle(Console.ReadLine());

                                    if (amountToConvert <= kzt)
                                    {
                                        kzt -= amountToConvert;
                                        usd += amountToConvert / kztToUsd;
                                        Console.WriteLine();
                                        break;
                                    }

                                    if (amountToConvert > kzt)
                                    {
                                        Console.WriteLine("Недоcтаточно средств.");
                                        Console.WriteLine();
                                    }

                                }
                            }
                            if (currencyDesired == "rub")
                            {
                                while (true)
                                {
                                    Console.WriteLine("Введите сумму в тенге для обмена:");
                                    amountToConvert = Convert.ToSingle(Console.ReadLine());

                                    if (amountToConvert <= kzt)
                                    {
                                        kzt -= amountToConvert;
                                        rub += amountToConvert / kztToRub;
                                        Console.WriteLine();
                                        break;
                                    }

                                    if (amountToConvert > kzt)
                                    {
                                        Console.WriteLine("Недоcтаточно средств.");
                                        Console.WriteLine();
                                    }

                                }
                            }

                        if (currencyDesired == "exit")
                        {
                            break;
                        }

                        if (currencyDesired != "usd" && currencyDesired != "rub" && currencyDesired != "exit")
                        {
                            Console.WriteLine("Недопустимое значение.");
                            Console.WriteLine();
                        }
                            break;
                        }
                    }
                    if (currencyToConvert == "exit")
                    {
                        break;
                    }

                    if (currencyToConvert != "rub" && currencyToConvert != "usd" && currencyToConvert != "kzt" && currencyToConvert != "exit")
                    {
                            Console.WriteLine("Недопустимое значение.");
                            Console.WriteLine();
                    }
                    
                
            }
        }
    }
}
