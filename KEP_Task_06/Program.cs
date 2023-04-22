using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEP_Task_06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string FirstCommand = "1";
            const string SecondCommand = "2";
            const string ThirdCommand = "3";
            const string FourthCommand = "4";
            const string FifthCommand = "5";

            string[] posts = new string[0];
            string[] surnames = new string[0];
            string[] names = new string[0];
            string[] patronymics = new string[0];

            bool isExitProgram = true;

            while (isExitProgram)
            {
                Console.Clear();
                Console.WriteLine("Отдел кадров");
                Console.WriteLine($"{FirstCommand} - добавить досье");
                Console.WriteLine($"{SecondCommand} - вывести все досье");
                Console.WriteLine($"{ThirdCommand} - удалить досье");
                Console.WriteLine($"{FourthCommand} - поиск по фамилии");
                Console.WriteLine($"{FifthCommand} - выход из программы\n");

                Console.Write("Выберите пункт меню: ");
                switch (Console.ReadLine())
                {
                    case FirstCommand:
                        AddDossier(ref surnames, ref names, ref patronymics, ref posts);
                        break;

                    case SecondCommand:
                        OutputAllDossiers(surnames, names, patronymics, posts);
                        break;

                    case ThirdCommand:
                        DeleteDossier(ref surnames, ref names, ref patronymics, ref posts);
                        break;

                    case FourthCommand:
                        SearchDossier(surnames, names, patronymics, posts);
                        break;

                    case FifthCommand:
                        isExitProgram = false;
                        break;

                }

                Console.Write("\nНажмите любую клавишу...");
                Console.ReadKey();
            }
        }
        private static void AddDossier(ref string[] surnames, ref string[] names, ref string[] patronymics, ref string[] posts)
        {
            Console.WriteLine("Добавление досье:\n");
            Console.Write("Введите фамилию:");
            string surname = Console.ReadLine();
            Console.Write("Введите имя:");
            string name = Console.ReadLine();
            Console.Write("Введите отчество:");
            string patronymic = Console.ReadLine();
            Console.Write("Введите должность:");
            string post = Console.ReadLine();
            

            surnames = AddArrayDossier(surnames, surname);
            names = AddArrayDossier(names, name);
            patronymics = AddArrayDossier(patronymics, patronymic);
            posts = AddArrayDossier(posts, post);
            Console.WriteLine("\nДанные занесены успешно!\n");
        }

        private static string[] AddArrayDossier(string[] array, string text)
        {
            
            string[] additionalArray = new string[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
            {
                additionalArray[i] = array[i];
            }

            additionalArray[additionalArray.Length - 1] = text;
            array = additionalArray;
            return array;
        }

        private static void OutputAllDossiers(string[] surnames, string[] names, string[] patronymics, string[] posts)
        {
            Console.WriteLine("Вывод всех досье:\n");
            int index = 1;

            for (int i = 0; i < posts.Length; i++)
            {
                Console.WriteLine($"{index}    {surnames[i]} {names[i]} {patronymics[i]} - {posts[i]}");
                index++;
            }
        }

        private static void DeleteDossier(ref string[] surnames, ref string[] names, ref string[] patronymics, ref string[] posts)
        {
            Console.Write("Введите номер досье для удаления:");
            int number = int.Parse(Console.ReadLine());

            if (number > 0 && number <= surnames.Length && number <= names.Length && number <= patronymics.Length)
            {
                int index = number - 1;
                names = DeleteArrayDossier(names, index);
                surnames = DeleteArrayDossier(surnames, index);
                patronymics = DeleteArrayDossier(patronymics, index);
                posts = DeleteArrayDossier(posts, index);
                Console.WriteLine($"Досье удалено успешно!!!");
            }
            else
            {
                Console.WriteLine("Досье с таким номером не существует");
            }
        }
       
        private static string[] DeleteArrayDossier(string[] array, int index)
        {
            string[] additionalArray = new string[array.Length - 1];

            for (int i = 0; i < index; i++)
            {
                additionalArray[i] = array[i];
            }

            for (int i = index; i < array.Length - 1; i++)
            {
                additionalArray[i] = array[i + 1];
            }

            array = additionalArray;
            return array;
        }       

        private static void SearchDossier(string[] surnames, string[] names, string[] patronymics, string[] posts)
        {
            Console.WriteLine("Введите фамилию для поиска:");
            string surname = Console.ReadLine();
            bool successful = false;

            for (int i = 0; i < surnames.Length; i++)
            {
                string[] split = surnames[i].Split(' ');

                if (split[0].ToLower() == surname.ToLower())
                {
                    Console.WriteLine($"{i + 1}    {surnames[i]} {names[i]} {patronymics[i]} - {posts[i]}");
                    successful = true;
                }
            }

            if (successful == false)
            {
                Console.WriteLine($"Сотрудников с фамилией '{surname}' нет");
            }

            Console.WriteLine(new string('-', 40));
        }
    }
}