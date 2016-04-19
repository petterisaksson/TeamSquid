using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YH_Admin
{
    public class SchoolClass
    {
        public int ClassId { get; set; }

        public string Name { get; set; }

        public List<int> StudentIds { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public SchoolClass(string line)
        {

            try
            {
                var splits = line.Split(' ');
                ClassId = int.Parse(splits[0]);
                Name = splits[1];
                var nums = splits[2].Split(',');
                StudentIds = new List<int>();
                foreach (var n in nums)
                {
                    StudentIds.Add(int.Parse(n));
                }
                StartDate = DateTime.ParseExact(splits[3], "yyyymmdd", null);
                EndDate = DateTime.ParseExact(splits[4], "yyyymmdd", null);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in creating SchoolClass: " + ex);
            }

        }

        public override string ToString()
        {
            return ClassId + ": " + Name + ", studIds: " + GetStudentIds() + "; " + GetStartDate() + "->" + GetEndDate();
        }

        string GetStudentIds()
        {
            string str = "";
            foreach (var id in StudentIds)
            {
                str += id + ",";
            }
            return str.Remove(str.Length - 1);
        }

        string GetStartDate()
        {
            return StartDate.ToString("yyyymmdd");
        }

        string GetEndDate()
        {
            return EndDate.ToString("yyyymmdd");
        }
    }
}
