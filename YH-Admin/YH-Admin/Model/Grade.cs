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

        public int ClassCourseId { get; set; }

        public int StudentId { get; set; }

        public string CourseGrade { get; set; }

        public Grade(int gid, int ccid, int sid, string grade)
        {
            GradeId = gid;
            ClassCourseId = ccid;
            StudentId = sid;
            CourseGrade = grade;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Grade gr = obj as Grade;
            if (gr == null)
                return false;

            // Return true if the fields match:
            return (ClassCourseId == gr.ClassCourseId) && (StudentId == gr.StudentId);
        }

        public override int GetHashCode()
        {
            return GradeId ^ ClassCourseId ^ StudentId;
        }

        public string ToFileString()
        {
            return $"{GradeId} {ClassCourseId} {StudentId} {CourseGrade}";
        }
    }
}
