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
        /// <summary>
        /// A list of all school classes
        /// </summary>
        List<SchoolClass> SchoolClasses { get; set; }

        /// <summary>
        /// A list of all students
        /// </summary>
        List<Student> Students { get; set; }

        /// <summary>
        /// Read all the datafiles in a specific folder.
        /// </summary>
        public void LoadData()
        {
            // Path to the application solution
            string soluPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

            // Read student file
            ReadStudentFile(Path.Combine(soluPath, @"DataFiles\students.txt"));

            // Read class file
            ReadClassFile(Path.Combine(soluPath, @"DataFiles\classes.txt"));

        }

        /// <summary>
        /// Read the school classes data
        /// </summary>
        /// <param name="path"></param>
        public void ReadClassFile(string path)
        {
            try
            {
                SchoolClasses = new List<SchoolClass>();
                string[] lines = File.ReadAllLines(path);
                foreach (var line in lines)
                {
                    var splits = line.Split(' ');
                    var startDate = DateTime.ParseExact(splits[3], "yyyyMMdd", null);
                    var endDate = DateTime.ParseExact(splits[4], "yyyyMMdd", null);
                    var cl = new SchoolClass(int.Parse(splits[0]), splits[1], int.Parse(splits[2]), startDate, endDate);
                    SchoolClasses.Add(cl);

                    //Test code: 
                    //Console.WriteLine(cl);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in creating SchoolClass: " + ex);
            }

        }

        /// <summary>
        /// Get the classes within an education with educationId.
        /// </summary>
        /// <param name="educationId"></param>
        /// <returns></returns>
        public List<SchoolClass> GetClasses(int educationId)
        {
            var classes = SchoolClasses.Where(s => s.EducationId == educationId).ToList();
            return classes;
        }

        /// <summary>
        /// Read the students data
        /// </summary>
        /// <param name="path"></param>
        public void ReadStudentFile(string path)
        {
            try
            {
                Students = new List<Student>();
                string[] lines = File.ReadAllLines(path);
                foreach (var line in lines)
                {
                    var splits = line.Split(' ');
                    var st = new Student(int.Parse(splits[0]), splits[1], splits[2], int.Parse(splits[3]));
                    Students.Add(st);

                    //Test code: 
                    //Console.WriteLine(st);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in ReadStudentFile: " + ex);
            }
        }

        /// <summary>
        /// Get students from a class with classId.
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public List<Student> GetStudents(int classId)
        {
            var students = Students.Where(s => s.ClassId == classId).ToList();

            return students;
        }

    }
}
