using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YH_Admin.Model
{
    public class Grade
    {
        public Guid GradeId { get; set; }

        public int StudentId { get; set; }

        public int ClassCourseId { get; set; }

        public string GradeString { get; set; }

        public Grade(Guid gradeId, int studentId, int classCourseId, string grade)
        {
            GradeId = gradeId;
            StudentId = studentId;
            ClassCourseId = classCourseId;
            GradeString = grade;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Grade gr = obj as Grade;
            if (gr == null)
                return false;

            // Return true if the fields match:
            return (StudentId == gr.StudentId) && (ClassCourseId == gr.ClassCourseId);
        }

        public override int GetHashCode()
        {
            return StudentId ^ ClassCourseId;
        }
    }
}
