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

        List<ClassCourse> CurrentClassCourses { get; set; }

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
            View.Titles.Push("Inloggning till Yh-Admin");
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
            View.Titles.Pop();
            var p = PreviousMenus.Pop();
            p();
        }

        /// <summary>
        /// Show the main menu.
        /// </summary>
        public void ShowMainMenu()
        {
            PreviousMenus.Clear();
            View.Titles.Clear();
            View.Titles.Push($"Huvudmeny - {CurrentUser.Name}");

            var table = new string[5, 1];
            table[0, 0] = "Kategorier";
            table[1, 0] = "Utbildning";
            table[2, 0] = "Klasser";
            table[3, 0] = "Kurser";
            table[4, 0] = "Studerande";
            table[5, 0] = "Betyg";
            table[6, 0] = "Bemanning";


            View.ChoiceHandler = HandleMainMenuChoice;
            View.ShowTableAndWaitForChoice(table, isMainMenu: true);
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
                    ShowStudentMenu();
                    break;
                case "5":
                    PreviousMenus.Push(ShowMainMenu);
                    // TODO
                    break;
                case "6":
                    PreviousMenus.Push(ShowMainMenu);
                    // TODO
                    break;
                case "x":
                    return;

                case "h":
                    return;
                default:
                    ShowMainMenu();
                    break;
            }
        }

        private void ShowCurrentEducation()
        {
            View.Titles.Push($"Utbildningar ansvariga av {CurrentUser.Name}");
            var table = new string[CurrentEducations.Count + 1, 1];
            table[0, 0] = "Namn";
            for (int i = 0; i < CurrentEducations.Count; i++)
            {
                table[i + 1, 0] = CurrentEducations[i].Name;
            }
            View.ChoiceHandler = HandleCurrentEducations;
            View.ShowTableAndWaitForChoice(table);
        }

        private void HandleCurrentEducations(string choice)
        {
            if (choice.Equals("x"))
            {
                GoBack();
                return;
            }
            if (choice.Equals("h"))
            {
                ShowMainMenu();
                return;
            }
            int index;
            if (int.TryParse(choice, out index))
            {
                if (index > 0 && index <= CurrentEducations.Count)
                {
                    PreviousMenus.Push(ShowCurrentEducation);
                    var chosen = CurrentEducations[index - 1];
                    View.Titles.Push($"Klasser i {chosen.Name}");
                    CurrentClasses = Model.GetClasses(chosen);
                    ShowCurrentClasses();
                    return;
                }
            }
            ShowCurrentEducation();

        }

        private void ShowClassMenu()
        {
            View.Titles.Push($"Visa klasser i en viss utbildning");
            CurrentEducations = Model.Educations;
            var table = new string[CurrentEducations.Count + 1, 1];
            table[0, 0] = "Namn";
            for (int i = 0; i < CurrentEducations.Count; i++)
            {
                table[i + 1, 0] = CurrentEducations[i].Name;
            }

            View.ChoiceHandler = HandleClassMenu;
            View.ShowTableAndWaitForChoice(table);
        }

        private void HandleClassMenu(string choice)
        {
            if (choice.Equals("x"))
            {
                GoBack();
                return;
            }
            if (choice.Equals("h"))
            {
                ShowMainMenu();
                return;
            }
            int index;
            if (int.TryParse(choice, out index))
            {
                if (index > 0 && index <= CurrentEducations.Count)
                {
                    PreviousMenus.Push(ShowClassMenu);
                    var chosen = CurrentEducations[index - 1];
                    View.Titles.Push($"Klasser i {chosen.Name}");
                    CurrentClasses = Model.GetClasses(chosen);
                    ShowCurrentClasses();
                    return;
                }
            }
            ShowClassMenu();
        }

        private void ShowCourseMenu()
        {
            View.Titles.Push($"Visa kurser som läses av en viss klass");
            CurrentClasses = Model.SchoolClasses;
            var table = new string[CurrentClasses.Count + 1, 1];
            table[0, 0] = "Namn";
            for (int i = 0; i < CurrentClasses.Count; i++)
            {
                table[i + 1, 0] = CurrentClasses[i].Name;
            }

            View.ChoiceHandler = HandleCourseMenu;
            View.ShowTableAndWaitForChoice(table);
        }

        private void HandleCourseMenu(string choice)
        {
            if (choice.Equals("x"))
            {
                GoBack();
                return;
            }
            if (choice.Equals("h"))
            {
                ShowMainMenu();
                return;
            }
            int index;
            if (int.TryParse(choice, out index))
            {
                if (index > 0 && index <= CurrentClasses.Count)
                {
                    PreviousMenus.Push(ShowCourseMenu);
                    var chosen = CurrentClasses[index - 1];
                    View.Titles.Push($"Kurser som läses av {chosen.Name}");
                    CurrentClassCourses = Model.GetClassCourses(chosen);
                    ShowCurrentClassCourses();
                    return;
                }
            }
            ShowCourseMenu();
        }

        private void ShowStudentMenu()
        {
            View.Titles.Push($"Visa studerande i en viss klass");
            CurrentClasses = Model.SchoolClasses;
            var table = new string[CurrentClasses.Count + 1, 1];
            table[0, 0] = "Namn";
            for (int i = 0; i < CurrentClasses.Count; i++)
            {
                table[i + 1, 0] = CurrentClasses[i].Name;
            }

            View.ChoiceHandler = HandleStudentMenuChoice;
            View.ShowTableAndWaitForChoice(table);
        }

        private void HandleStudentMenuChoice(string choice)
        {
            if (choice.Equals("x"))
            {
                GoBack();
                return;
            }
            if (choice.Equals("h"))
            {
                ShowMainMenu();
                return;
            }
            int index;
            if (int.TryParse(choice, out index))
            {
                if (index > 0 && index <= CurrentClasses.Count)
                {
                    PreviousMenus.Push(ShowStudentMenu);
                    var chosen = CurrentClasses[index - 1];
                    View.Titles.Push($"Studerande i {chosen.Name}");
                    CurrentStudents = Model.GetStudents(chosen);
                    ShowCurrentStudents();
                    return;
                }
            }
            ShowStudentMenu();
        }

        private void ShowCurrentClasses()
        {
            var table = new string[CurrentClasses.Count + 1, 3];
            table[0, 0] = "Namn";
            table[0, 1] = "Startdatum";
            table[0, 2] = "Status";

            for (int i = 0; i < CurrentClasses.Count; i++)
            {
                table[i + 1, 0] = CurrentClasses[i].Name;
                table[i + 1, 1] = CurrentClasses[i].StartDateString;
                table[i + 1, 2] = CurrentClasses[i].Status;

            }
            View.ChoiceHandler = HandleShowCurrentClasses;
            View.ShowTableAndWaitForChoice(table);
        }

        private void HandleShowCurrentClasses(string choice)
        {
            if (choice.Equals("x"))
            {
                GoBack();
                return;
            }
            if (choice.Equals("h"))
            {
                ShowMainMenu();
                return;
            }
            int index;
            if (int.TryParse(choice, out index))
            {
                if (index > 0 && index <= CurrentClasses.Count)
                {
                    PreviousMenus.Push(ShowCurrentClasses);
                    var chosen = CurrentClasses[index - 1];
                    View.Titles.Push($"Studerande i {chosen.Name}");
                    CurrentStudents = Model.GetStudents(chosen);
                    ShowCurrentStudents();
                    return;
                }
            }
            ShowCurrentClasses();
        }

        private void ShowCurrentClassCourses()
        {
            var table = new string[CurrentClassCourses.Count + 1, 4];
            table[0, 0] = "Namn";
            table[0, 1] = "Startdatum";
            table[0, 2] = "Slutdatum";
            table[0, 3] = "Status";
            for (int i = 0; i < CurrentClassCourses.Count; i++)
            {
                table[i + 1, 0] = Model.Courses.Find(c => c.CourseId == CurrentClassCourses[i].CourseId).Name;
                table[i + 1, 1] = CurrentClassCourses[i].StartDateString;
                table[i + 1, 2] = CurrentClassCourses[i].EndDateString;
                table[i + 1, 3] = CurrentClassCourses[i].Status;
            }
            View.ChoiceHandler = HandleShowCurrentClassCourses;
            View.ShowTableAndWaitForChoice(table, false);
        }

        private void HandleShowCurrentClassCourses(string choice)
        {
            if (choice.Equals("x"))
            {
                GoBack();
                return;
            }
            if (choice.Equals("h"))
            {
                ShowMainMenu();
                return;
            }
            ShowCurrentClassCourses();
        }

        private void ShowCurrentCourses()
        {
            View.Titles.Push($"Kurser - ");

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
            if (choice.Equals("h"))
            {
                ShowMainMenu();
                return;
            }


            ShowCurrentCourses();
           
        }

        private void ShowCurrentStudents()
        {
            var table = new string[CurrentStudents.Count + 1, 1];
            table[0, 0] = "Namn";
            for (int i = 0; i < CurrentStudents.Count; i++)
            {
                table[i + 1, 0] = CurrentStudents[i].Name;
            }
            View.ChoiceHandler = HandleShowCurrentStudents;
            View.ShowTableAndWaitForChoice(table);
        }

        private void HandleShowCurrentStudents(string choice)
        {
            if (choice.Equals("x"))
            {
                GoBack();
                return;
            }
            if (choice.Equals("h"))
            {
                ShowMainMenu();
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
                        ShowMainMenu();
                    }
                    return;
                }
            }
            ShowCurrentStudents();
        }
    }
}
