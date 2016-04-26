using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YH_Admin.Model
{
    public class Education
    {
        public int EducationId { get; set; }

        public string Name { get; set; }

        public int UserId { get; set; }

        public Education(int eId, string name, int uId)
        {
            EducationId = eId;
            Name = name;
            UserId = uId;
        }

        public Education()
        {

        }

        public override string ToString()
        {
            return $"EducationId: {EducationId}; Name: {Name}; UserId: {UserId}";
        }
    }
}
