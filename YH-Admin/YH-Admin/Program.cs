using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH_Admin;

class Program
{
    static void Main(string[] args)
    {
        School mySchool = new School();
        

        mySchool.LoadData();


        #region TestRegion

        // Test code: GetClasses in a certain education.
        Console.WriteLine("GetClasses in education: 0");
        var classes = mySchool.GetClasses(0);
        foreach (var s in classes)
        {
            Console.WriteLine(s.ShowClassStatus());
        }

        // Test code: GetStudents in a certain class.
        Console.WriteLine("GetStudents in class: 2");
        var students = mySchool.GetStudents(2);
        foreach (var s in students)
        {
            Console.WriteLine(s);
        }

        #endregion //TestRegion


    }

}