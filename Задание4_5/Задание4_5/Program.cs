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

            int firstNumber = 0;
            int lastNumber = 20;

            int[] numbers = new int[arraySize];

            Random random = new Random();

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(firstNumber, lastNumber);
            }

            foreach(int symbol in numbers) 
            {
                Console.Write(symbol + " ");
            }

            numbers = SortArrayRandom(numbers);
            Console.WriteLine();

            foreach (int symbol in numbers)
            {
                Console.Write(symbol + " ");
            }
        }

        static int[] SortArrayRandom(int[] symbols)
        {
            int temporaryArrayMember;
            int temporaryNumber;

            Random random = new Random();

            for (int i = 0; i < symbols.Length; i++)
            {
                temporaryArrayMember = random.Next(symbols.Length);
                temporaryNumber = symbols[temporaryArrayMember];
                symbols[temporaryArrayMember] = symbols[i];
                symbols[i] = temporaryNumber;
            }
           
            return symbols;
        }
    }
}
