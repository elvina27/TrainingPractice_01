using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEP_Task_04
{
    internal class Program
    {
        private static int studentSkills = 360;
        private static int remandSkills = 420;

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Вы – студент ПКГХ и у вас в арсенале есть несколько заклинаний,\n" +
                             "которые вы можете использовать против ОТЧИСЛЕНИЯ. \n" +
                             "Вы должны избежать ОТЧИСЛЕНИЯ и только после этого будет вам покой.\n");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Заклинания для студента:\n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Доклад ");
            Console.ResetColor();
            Console.Write("- атака, может наносить урон ровно 80 единиц\n\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Участие в конференции ");
            Console.ResetColor();
            Console.Write("- тратится 20 единиц здоровья на фоне стресса. Но вы имеете возможность атаковать ОТЧИСЛЕНИЕ\n" +
                             "и отнять от 50 до 180 едениц здоровья. Четко не ясно, насколько сильно может задеть ОТЧИСЛЕНИЕ ваш урон\n" +
                             "ведь в нашей игре мы не знаем, на какую именно конференцию отправился студент:)\n\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Больничный ");
            Console.ResetColor();
            Console.Write("- тратится 60 единиц здоровья, но после каждый ход добавляет 20 единиц\n" +
                             "Отчисление не может наносить удары по студенту,который ушел на больничный\n" +
                             "На больничном нельзя учавствовать в конференции,ведь если студент пропустит много пар, то\n" +
                             "может не успеть закрыть все долги и ОТЧИСЛЕНИЕ настигнет его в конце концов.\n" +
                             "Из больничного нельзя атаковать ОТЧИСЛЕНИЕ\n\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Возвращение с больничного ");
            Console.ResetColor();
            Console.Write("- студент снова имеет возможность атаковать ОТЧИСЛЕНИЕ\n\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Вовремя сделанная работа ");
            Console.ResetColor();
            Console.Write("- длительное восстановление.\n" +
                            "Тратится 50 единиц здоровья,но следующие 5 игровых тактов восстанавливается по 40 единиц здоровья за такт.\n\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Начальное значение здоровья у игрока -  360 единиц\n" +
                "Начальное значение здоровья у БОССА - 420 единиц\n\n");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Выберите заклинание (введите номер):\n\n");
            Console.ResetColor();
            Console.WriteLine("1. Напасть на ОТЧИСЛЕНИЕ заклинанием \"Доклад\"\n");
            Console.WriteLine("2. Использовать заклинание \"Участие в конференции\"\n");
            Console.WriteLine("3. Использовать заклинание \"Больничный\"\n");
            Console.WriteLine("4. Вернуться из портала с помощью заклинания \"Возвращение с больничного\"\n");
            Console.WriteLine("5. Использовать заклинание \"Вовремя сделанная работа\"\n");

            int selectedSpell = int.Parse(Console.ReadLine());
            bool isOnSickLeave = false;
            bool canCastSpells = true;
            Random random = new Random();
            int turnCount = 1;            

            while (studentSkills >= 0 && remandSkills >= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nИгровой такт № " + turnCount);
                Console.ResetColor();
                turnCount++;

                if (selectedSpell == 1)
                {
                    if (!canCastSpells)
                    {
                        Console.WriteLine("Вы не можете использовать это заклинание в данный момент.\n");
                        studentSkills += 20;
                        Console.WriteLine("Осталось здоровья у студента - " + studentSkills + " единиц");
                        Console.WriteLine("Осталось здоровья у ОТЧИСЛЕНИЯ - " + remandSkills + " единиц\n");
                    }
                    if (canCastSpells)
                    {
                        Console.WriteLine("Игрок напал на ОТЧИСЛЕНИЕ заклинанием \"Доклад\"");
                        Console.WriteLine("Ничего не произошло, но вы получили знания и опыт");
                        remandSkills -= 80;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Осталось здоровья у студента - " + studentSkills + " единиц");
                        Console.WriteLine("Осталось здоровья у ОТЧИСЛЕНИЯ - " + remandSkills + " единиц\n");
                        Console.ResetColor();
                    }
                }
                else if (selectedSpell == 2)
                {
                    if (!canCastSpells)
                    {
                        Console.WriteLine("Вы не можете использовать это заклинание в данный момент.\n");
                        studentSkills += 20;
                        Console.WriteLine("Осталось здоровья у студента - " + studentSkills + " единиц");
                        Console.WriteLine("Осталось здоровья у ОТЧИСЛЕНИЯ - " + remandSkills + " единиц\n");
                    }
                    if (canCastSpells) { 
                        int damage = random.Next(50, 180);
                    Console.WriteLine("Игрок использует заклинание \"Участие в конференции\"");
                    Console.WriteLine("Вы получили знания и опыт, но вы не контролируете силу удара по ОТЧИСЛЕНИЮ");
                    remandSkills -= damage;
                    studentSkills -= 20;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Осталось здоровья у студента - " + studentSkills + " единиц");
                    Console.WriteLine("Осталось здоровья у ОТЧИСЛЕНИЯ - " + remandSkills + " единиц\n");
                        Console.ResetColor();
                    }
                }

                else if (selectedSpell == 3)
                {
                    if (!canCastSpells)
                    {
                        Console.WriteLine("Вы не можете использовать это заклинание в данный момент.\n");
                        studentSkills += 20;
                        Console.WriteLine("Осталось здоровья у студента - " + studentSkills + " единиц");
                        Console.WriteLine("Осталось здоровья у ОТЧИСЛЕНИЯ - " + remandSkills + " единиц\n");
                    }
                    if (canCastSpells)
                    {
                        Console.WriteLine("Игрок использует заклинание \"Больничный\"");
                        Console.WriteLine("Вы получаете немного отдыха, но теряете здоровье. В свою очередь ОТЧИСЛЕНИЕ " +
                            "не имеет возможности атаковать вас, ведь у вас есть справка");
                        studentSkills -= 60;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Осталось здоровья у студента - " + studentSkills + " единиц");
                        Console.WriteLine("Осталось здоровья у ОТЧИСЛЕНИЯ - " + remandSkills + " единиц\n");
                        Console.ResetColor();
                        canCastSpells = false;
                        isOnSickLeave = true;
                    }
                }

                else if (selectedSpell == 4)
                {                    
                    Console.WriteLine("Вы вернулись с больничного!");
                }

                else if (selectedSpell == 5)
                {
                    if (!canCastSpells)
                    {
                        Console.WriteLine("Вы не можете использовать это заклинание в данный момент.\n");
                        studentSkills += 20;
                        Console.WriteLine("Осталось здоровья у студента - " + studentSkills + " единиц");
                        Console.WriteLine("Осталось здоровья у ОТЧИСЛЕНИЯ - " + remandSkills + " единиц\n");
                    }
                    if (canCastSpells)
                    {
                        Console.WriteLine("Игрок использует заклинание \"Вовремя сделанная работа\"");
                        Console.WriteLine("Вы успешно справились с заданием, за что следующие 5 хода имеете + 40 едениц здоровья");
                        studentSkills -= 50;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Осталось здоровья у студента - " + studentSkills + " единиц");
                        Console.WriteLine("Осталось здоровья у ОТЧИСЛЕНИЯ - " + remandSkills + " единиц\n");
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод! Попробуйте еще раз");
                }
                
                // ОТЧИСЛЕНИЕ атакует студента
                if (!isOnSickLeave && (remandSkills >= 0 && studentSkills >= 0))
                {
                    int damage = random.Next(30, 100);
                    Console.WriteLine("ОТЧИСЛЕНИЕ атакует студента заклинанием \"Неудачный экзамен\"");
                    Console.WriteLine("Вам нанесен урон в размере " + damage + " единиц");
                    studentSkills -= damage;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Осталось здоровья у студента - " + studentSkills + " единиц");
                    Console.WriteLine("Осталось здоровья у ОТЧИСЛЕНИЯ - " + remandSkills + " единиц");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("ОТЧИСЛЕНИЕ не может атаковать вас, ведь у вас есть справка");
                    Console.ResetColor();
                    if (selectedSpell == 4)
                    {
                        isOnSickLeave = false;
                        Console.WriteLine("Вы вернулись из больничного, но силы еще не полностью восстановлены");
                        studentSkills -= 10;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Осталось здоровья у студента - " + studentSkills + " единиц");
                        Console.WriteLine("Осталось здоровья у ОТЧИСЛЕНИЯ - " + remandSkills + " единиц");
                        Console.ResetColor();
                        canCastSpells = true;
                    }
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.ResetColor();
                Console.WriteLine("\nВыберите заклинание (введите номер):\n\n");
                Console.WriteLine("1. Напасть на ОТЧИСЛЕНИЕ заклинанием \"Доклад\"");
                Console.WriteLine("2. Использовать заклинание \"Участие в конференции\"");
                Console.WriteLine("3. Использовать заклинание \"Больничный\"");
                Console.WriteLine("4. Вернуться из ,больничного с помощью заклинания \"Возвращение с больничного\"");
                Console.WriteLine("5. Использовать заклинание \"Вовремя сделанная работа\"");
                Console.WriteLine("0. Выйти из игры");

                selectedSpell = int.Parse(Console.ReadLine());

                if (selectedSpell == 0 && (remandSkills <= 0 && studentSkills <= 0))
                {
                    Console.WriteLine("Игра завершена. Спасибо за игру!");
                    Console.ReadKey();
                }                
            }
        }
    }
}

