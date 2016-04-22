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
        
        public void ShowListAndWaitForChoice(string[] strList)
        {
            Console.Clear();
            for (int i = 1; i < strList.Length; i++)
            {
                Console.WriteLine($"{i}: {strList[i]}");
            }
            Console.WriteLine();
            Console.WriteLine($"x: {strList[0]}");
            Console.Write("Your choice: ");
            var choice = Console.ReadLine();
            ChoiceHandler(choice);
        }




    }
}
