using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEP_Task_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool enoughGold;
            Console.WriteLine("Вы пришли в магазин купить кристаллы. " +
                "Введите количество золота в вашем кошельке: ");

            int myGold = Convert.ToInt32(Console.ReadLine());
            int cristal = 3;

            Console.WriteLine("Цена одного кристалла равна 3 золота");
            Console.WriteLine("Сколько кристаллов вы хотите купить?");

            int cristalCount = int.Parse(Console.ReadLine());
            enoughGold = myGold >= cristalCount * cristal;
            cristalCount *= Convert.ToInt32(enoughGold);
            myGold -= cristalCount * cristal;

            Console.WriteLine($"У вас осталось золота {myGold} и кристаллов {cristalCount}");     
            Console.ReadKey();           
        }
    }
}
