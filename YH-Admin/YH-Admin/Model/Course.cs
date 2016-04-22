using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YH_Admin
{
    public class Course
    {
        public int CourseId { get; set; }

        public string CourseName { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Course(int courseId, string courseName, DateTime startDate, DateTime endDate)
        {
            courseId = CourseId;
            courseName = CourseName;
            startDate = StartDate;
            endDate = EndDate;

        }

    }
}
