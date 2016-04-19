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



        string soluPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        var userPath = Path.Combine(soluPath, @"DataFiles\user.txt");
        Console.WriteLine(userPath);

        string[] usernamePassword;


        string userName;
        string password;
        Console.WriteLine("Användarnamn:");//test
        userName = Console.ReadLine();
        Console.WriteLine("Lösenord:");
        password = Console.ReadLine();


        string[] lines = System.IO.File.ReadAllLines(userPath);

        foreach (string line in lines)
        {
            Console.WriteLine(line);

            if (true)
                break;

            usernamePassword = line.Split(',');
            if (usernamePassword[0] == userName)
            {
                Console.WriteLine("Hittade användare... kontrollerar lösenord..");
                if (usernamePassword[1] == password)
                {
                    Console.WriteLine("Lösesnord korrekt... loggar in användare.. ");
                }
                //asd

            }
            Console.ReadLine();


        }
    }

}