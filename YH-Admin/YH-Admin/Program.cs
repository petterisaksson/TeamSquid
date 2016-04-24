using YH_Admin;
using YH_Admin.Model;
using YH_Admin.View;

class Program
{
    static void Main(string[] args)
    {
        ConsoleOutput output = new ConsoleOutput();
        School school = new School();
        school.LoadData();

        ConsoleController controller = new ConsoleController(school, output);
        controller.ShowWelcomeScreen();
 
    }

}