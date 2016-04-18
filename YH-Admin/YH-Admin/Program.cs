using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        string[] usernamePassword;


        string userName;
        string password;
        Console.WriteLine("Användarnamn:");
        userName = Console.ReadLine();
        Console.WriteLine("Lösenord:");
        password = Console.ReadLine();

        // Comment 
        // Comment 2
        string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Petter\Documents\Login.txt");

        foreach (string line in lines)
        {

            usernamePassword = line.Split(',');
            if (usernamePassword[0] == userName)
            {
                Console.WriteLine("Hittade användare... kontrollerar lösenord..");
                if (usernamePassword[1] == password)
                {
                    Console.WriteLine("Lösesnord korrekt... loggar in användare.. ");
                }


            }
            Console.ReadLine();


        }
    }
}