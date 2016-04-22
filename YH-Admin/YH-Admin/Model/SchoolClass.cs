using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YH_Admin.Model
{
    public class SchoolClass
    {
        /// <summary>
        /// Identifier to this school class.
        /// </summary>
        public int ClassId { get; set; }

        /// <summary>
        /// Name to this school class.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The education id that this class belongs to.
        /// </summary>
        public int EducationId { get; set; }

        /// <summary>
        /// The starting date of this school class.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// The ending date of this school class.
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="classId"></param>
        /// <param name="name"></param>
        /// <param name="educationId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        public SchoolClass(int classId, string name, int educationId, DateTime startDate, DateTime endDate)
        {
            ClassId = classId;
            Name = name;
            EducationId = educationId;
            StartDate = startDate;
            EndDate = endDate;
        }

        /// <summary>
        /// Default string output.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ClassId + ": " + Name + ", eduId: " + EducationId + "; " + GetStartDate() + "->" + GetEndDate();
        }

        /// <summary>
        /// Get the start date of this school class as a string.
        /// </summary>
        /// <returns></returns>
        string GetStartDate()
        {
            return StartDate.ToString("yyyyMMdd");
        }

        /// <summary>
        /// Get the end date of this school class as a string.
        /// </summary>
        /// <returns></returns>
        string GetEndDate()
        {
            return EndDate.ToString("yyyyMMdd");
        }

        /// <summary>
        /// Get of name, start date and whether the class has ended or not.
        /// </summary>
        /// <returns></returns>
        public string ShowClassStatus()
        {
            string str = "Class: " + Name + "; Startdate: " + GetStartDate();
            if (EndDate > DateTime.Today)
                return str + ", Status: active.";
            else
                return str + ", Status: ended on " + GetEndDate();
        }
    }
}
