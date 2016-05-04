using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YH_Admin.Utils;

namespace YH_Admin.Model
{
    public class School
    {
        public SchoolIO SchoolDatabase { get; set; }

        public List<User> Users { get; set; }

        public List<Education> Educations { get; set; }

        public List<SchoolClass> SchoolClasses { get; private set; }

        public List<Student> Students { get; private set; }

        public List<Course> Courses { get; private set; }

        public List<EducationCourse> EducationCourses { get; private set; }

        public List<ClassCourse> ClassCourseTable { get; private set; }

        public List<Grade> Grades { get; set; }

        public School()
        {
            Users = new List<User>();
            Educations = new List<Education>();
            SchoolClasses = new List<SchoolClass>();
            Students = new List<Student>();
            Courses = new List<Course>();
            EducationCourses = new List<EducationCourse>();
            ClassCourseTable = new List<ClassCourse>();
            Grades = new List<Grade>();
        }

        /// <summary>
        /// Read all the datafiles in a specific folder.
        /// </summary>
        public void LoadData(string soluPath)
        {
            SchoolDatabase = new SchoolIO(soluPath);
            Users = SchoolDatabase.ReadUserFile();
            Educations = SchoolDatabase.ReadEducationFile();
            Students = SchoolDatabase.ReadStudentFile();
            SchoolClasses = SchoolDatabase.ReadClassFile();
            Courses = SchoolDatabase.ReadCourseFile();
            ClassCourseTable = SchoolDatabase.ReadClassCourseFile();
            EducationCourses = SchoolDatabase.ReadEducationCourseFile();
            Grades = SchoolDatabase.ReadGradeFile();

            // Read user file
            //ReadUserFile(Path.Combine(soluPath, @"DataFiles\users.txt"));

            // Read student file
            //ReadStudentFile(Path.Combine(soluPath, @"DataFiles\students.txt"));

            // Read class file
            //ReadClassFile(Path.Combine(soluPath, @"DataFiles\classes.txt"));

            // Read course file
            //ReadCourseFile(Path.Combine(soluPath, @"DataFiles\courses.txt"));

            // Read class-course file
            //ReadClassCourseFile(Path.Combine(soluPath, @"DataFiles\class_courses.txt"));

            // Read education file
            //ReadEducationFile(Path.Combine(soluPath, @"DataFiles\education.txt"));

            // Read education-course file
            //ReadEducationCourseFile(Path.Combine(soluPath, @"DataFiles\education_courses.txt"));

            // Read grade file
            //ReadGradeFile(Path.Combine(soluPath, @"DataFiles\grades.txt"));
        }

        //private void ReadGradeFile(string path)
        //{
        //    try
        //    {
        //        Grades = new List<Grade>();
        //        string[] lines = File.ReadAllLines(path);
        //        foreach (var line in lines)
        //        {
        //            var splits = line.Split(' ');
        //            var u = new Grade(Guid.Parse(splits[0]), int.Parse(splits[1]), int.Parse(splits[2]), splits[3]);
        //            Grades.Add(u);

        //            //Test code: 
        //            //Console.WriteLine(u);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Exception caught in creating Grades: " + ex);
        //        Console.ReadLine();
        //    }
        //}

        //private void ReadUserFile(string path)
        //{
        //    try
        //    {
        //        Users = new List<User>();
        //        string[] lines = File.ReadAllLines(path);
        //        foreach (var line in lines)
        //        {
        //            var splits = line.Split(' ');
        //            var u = new User(int.Parse(splits[0]), splits[1], splits[2], splits[3], splits[4]);
        //            Users.Add(u);

        //            //Test code: 
        //            //Console.WriteLine(u);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Exception caught in creating EducationCourses: " + ex);
        //        Console.ReadLine();

        //    }
        //}

        public void SaveToFiles()
        {

        }

        //private void ReadEducationFile(string path)
        //{
        //    try
        //    {
        //        Educations = new List<Education>();
        //        string[] lines = File.ReadAllLines(path);
        //        foreach (var line in lines)
        //        {
        //            var splits = line.Split(' ');
        //            var name = splits[1];
        //            for (int i = 2; i < splits.Length - 1; i++)
        //            {
        //                name += " " + splits[i];
        //            }
        //            var e = new Education(int.Parse(splits[0]), name, int.Parse(splits.Last()));
        //            Educations.Add(e);

        //            //Test code: 
        //            //Console.WriteLine(e);
        //            //Console.ReadLine();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Exception caught in creating Educations: " + ex);
        //        Console.ReadLine();

        //    }
        //}

        //private void ReadEducationCourseFile(string path)
        //{
        //    try
        //    {
        //        EducationCourses = new List<EducationCourse>();
        //        string[] lines = File.ReadAllLines(path);
        //        foreach (var line in lines)
        //        {
        //            var splits = line.Split(' ');
        //            var ec = new EducationCourse(int.Parse(splits[0]), int.Parse(splits[1]), int.Parse(splits[2]));
        //            EducationCourses.Add(ec);

