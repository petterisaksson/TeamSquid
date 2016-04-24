using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace YH_Admin.View
{
    public class ConsoleOutput
    {
        public delegate void DelHandle(string choice);
        public DelHandle ChoiceHandler { get; set; }

        public string Title { get; set; }
        
        public void ShowListAndWaitForChoice(string[] strList)
        {
            Console.Clear();
            ShowTitle();
            if (strList.Length > 1)
            {
                for (int i = 1; i < strList.Length; i++)
                {
                    Console.WriteLine($"{i}: {strList[i]}");
                }
            }
            else
            {
                Console.WriteLine("Hittar tyvärr inget i databasen.");
            }
            Console.WriteLine();
            Console.WriteLine($"x: {strList[0]}");
            Console.Write("Ditt val: ");
            var choice = Console.ReadLine();
            ChoiceHandler(choice);
        }

        public void ShowLogIn()
        {
            Console.Clear();
            ShowTitle();
            Console.Write("Username: ");
            var username = Console.ReadLine();
            Console.Write("Password: ");
            var password = Console.ReadLine();
            ChoiceHandler($"{username}\n{password}");
        }

        private void ShowTitle()
        {
            Console.WriteLine(Title);
            for (int i = 0; i < Title.Length; i++)
            {
                Console.Write("=");
            }
            Console.WriteLine("\n");
        }

    }
}
