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

        public ConsoleController(School school, ConsoleOutput output)
        {
            Model = school;
            View = output;
        }

        public void ShowMainMenu()
        {
            string[] alts = { "Avsluta", "Utbildning", "Klasser", "Kurser", "Undervisare", "Studerande" };
            View.ChoiceHandler = HandleMainMenuChoice;
            View.ShowListAndWaitForChoice(alts);
        }

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
                case "x":
                    return;
                default:
                    ShowMainMenu();
                    break;
            }
        }

        public void ShowClassMenu()
        {
            string[] alts = { "Tillbaka", "Visa klasser i en viss utbildning" };
            View.ChoiceHandler = HandleClassMenu;
            View.ShowListAndWaitForChoice(alts);
        }

        private void HandleClassMenu(string choice)
        {

        }


        public void ShowStudentMenu()
        {
            string[] alts = { "Tillbaka", "Visa studerande i en viss klass" };
            View.ChoiceHandler = HandleStudentMenuChoice;
            View.ShowListAndWaitForChoice(alts);
        }

        private void HandleStudentMenuChoice(string choice)
        {
            PreviousMenu = ShowStudentMenu;
            switch (choice)
            {
                case "1":
                    CurrentClasses = Model.SchoolClasses;
                    ShowCurrentClasses();
                    break;
                case "x":
                    ShowMainMenu();
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
