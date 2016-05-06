using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YH_Admin.Model
{
    public class Staffing
    {
        public int StaffingId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public String Name { get { return $"{FirstName} {LastName}"; } }

        



        public Staffing(int staffingId, string firstName, string lastName)
        {
            StaffingId = staffingId;
            FirstName = firstName;
            LastName = lastName;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Staffing sf = obj as Staffing;
            if ((System.Object) sf == null)
                return false;

            return (StaffingId == sf.StaffingId) && (Name == sf.Name);
        }
    }
}

    