        //            //Test code: 
        //            //Console.WriteLine(ec);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Exception caught in creating EducationCourses: " + ex);
        //        Console.ReadLine();

        //    }
        //}

        //private void ReadClassCourseFile(string path)
        //{
        //    try
        //    {
        //        ClassCourseTable = new List<ClassCourse>();
        //        string[] lines = File.ReadAllLines(path);
        //        foreach (var line in lines)
        //        {
        //            var splits = line.Split(' ');
        //            var startDate = DateTime.ParseExact(splits[splits.Length - 2], "yyyyMMdd", null);
        //            var endDate = DateTime.ParseExact(splits[splits.Length - 1], "yyyyMMdd", null);
        //            var cc = new ClassCourse(int.Parse(splits[0]), int.Parse(splits[1]), int.Parse(splits[2]), startDate, endDate);
        //            ClassCourseTable.Add(cc);

        //            //Test code: 
        //            //Console.WriteLine(cc);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Exception caught in creating Courses: " + ex);
        //        Console.ReadLine();

        //    }
        //}

        //private void ReadCourseFile(string path)
        //{
        //    try
        //    {
        //        Courses = new List<Course>();
        //        string[] lines = File.ReadAllLines(path);
        //        foreach (var line in lines)
        //        {
        //            var splits = line.Split(' ');
        //            var name = splits[1];
        //            for (int i = 2; i < splits.Length; i++)
        //            {
        //                name += " " + splits[i];
        //            }
        //            var c = new Course(int.Parse(splits[0]), name);
        //            Courses.Add(c);

        //            //Test code: 
        //            //Console.WriteLine(c);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Exception caught in creating Courses: " + ex);
        //        Console.ReadLine();

        //    }
        //}

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
                Console.ReadLine();

            }

        }

        public Grade GetGrade(Student student, ClassCourse classCourse)
        {
            return Grades.Find(g => g.StudentId == student.StudentId && g.ClassCourseId == classCourse.ClassCourseId);
        }

        public List<Student> GetFailers()
        {
            var failList = Grades.Where(g => g.GradeString == "IG");
            var failedStudent = new List<Student>();

            foreach (var grade in failList)
            {
                var student = Students.Find(s => s.StudentId == grade.StudentId);
                if (student != null)
                    failedStudent.Add(student);
            }

            return failedStudent;
        }

        public void SetGrade(Student student, ClassCourse classCourse, string gradeString)
        {
            var grade = GetGrade(student, classCourse);
            if (grade != null)
                grade.GradeString = gradeString;
            else
            {
                Grades.Add(new Grade(Guid.NewGuid(), student.StudentId, classCourse.ClassCourseId, gradeString));
            }
        }

        public List<Education> GetEducations(int userId)
        {
            var educations = Educations.Where(e => e.UserId == userId).ToList();
            return educations;
        }

        public List<Education> GetEducations(User user)
        {
            return GetEducations(user.UserId);
        }

        public List<ClassCourse> GetClassCourses(Student student)
        {
            var schoolClass = SchoolClasses.Find(c => c.SchoolClassId == student.ClassId);
            return GetClassCourses(schoolClass);
        }

        public List<string> GetCourses(int classId)
        {
            var ccs = ClassCourseTable.Where(c => c.ClassId == classId);
            var sorted = ccs.OrderBy(c => c.StartDate);
            var output = new List<string>();
            foreach (var cc in sorted)
            {
                var course = Courses.Find(c => c.CourseId == cc.CourseId);
                output.Add(course.ToString() + " | " + cc.ShowCourseStatus());
            }
            return output;
        }

        public List<string> GetCourses(SchoolClass schoolClass)
        {
            return GetCourses(schoolClass.SchoolClassId);
        }

        public List<ClassCourse> GetClassCourses(SchoolClass schoolClass)
        {
            return ClassCourseTable.Where(c => c.ClassId == schoolClass.SchoolClassId).OrderBy(c => c.StartDate).ToList();
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

        public List<SchoolClass> GetClasses(Education education)
        {
            return GetClasses(education.EducationId);
        }

        /// <summary>
        /// Read the students data
        /// </summary>
        /// <param name="path"></param>
        //public void ReadStudentFile(string path)
        //{
        //    try
        //    {
        //        Students = new List<Student>();
        //        string[] lines = File.ReadAllLines(path);
        //        foreach (var line in lines)
        //        {
        //            var splits = line.Split(' ');
        //            var st = new Student(int.Parse(splits[0]), splits[1], splits[2], int.Parse(splits[3]));
        //            Students.Add(st);

        //            //Test code: 
        //            //Console.WriteLine(st);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Exception caught in ReadStudentFile: " + ex);
        //        Console.ReadLine();

        //    }
        //}

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

        /// <summary>
        /// Get students from a class with schoolClass.
        /// </summary>
        /// <param name="schoolClass"></param>
        /// <returns></returns>
        public List<Student> GetStudents(SchoolClass schoolClass)
        {
            return GetStudents(schoolClass.SchoolClassId);
        }

    }
}
