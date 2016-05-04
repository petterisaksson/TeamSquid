using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YH_Admin.Model
{
    public class Grade
    {
        public int GradeId { get; set; }

        public int StudentId { get; set; }

        public int ClassCourseId { get; set; }

        public string GradeString { get; set; }

        public Grade(int gradeId, int studentId, int classCourseId, string grade)
        {
            GradeId = gradeId;
            StudentId = studentId;
            ClassCourseId = classCourseId;
            GradeString = grade;
        }
    }
}
