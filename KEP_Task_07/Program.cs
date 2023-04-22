using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEP_Task_07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размерность массива: ");
            int size = Convert.ToInt32(Console.ReadLine());

            int[] numbers = new int[size]; 
            var rand = new Random();

            for (int i = 0; i < size; i++)
            {
                numbers[i] = rand.Next(0, 100);
                Console.Write(numbers[i]+" ");
            }

            var finiteMas = Shaffle(numbers);

            Console.WriteLine();

            for (int i = 0; i < size; i++)
            {
                Console.Write(finiteMas[i] + " ");
            }
            Console.ReadKey();
        }

        public static int[] Shaffle(int[] change)
        {
            var rand = new Random();
            for (int i = 0; i < 20; i++)
            {
                int index1 = rand.Next(0, change.Length);
                int index2 = rand.Next(0, change.Length);
                (change[index1], change[index2]) = (change[index2], change[index1]);
            }
            return change;
        }

    }
}
