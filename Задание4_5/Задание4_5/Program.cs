using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание4_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int arraySize = 10;

            char firstSymbol = '!';
            char lastSymbol = '?';

            string[] symbols = new string[arraySize];

            Random random = new Random();

            for (int i = 0; i < symbols.Length; i++)
            {
                symbols[i] = Convert.ToString(Convert.ToChar(random.Next(firstSymbol, lastSymbol)));
            }

            foreach(string symbol in symbols) 
            {
                Console.Write(symbol + " ");
            }

            symbols = SortingArrayRandom(symbols);
            Console.WriteLine();

            foreach (string symbol in symbols)
            {
                Console.Write(symbol + " ");
            }
        }

        static string[] SortingArrayRandom(string[] symbols)
        {
            int temporaryArrayMember;

            string temporaryChar;

            string[] newSymbols = new string[symbols.Length];

            Random random = new Random();

            for (int i = 0; i < newSymbols.Length; i++)
            {
                string[] temporarySymbols = new string[symbols.Length - 1];

                temporaryArrayMember = random.Next(symbols.Length);
                temporaryChar = symbols[temporaryArrayMember];
                newSymbols[i] = temporaryChar;

                for (int j = 0; j < temporaryArrayMember; j++)
                {
                    temporarySymbols[j] = symbols[j];
                }

                for (int k = temporaryArrayMember + 1; k < symbols.Length; k++)
                {
                    temporarySymbols[k - 1] = symbols[k];
                }

                symbols = temporarySymbols;
            }

            symbols = newSymbols;

            return newSymbols;
        }
    }
}
