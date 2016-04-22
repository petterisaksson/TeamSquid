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

        public delegate void DelMenu();
        DelMenu PreviousMenu { get; set; }

        List<SchoolClass> CurrentClasses { get; set; }

        List<Student> CurrentStudents { get; set; }

        /// <summary>
        /// Constructor to set up Model and View.
        /// </summary>
        /// <param name="school"></param>
        /// <param name="output"></param>
        public ConsoleController(School school, ConsoleOutput output)
        {
            Model = school;
            View = output;
        }

        /// <summary>
        /// Show the main menu.
        /// </summary>
        public void ShowMainMenu()
        {
            string[] alts = { "Avsluta", "Utbildning", "Klasser", "Kurser", "Undervisare", "Studerande", "Betyg" };
            View.ChoiceHandler = HandleMainMenuChoice;
            View.ShowListAndWaitForChoice(alts);
        }

        /// <summary>
        /// Handle the choices from the main menu.
        /// </summary>
        /// <param name="choice"></param>
        private void HandleMainMenuChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Utbildningar - ej implementerat");
                    break;
                case "2":
                    ShowClassMenu();
                    break;
                case "3":
                    Console.WriteLine("Kurser - ej implementerat");
                    break;
                case "4":
                    Console.WriteLine("Undervisare - ej implementerat");
                    break;
                case "5":
                    ShowStudentMenu();
                    break;
                case "6":
                    Console.WriteLine("Betyg - ej implementerat");
                    break;
                case "x":
                    return;
                default:
                    ShowMainMenu();
                    break;
            }
        }

        private void ShowClassMenu()
        {
            PreviousMenu = ShowMainMenu;
            string[] alts = { "Tillbaka", "Visa klasser i en viss utbildning" };
            View.ChoiceHandler = HandleClassMenu;
            View.ShowListAndWaitForChoice(alts);
        }

        private void HandleClassMenu(string choice)
        {
            if (choice.Equals("x"))
            {
                PreviousMenu();
                return;
            }
            int index;
            if (int.TryParse(choice, out index))
            {
                if (index > 0 /*&& index <= CurrentClasses.Count*/)
                {
                    PreviousMenu = ShowClassMenu;
                    // TODO : Get classes from an education.
                    CurrentClasses = new List<SchoolClass>();
                    ShowCurrentClasses();
                    return;
                }
            }
            ShowClassMenu();

        }


        private void ShowStudentMenu()
        {
            PreviousMenu = ShowMainMenu;
            string[] alts = { "Tillbaka", "Visa studerande i en viss klass" };
            View.ChoiceHandler = HandleStudentMenuChoice;
            View.ShowListAndWaitForChoice(alts);
        }

        private void HandleStudentMenuChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    PreviousMenu = ShowStudentMenu;
                    CurrentClasses = Model.SchoolClasses;
                    ShowCurrentClasses();
                    break;
                case "x":
                    PreviousMenu();
                    break;
                default:
                    ShowStudentMenu();
                    break;
            }
        }

        private void ShowCurrentClasses()
        {
            string[] alts = new string[CurrentClasses.Count + 1];
            alts[0] = "Tillbaka";
            for (int i = 0; i < CurrentClasses.Count; i++)
            {
                alts[i + 1] = CurrentClasses[i].ShowClassStatus();
            }
            View.ChoiceHandler = HandleShowCurrentClasses;
            View.ShowListAndWaitForChoice(alts);
        }

        private void HandleShowCurrentClasses(string choice)
        {
            if (choice.Equals("x"))
            {
                PreviousMenu();
                return;
            }
            int index;
            if (int.TryParse(choice, out index))
            {
                if (index > 0 && index <= CurrentClasses.Count)
                {
                    CurrentStudents = Model.GetStudents(CurrentClasses[index - 1]);
                    ShowCurrentStudents();
                    return;
                }
            }
            ShowCurrentClasses();
        }


        private void ShowCurrentStudents()
        {
            string[] strs = new string[CurrentStudents.Count + 1];
            strs[0] = "Tillbaka";
            for (int i = 0; i < CurrentStudents.Count; i++)
            {
                strs[i + 1] = CurrentStudents[i].Name;
            }
            View.ChoiceHandler = HandleShowCurrentStudents;
            View.ShowListAndWaitForChoice(strs);
        }

        private void HandleShowCurrentStudents(string choice)
        {
            if (choice.Equals("x"))
            {
                PreviousMenu();
                return;
            }
            int index;
            if (int.TryParse(choice, out index))
            {
                if (index > 0 && index <= CurrentStudents.Count)
                {
                    // Visar betyg ?
                    return;
                }
            }
            ShowCurrentStudents();
        }
    }
}
