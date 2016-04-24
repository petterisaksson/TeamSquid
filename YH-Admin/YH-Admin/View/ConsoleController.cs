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

        delegate void DelMenu();

        Stack<DelMenu> PreviousMenus { get; set; }

        User CurrentUser { get; set; }

        List<Education> CurrentEducations { get; set; }

        List<SchoolClass> CurrentClasses { get; set; }

        List<Student> CurrentStudents { get; set; }

        List<string> CurrentCourses { get; set; }

        /// <summary>
        /// Constructor to set up Model and View.
        /// </summary>
        /// <param name="school"></param>
        /// <param name="output"></param>
        public ConsoleController(School school, ConsoleOutput output)
        {
            Model = school;
            View = output;
            PreviousMenus = new Stack<DelMenu>();
        }

        public void ShowWelcomeScreen()
        {
            View.Title = "Inloggning till Yh-Admin";
            View.ChoiceHandler = HandleLogIn;
            View.ShowLogIn();
        }

        public void HandleLogIn(string choice)
        {
            var splits = choice.Split('\n');
            if (splits.Length == 2)
            {
                var user = Model.Users.Find(u => u.Username.Equals(splits[0]) && u.PassWord.Equals(splits[1]));
                if (user != null)
                {
                    CurrentUser = user;
                    ShowMainMenu();
                    return;
                }
            }
            ShowWelcomeScreen();

        }

        private void GoBack()
        {
            var p = PreviousMenus.Pop();
            p();
        }

        /// <summary>
        /// Show the main menu.
        /// </summary>
        public void ShowMainMenu()
        {
            View.Title = $"Huvudmeny - {CurrentUser.Name}";
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
                    PreviousMenus.Push(ShowMainMenu);
                    CurrentEducations = Model.GetEducations(CurrentUser);
                    ShowCurrentEducation();
                    break;
                case "2":
                    PreviousMenus.Push(ShowMainMenu);
                    ShowClassMenu();
                    break;
                case "3":
                    PreviousMenus.Push(ShowMainMenu);
                    ShowCourseMenu();
                    break;
                case "4":
                    PreviousMenus.Push(ShowMainMenu);

                    Console.WriteLine("Undervisare - ej implementerat");
                    break;
                case "5":
                    PreviousMenus.Push(ShowMainMenu);
                    ShowStudentMenu();
                    break;
                case "6":
                    PreviousMenus.Push(ShowMainMenu);

                    Console.WriteLine("Betyg - ej implementerat");
                    break;
                case "x":
                    return;
                default:
                    ShowMainMenu();
                    break;
            }
        }

        private void ShowCurrentEducation()
        {
            View.Title = $"Utbildningar - {CurrentUser.Name}";
            string[] alts = new string[CurrentEducations.Count + 1];
            alts[0] = "Tillbaka";
            for (int i = 0; i < CurrentEducations.Count; i++)
            {
                alts[i + 1] = CurrentEducations[i].ToString();
            }
            View.ChoiceHandler = HandleCurrentEducations;
            View.ShowListAndWaitForChoice(alts);
        }

        private void HandleCurrentEducations(string choice)
        {
            if (choice.Equals("x"))
            {
                GoBack();
                return;
            }
            int index;
            if (int.TryParse(choice, out index))
            {
                if (index > 0 && index <= CurrentEducations.Count)
                {
                    PreviousMenus.Push(ShowCurrentEducation);
                    CurrentClasses = Model.GetClasses(CurrentEducations[index - 1]);
                    ShowCurrentClasses();
                    return;
                }
            }
            ShowCurrentEducation();

        }

        private void ShowClassMenu()
        {
            View.Title = $"Klasser - ";

            string[] alts = { "Tillbaka", "Visa klasser i en viss utbildning" };
            View.ChoiceHandler = HandleClassMenu;
            View.ShowListAndWaitForChoice(alts);
        }

        private void HandleClassMenu(string choice)
        {
            switch (choice)
            {
                case "1":
                    PreviousMenus.Push(ShowClassMenu);
                    CurrentEducations = Model.Educations;
                    ShowCurrentEducation();
                    break;
                case "x":
                    GoBack();
                    break;
                default:
                    ShowClassMenu();
                    break;
            }
        }

        private void ShowCourseMenu()
        {
            View.Title = $"Kurser - ";

            string[] alts = { "Tillbaka", "Visa kurser som läses av en viss klass" };
            View.ChoiceHandler = HandleCourseMenu;
            View.ShowListAndWaitForChoice(alts);
        }

        private void HandleCourseMenu(string choice)
        {
            switch (choice)
            {
                case "1":
                    PreviousMenus.Push(ShowCourseMenu);
                    CurrentClasses = Model.SchoolClasses;
                    ShowCurrentClasses();
                    break;
                case "x":
                    GoBack();
                    break;
                default:
                    ShowCourseMenu();
                    break;
            }
        }

        private void ShowStudentMenu()
        {
            View.Title = $"Studenter - ";

            string[] alts = { "Tillbaka", "Visa studerande i en viss klass" };
            View.ChoiceHandler = HandleStudentMenuChoice;
            View.ShowListAndWaitForChoice(alts);
        }

        private void HandleStudentMenuChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    PreviousMenus.Push(ShowStudentMenu);
                    CurrentClasses = Model.SchoolClasses;
                    ShowCurrentClasses();
                    break;
                case "x":
                    GoBack();
                    break;
                default:
                    ShowStudentMenu();
                    break;
            }
        }

        private void ShowCurrentClasses()
        {
            View.Title = $"Klasser - ";

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
                GoBack();
                return;
            }
            int index;
            if (int.TryParse(choice, out index))
            {
                if (index > 0 && index <= CurrentClasses.Count)
                {
                    var peek = PreviousMenus.Peek();
                    PreviousMenus.Push(ShowCurrentClasses);
                    if (peek.Method.Name == "ShowCourseMenu")
                    {

                        CurrentCourses = Model.GetCourses(CurrentClasses[index - 1]);
                        ShowCurrentCourses();
                    }
                    else
                    {
                        CurrentStudents = Model.GetStudents(CurrentClasses[index - 1]);
                        ShowCurrentStudents();
                    }
                    return;
                }
            }
            ShowCurrentClasses();
        }

        private void ShowCurrentCourses()
        {
            View.Title = $"Kurser - ";

            var alts = new List<string>(CurrentCourses);
            alts.Insert(0, "Tillbaka");
            View.ChoiceHandler = HandleShowCurrentCourses;
            View.ShowListAndWaitForChoice(alts.ToArray());
        }

        private void HandleShowCurrentCourses(string choice)
        {
            if (choice.Equals("x"))
            {
                GoBack();
                return;
            }

            ShowCurrentCourses();
        }

        private void ShowCurrentStudents()
        {
            View.Title = $"Studenter - ";

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
                GoBack();
                return;
            }
            int index;
            if (int.TryParse(choice, out index))
            {
                if (index > 0 && index <= CurrentStudents.Count)
                {
                    PreviousMenus.Push(ShowClassMenu);
                    // Visar betyg ?
                    {
                        PreviousMenus.Clear();
                        ShowMainMenu();
                    }
                    return;
                }
            }
            ShowCurrentStudents();
        }
    }
}
