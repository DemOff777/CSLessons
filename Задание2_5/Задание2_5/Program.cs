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
            string currencyToConvert = "";
            string currencyDesired = "";
            string currencyRub = "rub";
            string currencyUsd = "usd";
            string currencyKzt = "kzt";
            string exit = "exit";
            float rubAmount = 100000;
            float usdAmount = 500;
            float kztAmount = 200000;
            float amountToConvert;
            float rubToUsd = 96.5f;
            float rubToKzt = 0.2177f;
            float usdToRub = 0.0107f;
            float usdToKzt = 0.0022f;
            float kztToUsd = 453.9f;
            float kztToRub = 4.7778f;

            
            while (currencyToConvert != exit)
            {
                Console.WriteLine("Ваш баланс:");
                Console.WriteLine($"{rubAmount} рублей");
                Console.WriteLine($"{usdAmount} долларов");
                Console.WriteLine($"{kztAmount} тенге");
                Console.WriteLine();
                Console.WriteLine("Введите валюту для обмена:");
                Console.WriteLine("rub-рубли");
                Console.WriteLine("usd-доллары");
                Console.WriteLine("kzt-тенге");
                currencyToConvert = Console.ReadLine();

                while (currencyToConvert == currencyRub)
                {
                    Console.WriteLine("Введите валюту на которую вы хотите совершить обмен:");
                    Console.WriteLine("usd-доллары");
                    Console.WriteLine("kzt-тенге");
                    currencyDesired = Console.ReadLine();

                    while (currencyDesired == currencyUsd)
                    {
                        Console.WriteLine("Введите сумму в рублях для обмена:");
                        amountToConvert = Convert.ToSingle(Console.ReadLine());

                        if (amountToConvert <= rubAmount)
                        {
                            rubAmount -= amountToConvert;
                            usdAmount += amountToConvert / rubToUsd;
                            Console.WriteLine();
                            break;
                        }

                        if (amountToConvert > rubAmount)
                        {
                            Console.WriteLine("Недоcтаточно средств.");
                            Console.WriteLine();
                        }

                    }

                    while (currencyDesired == currencyKzt)
                    {
                        Console.WriteLine("Введите сумму в рублях для обмена:");
                        amountToConvert = Convert.ToSingle(Console.ReadLine());

                        if (amountToConvert <= rubAmount)
                        {
                            rubAmount -= amountToConvert;
                            kztAmount += amountToConvert / rubToKzt;
                            Console.WriteLine();
                            break;
                        }

                        if (amountToConvert > rubAmount)
                        {
                            Console.WriteLine("Недоcтаточно средств.");
                            Console.WriteLine();
                        }

                    }

                    if (currencyDesired == currencyUsd || currencyDesired == currencyKzt || currencyDesired == exit)
                    {
                        break;
                    }

                    if (currencyDesired != currencyUsd && currencyDesired != currencyKzt && currencyDesired != exit)
                    {
                        Console.WriteLine("Недопустимое значение.");
                        Console.WriteLine();
                    }
                }

                while (currencyToConvert == currencyUsd)
                {
                    Console.WriteLine("Введите валюту на которую вы хотите совершить обмен:");
                    Console.WriteLine("rub-рубли");
                    Console.WriteLine("kzt-тенге");
                    currencyDesired = Console.ReadLine();

                    while (currencyDesired == currencyRub)
                    {
                        Console.WriteLine("Введите сумму в долларах для обмена:");
                        amountToConvert = Convert.ToSingle(Console.ReadLine());

                        if (amountToConvert <= usdAmount)
                        {
                            usdAmount -= amountToConvert;
                            rubAmount += amountToConvert / usdToRub;
                            Console.WriteLine();
                            break;
                        }

                        if (amountToConvert > usdAmount)
                        {
                            Console.WriteLine("Недоcтаточно средств.");
                            Console.WriteLine();
                        }

                    }

                    while (currencyDesired == currencyKzt)
                    {
                        Console.WriteLine("Введите сумму в долларах для обмена:");
                        amountToConvert = Convert.ToSingle(Console.ReadLine());

                        if (amountToConvert <= usdAmount)
                        {
                            usdAmount -= amountToConvert;
                            kztAmount += amountToConvert / usdToKzt;
                            Console.WriteLine();
                            break;
                        }

                        if (amountToConvert > usdAmount)
                        {
                            Console.WriteLine("Недоcтаточно средств.");
                            Console.WriteLine();
                        }
                    }

                    if (currencyDesired == currencyRub || currencyDesired == currencyKzt || currencyDesired == exit)
                    {
                        break;
                    }

                    if (currencyDesired != currencyRub && currencyDesired != currencyKzt && currencyDesired != exit)
                    {
                        Console.WriteLine("Недопустимое значение.");
                        Console.WriteLine();
                    }
                }

                while (currencyToConvert == currencyKzt)
                {
                    Console.WriteLine("Введите валюту на которую вы хотите совершить обмен:");
                    Console.WriteLine("usd-доллары");
                    Console.WriteLine("rub-рубли");
                    currencyDesired = Console.ReadLine();

                    while (currencyDesired == currencyUsd)
                    {
                        Console.WriteLine("Введите сумму в тенге для обмена:");
                        amountToConvert = Convert.ToSingle(Console.ReadLine());

                        if (amountToConvert <= kztAmount)
                        {
                            kztAmount -= amountToConvert;
                            usdAmount += amountToConvert / kztToUsd;
                            Console.WriteLine();
                            break;
                        }

                        if (amountToConvert > kztAmount)
                        {
                            Console.WriteLine("Недоcтаточно средств.");
                            Console.WriteLine();
                        }
                    }

                    while (currencyDesired == currencyRub)
                    {
                        Console.WriteLine("Введите сумму в тенге для обмена:");
                        amountToConvert = Convert.ToSingle(Console.ReadLine());

                        if (amountToConvert <= kztAmount)
                        {
                            kztAmount -= amountToConvert;
                            rubAmount += amountToConvert / kztToRub;
                            Console.WriteLine();
                            break;
                        }

                        if (amountToConvert > kztAmount)
                        {
                            Console.WriteLine("Недоcтаточно средств.");
                            Console.WriteLine();
                        }
                    }

                    if (currencyDesired == currencyUsd || currencyDesired == currencyRub || currencyDesired == exit)
                    {
                        break;
                    }

                    if (currencyDesired != currencyUsd && currencyDesired != currencyRub && currencyDesired != exit)
                    {
                        Console.WriteLine("Недопустимое значение.");
                        Console.WriteLine();
                    }
                }

                if (currencyToConvert == exit || currencyDesired == exit)
                {
                    break;
                }

                if (currencyToConvert != currencyRub && currencyToConvert != currencyUsd && currencyToConvert != currencyKzt && currencyToConvert != exit)
                {
                    Console.WriteLine("Недопустимое значение.");
                    Console.WriteLine();
                }

            }
        }
    }
}
