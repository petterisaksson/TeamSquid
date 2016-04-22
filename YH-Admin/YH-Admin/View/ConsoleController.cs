using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH_Admin.Model;

namespace YH_Admin.View
{
    class ConsoleController
    {
        School Model { get; set; }
        ConsoleOutput View { get; set; }

        public ConsoleController(School school, ConsoleOutput output)
        {
            Model = school;
            View = output;
        }

        public void ShowMainMenu()
        {
            string[] alts = { "Exit", "Utbildning", "Klasser", "Kurser", "Undervisare", "Studerande" };
            View.ChoiceHandler = HandleMainMenuChoice;
        }

        public void HandleMainMenuChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Utbildningar");
                    break;
                case "2":
                    ShowClassMenu();
                    break;
                case "3":
                    Console.WriteLine("Kurser");
                    break;
                case "4":
                    Console.WriteLine("Undervisare");
                    break;
                case "5":
                    ShowStudentMenu();
                    break;
                case "x":
                    return;
                default:
                    ShowMainMenu();
                    break;
            }
        }

        public void ShowClassMenu()
        {

        }

        public void ShowStudentMenu()
        {

        }


    }
}
