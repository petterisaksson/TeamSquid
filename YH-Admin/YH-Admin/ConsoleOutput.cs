using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YH_Admin
{
    class ConsoleOutput
    {
        public void Menu()
        {
            Console.WriteLine("1. Utbildning\n 2. Klasser\n 3. Kurser \n 4. Undervisare\n 5. Studerande\n");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1": Console.WriteLine("Utbildningar");
                    break;
                case "2": Console.WriteLine("Klasser");
                    break;
                case "3": Console.WriteLine("Kurser");
                    break;
                case "4": Console.WriteLine("Undervisare");
                    break;
                case "5": Console.WriteLine("Studerande");
                    break;
            }
        }
    }
}
