using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH_Admin.Model;

namespace YH_Admin.Utils
{
    public class SchoolIO
    {
        public string DirectoryPath { get; set; }

        public SchoolIO(string path)
        {
            DirectoryPath = path;
        }

        public List<Grade> ReadGradeFile()
        {
            var path = Path.Combine(DirectoryPath, @"DataFiles\grades.txt");
            var Grades = new List<Grade>();
            try
            {
                string[] lines = File.ReadAllLines(path);
                foreach (var line in lines)
                {
                    var splits = line.Split(' ');
                    var u = new Grade(Guid.Parse(splits[0]), int.Parse(splits[1]), int.Parse(splits[2]), splits[3]);
                    Grades.Add(u);

                    //Test code: 
                    //Console.WriteLine(u);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in creating Grades: " + ex);
                Console.ReadLine();
            }
            return Grades;
        }

        public void SaveGradeFile(List<Grade> grades)
        {
            var path = Path.Combine(DirectoryPath, @"DataFiles\grades.txt");
            var lines = grades.Select(g => g.ToString()).ToArray();
            File.WriteAllLines(path, lines);
        }

        public List<User> ReadUserFile()
        {
            var path = Path.Combine(DirectoryPath, @"DataFiles\users.txt");
            var Users = new List<User>();
            try
            {
                string[] lines = File.ReadAllLines(path);
                foreach (var line in lines)
                {
                    var splits = line.Split(' ');
                    var u = new User(int.Parse(splits[0]), splits[1], splits[2], splits[3], splits[4]);
                    Users.Add(u);

                    //Test code: 
                    //Console.WriteLine(u);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in creating EducationCourses: " + ex);
                Console.ReadLine();
            }
            return Users;
        }

        public List<Education> ReadEducationFile()
        {
            var path = Path.Combine(DirectoryPath, @"DataFiles\education.txt");
            var educations = new List<Education>();
            try
            {
                string[] lines = File.ReadAllLines(path);
                foreach (var line in lines)
                {
                    var splits = line.Split(' ');
                    var name = splits[1];
                    for (int i = 2; i < splits.Length - 1; i++)
                    {
                        name += " " + splits[i];
                    }
                    var e = new Education(int.Parse(splits[0]), name, int.Parse(splits.Last()));
                    educations.Add(e);

                    //Test code: 
                    //Console.WriteLine(e);
                    //Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in creating Educations: " + ex);
                Console.ReadLine();
            }
            return educations;
        }



        public List<Student> ReadStudentFile()
        {
            var path = Path.Combine(DirectoryPath, @"DataFiles\students.txt");
            var students = new List<Student>();
            try
            {
                string[] lines = File.ReadAllLines(path);
                foreach (var line in lines)
                {
                    var splits = line.Split(' ');
                    var st = new Student(int.Parse(splits[0]), splits[1], splits[2], int.Parse(splits[3]));
                    students.Add(st);

                    //Test code: 
                    //Console.WriteLine(st);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in ReadStudentFile: " + ex);
                Console.ReadLine();
            }
            return students;
        }

        public List<SchoolClass> ReadClassFile()
        {
            var path = Path.Combine(DirectoryPath, @"DataFiles\classes.txt");
            var schoolClasses = new List<SchoolClass>();
            try
            {
                string[] lines = File.ReadAllLines(path);
                foreach (var line in lines)
                {
                    var splits = line.Split(' ');
                    var startDate = DateTime.ParseExact(splits[3], "yyyyMMdd", null);
                    var endDate = DateTime.ParseExact(splits[4], "yyyyMMdd", null);
                    var cl = new SchoolClass(int.Parse(splits[0]), splits[1], int.Parse(splits[2]), startDate, endDate);
                    schoolClasses.Add(cl);

                    //Test code: 
                    //Console.WriteLine(cl);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in creating SchoolClass: " + ex);
                Console.ReadLine();
            }
            return schoolClasses;
        }

        public List<Course> ReadCourseFile()
        {
            var path = Path.Combine(DirectoryPath, @"DataFiles\courses.txt");
            var courses = new List<Course>();
            try
            {
                string[] lines = File.ReadAllLines(path);
                foreach (var line in lines)
                {
                    var splits = line.Split(' ');
                    var name = splits[1];
                    for (int i = 2; i < splits.Length; i++)
                    {
                        name += " " + splits[i];
                    }
                    var c = new Course(int.Parse(splits[0]), name);
                    courses.Add(c);

                    //Test code: 
                    //Console.WriteLine(c);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in creating Courses: " + ex);
                Console.ReadLine();

            }
            return courses;
        }

        public List<ClassCourse> ReadClassCourseFile()
        {
            var path = Path.Combine(DirectoryPath, @"DataFiles\class_courses.txt");
            var classCourseTable = new List<ClassCourse>();
            try
            {
                string[] lines = File.ReadAllLines(path);
                foreach (var line in lines)
                {
                    var splits = line.Split(' ');
                    var startDate = DateTime.ParseExact(splits[splits.Length - 2], "yyyyMMdd", null);
                    var endDate = DateTime.ParseExact(splits[splits.Length - 1], "yyyyMMdd", null);
                    var cc = new ClassCourse(int.Parse(splits[0]), int.Parse(splits[1]), int.Parse(splits[2]), startDate, endDate);
                    classCourseTable.Add(cc);

                    //Test code: 
                    //Console.WriteLine(cc);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in creating Courses: " + ex);
                Console.ReadLine();
            }
            return classCourseTable;
        }

        public List<EducationCourse> ReadEducationCourseFile()
        {
            var path = Path.Combine(DirectoryPath, @"DataFiles\education_courses.txt");
            var educationCourse = new List<EducationCourse>();
            try
            {
                string[] lines = File.ReadAllLines(path);
                foreach (var line in lines)
                {
                    var splits = line.Split(' ');
                    var ec = new EducationCourse(int.Parse(splits[0]), int.Parse(splits[1]), int.Parse(splits[2]));
                    educationCourse.Add(ec);

                    //Test code: 
                    //Console.WriteLine(ec);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in creating EducationCourses: " + ex);
                Console.ReadLine();

            }
            return educationCourse;
        }


    }
}
