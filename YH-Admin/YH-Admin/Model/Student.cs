using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YH_Admin.Model
{
    public class Student
    {
        /// <summary>
        /// Identifier to this student.
        /// </summary>  
        public int StudentId { get; set; }

        /// <summary>
        /// First name of this student.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of this student.
        /// </summary>
        public String LastName { get; set; }

        public String Name { get { return $"{FirstName} {LastName}"; } }

        /// <summary>
        /// The class id that this student belongs to.
        /// </summary>
        public int ClassId { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="classId"></param>
        public Student(int studentId, string firstName, string lastName, int classId)
        {
            StudentId = studentId;
            FirstName = firstName;
            LastName = lastName;
            ClassId = classId;
        }

        /// <summary>
        /// Default string output.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Id: {StudentId}; Name: {Name}; ClassId: {ClassId}";
        }

    }
}
