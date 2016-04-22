using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void ShowMenu()
        {
            View.Menu();
        }

    }
}
