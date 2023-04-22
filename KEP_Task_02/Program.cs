using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEP_Task_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word;

            while(true)
            {
                Console.Write("Напишите что-нибудь: ");
                word = Console.ReadLine();

                if (word == "exit")
                {
                    break;
                }
            }
        }
    }
}
