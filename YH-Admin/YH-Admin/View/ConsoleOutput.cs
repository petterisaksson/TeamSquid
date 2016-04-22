using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace YH_Admin
{
    public class ConsoleOutput
    {
        public delegate void DelMenu();

        public void Menu()
        {
            Console.Clear();
            Console.WriteLine(" 1. Utbildning\n 2. Klasser\n 3. Kurser \n 4. Undervisare\n 5. Studerande\n");
            string input = Console.ReadLine();

            Console.Clear();

            DelMenu thisMenu = Menu;

            switch (input)
            {
                case "1":
                    Console.WriteLine("Utbildningar");
                    break;
                case "2":
                    ShowClassMenu(thisMenu);
                    break;
                case "3":
                    Console.WriteLine("Kurser");
                    break;
                case "4":
                    Console.WriteLine("Undervisare");
                    break;
                case "5":
                    ShowStudentMenu(thisMenu);
                    break;
                case "q":
                    return;
                default:
                    Menu();
                    break;
            }
        }
        
        public void ShowClassMenu(DelMenu goBack)
        {
            Console.Clear();
            Console.WriteLine("Class Meny");
            Console.WriteLine();
            Console.WriteLine("Press any key to go back...");
            Console.ReadLine();
            goBack();
        }

        public void ShowStudentMenu(DelMenu goBack)
        {
            Console.Clear();
            Console.WriteLine("Student Meny\n\n");
            Console.WriteLine("Välj följande:");
            Console.WriteLine(" 1. Lista alla studerande i en viss klass.");
            Console.WriteLine("Press any key to go back...");
            Console.ReadLine();
            goBack();
        }

        public void ShowList(string heading, string[] strList)
        {
            Console.WriteLine(heading + "\n");
            foreach (var str in strList)
            {
                Console.WriteLine(str);
            }
            
            
        }



    }
}
