using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YH_Admin
{
    public class School
    {
        List<SchoolClass> SchoolClasses { get; set; }

        List<Student> Students { get; set; }

        public void LoadData()
        {
            string soluPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            //var userPath = Path.Combine(soluPath, @"DataFiles\user.txt");
            //Console.WriteLine(userPath);

            ReadStudentFile(Path.Combine(soluPath, @"DataFiles\students.txt"));
            ReadClassFile(Path.Combine(soluPath, @"DataFiles\classes.txt"));

        }

        public void ReadClassFile(string path)
        {
            SchoolClasses = new List<SchoolClass>();
            string[] lines = File.ReadAllLines(path);
            foreach (var line in lines)
            {
                var cl = new SchoolClass(line);
                SchoolClasses.Add(cl);
                Console.WriteLine(cl);
            }
        }

        public List<SchoolClass> GetClasses(int eduId)
        {
            List<SchoolClass> classes = new List<SchoolClass>();


            return classes;
        }

        public void ReadStudentFile(string path)
        {
            Students = new List<Student>();
            string[] lines = File.ReadAllLines(path);
            foreach (var line in lines)
            {
                var st = new Student(line);
                Students.Add(st);
                //Console.WriteLine(st);
            }
        }

        public List<Student> GetStudents(int classId)
        {
            List<Student> students = new List<Student>();
            var sc = SchoolClasses.Find(c => c.ClassId == classId);
            foreach (var id in sc.StudentIds)
            {
                students.Add(Students.Find(s => s.StudentId == id));
            }
            return students;
        }

        
    }
}
