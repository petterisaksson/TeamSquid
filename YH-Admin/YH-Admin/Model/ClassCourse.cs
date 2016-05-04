using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YH_Admin.Model
{
    public class ClassCourse
    {
        public int ClassCourseId { get; set; }

        public int ClassId { get; set; }

        public int CourseId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string StartDateString { get { return StartDate.ToString("yyyyMMdd"); } }

        public string EndDateString { get { return EndDate.ToString("yyyyMMdd"); } }

        public bool IsFinished { get { return EndDate < DateTime.Today; } }

        public string Status { get { return IsFinished ? "Avslutat" : "Aktiv"; } }

        public ClassCourse(int classCourseId, int classId, int courseId, DateTime startDate, DateTime endDate)
        {
            ClassCourseId = classCourseId;
            ClassId = classId;
            CourseId = courseId;
            StartDate = startDate;
            EndDate = endDate;
        }

        /// <summary>
        /// Get the start date of this course as a string.
        /// </summary>
        /// <returns></returns>
        public string GetStartDate()
        {
            return StartDate.ToString("yyyyMMdd");
        }

        /// <summary>
        /// Get the end date of this course as a string.
        /// </summary>
        /// <returns></returns>
        public string GetEndDate()
        {
            return EndDate.ToString("yyyyMMdd");
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            ClassCourse cc = obj as ClassCourse;
            if ((System.Object)cc == null)
                return false;

            // Return true if the fields match:
            return (ClassCourseId == cc.ClassCourseId) && (ClassId == cc.ClassId) && (CourseId == cc.CourseId);
        }

        public override int GetHashCode()
        {
            return ClassCourseId ^ ClassId ^ CourseId;
        }

        /// <summary>
        /// Default string output.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ClassCourseId + " " + ClassId + " " + CourseId + "; " + GetStartDate() + "->" + GetEndDate();

        }

        public string ShowCourseStatus()
        {
            return GetStartDate() + "->" + GetEndDate() + " Status: " + (IsFinished ? "Avslutat" : "Pågående");
        }

    }
}
