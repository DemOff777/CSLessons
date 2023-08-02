using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Егоренков_Задание3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name;
            string zodiac;
            string age;
            string work;

            Console.Write("Ну заходи раз пришел, как тебя звать то ");
            name = Console.ReadLine();
            Console.Write("Ага, ну а сколько годков то тебе? ");
            age = Console.ReadLine();
            Console.Write("Погоди, а ты кем будешь то вообще? ");
            work = Console.ReadLine();
            Console.Write("Ну ладно, гороскоп то свой забыл наверное? ");
            zodiac = Console.ReadLine();
            Console.WriteLine($"Хорошо хорошо сейчас расскажу про тебя все - ясно вижу, что ты " +
                $"{name} и родился ты {age} лет назад, соответственно ты по гороскопу {zodiac} " +
                $"и быть тебе всю жизнь {work}");

        }
    }
}
