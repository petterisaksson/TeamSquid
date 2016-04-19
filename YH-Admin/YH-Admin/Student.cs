using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YH_Admin
{
    public class Student
    {
        public int StudentId { get; set; }

        public string FirstName { get; set; }

        public String LastName { get; set; }

        public Student(string line)
        {
            try
            {
                var splits = line.Split(' ');
                StudentId = int.Parse(splits[0]);
                FirstName = splits[1];
                LastName = splits[2];
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in creating Student: " + ex);
            }
        }

        public override string ToString()
        {
            return StudentId + " " + FirstName + " " + LastName;
        }
    }
}
