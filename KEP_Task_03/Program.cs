using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEP_Task_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = "elvina";

            Console.WriteLine("Введите пароль: ");
            string attempt = Convert.ToString(Console.ReadLine());

            if(attempt == password)
            {
                Console.WriteLine("Cекретное сообщение: ты умница!");
            }
            else
            {
                Console.WriteLine("Пароль неверный. Введите пароль еще раз:");
                attempt = Convert.ToString(Console.ReadLine());
                if (attempt == password)
                {
                    Console.WriteLine("Cекретное сообщение: ты умница!");
                }
                else
                {
                    Console.WriteLine("Пароль неверный. Введите пароль еще раз:");
                    attempt = Convert.ToString(Console.ReadLine());
                    if (attempt == password)
                    {
                        Console.WriteLine("Cекретное сообщение: ты умница!");
                    }
                    else
                    {
                        Console.WriteLine("Пароль неверный. Введите пароль еще раз:");
                        attempt = Convert.ToString(Console.ReadLine());
                        if (attempt == password)
                        {
                            Console.WriteLine("Cекретное сообщение: ты умница!");
                        }
                        else
                        {
                            return;
                        }
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
