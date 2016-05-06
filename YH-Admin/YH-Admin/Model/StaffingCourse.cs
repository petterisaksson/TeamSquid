using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YH_Admin.Model
{
    public class StaffingCourse
    {
        public int StaffingCourseId { get; set; }

        public int CourseId { get; set; }

        public int StaffingId { get; set; }

        public DateTime StartDate { get; set; }

        //okpublic string None { get; set; }

        public string StartDateString { get { return StartDate.ToString("yyyyMMdd"); } }

        public bool IsNotAssign { get; set; }

        public string Status { get { return IsNotAssign ? "Tillsättas" : "Tillsatt"; } }
    }
}
