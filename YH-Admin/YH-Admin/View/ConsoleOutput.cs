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

        public Stack<string> Titles { get; set; }

        public string Message { get; set; }

        public ConsoleOutput()
        {
            Titles = new Stack<string>();
        }

        public void ShowTableAndWaitForChoice(string[,] content, bool choosable = true, bool isMainMenu = false, string cursorStr = "Ditt val")
        {
            Console.Clear();
            ShowTitle();
            var lengths = ColumnLengths(content);
            string seperator = new String('-', lengths.Sum() + 7);
            var numRows = content.GetLength(0);
            if (numRows < 2)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Finns inget i databasen");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("[Alt.] ");
                var numCols = content.GetLength(1);
                for (int j = 0; j < numCols; j++)
                {
                    SetColor(j);
                    Console.Write(content[0, j].PadRight(lengths[j]));
                }
                Console.Write("\n");
                Console.ResetColor();
                Console.WriteLine(seperator);

                for (int i = 1; i < numRows; i++)
                {
                    if (choosable)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"[{i}]".PadRight(7));
                    }
                    else
                    {
                        Console.Write(" ".PadRight(7));
                    }
                    for (int j = 0; j < numCols; j++)
                    {
                        SetColor(j);
                        var str = content[i, j] ?? "+";
                        Console.Write(str.PadRight(lengths[j]));
                    }
                    Console.Write("\n");
                }
            }
            Console.ResetColor();
            Console.WriteLine(seperator);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[x]".PadRight(7));
            Console.ForegroundColor = ConsoleColor.DarkRed;
            if (isMainMenu)
                Console.WriteLine("Avsluta");
            else
                Console.WriteLine("Tillbaka");
            if (isMainMenu)
            {
                
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("[h]".PadRight(7));
                Console.ForegroundColor = ConsoleColor.DarkRed; ;
                Console.WriteLine("Huvudmeny");
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine(Message);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{cursorStr}> ");
            var choice = Console.ReadLine();
            Console.ResetColor();
            ChoiceHandler(choice);
        }

        public void SetColor(int num)
        {
            if (num % 2 == 0)
                Console.ForegroundColor = ConsoleColor.DarkCyan;
            else
                Console.ForegroundColor = ConsoleColor.DarkGray;
        }

        public void ShowLogIn()
        {
            Console.Clear();
            ShowTitle();
            Console.Write("Användarnamn: ");
            var username = Console.ReadLine();
            Console.Write("Lösenord: ");
            var password = Console.ReadLine();
            ChoiceHandler($"{username}\n{password}");
        }

        public void ShowAddStudent(string[] classList)
        {
            Console.Clear();
            ShowTitle();
            Console.Write("Förnman: ");
            var firstname = Console.ReadLine();
            Console.Write("Efternamn: ");
            var lastname = Console.ReadLine();
            Console.Write($"Klass [{String.Join(", ", classList)}]: ");
            var answer = Console.ReadLine();
            if (firstname.Length > 0 && lastname.Length > 0 && classList.Contains(answer))
                ChoiceHandler($"{firstname}\n{lastname}\n{answer}");
            else
                ShowAddStudent(classList);
        }

        private void ShowTitle()
        {
            var title = Titles.Peek();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(title + "\n");
            Console.ResetColor();
        }

        public int[] ColumnLengths(string[,] content)
        {
            int[] lengths = new int[content.GetLength(1)];
            for (int j = 0; j < content.GetLength(1); j++)
            {
                for (int i = 0; i < content.GetLength(0); i++)
                {
                    if (content[i, j] != null && content[i, j].Length > lengths[j])
                        lengths[j] = content[i, j].Length;
                }
                lengths[j]++; // Space between columns
                //Console.WriteLine($"{j}: {lengths[j]}");
            }

            return lengths;
        }

        internal void ShowAddStaff()
        {
            Console.Clear();
            ShowTitle();
            Console.Write("Förnman: ");
            var firstname = Console.ReadLine();
            Console.Write("Efternamn: ");
            var lastname = Console.ReadLine();

            if (firstname.Length > 0 && lastname.Length > 0)
                ChoiceHandler($"{firstname}\n{lastname}");
            else
                ChoiceHandler("x");
        }
    }
}
