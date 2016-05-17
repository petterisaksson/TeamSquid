using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YH_Admin.Model
{
    public class CourseContent
    {
        public int ObjectivesId { get; set; }

        public int GCriteriaId { get; set; }

        public int VGCriteriaId { get; set; }

        public int Point { get; set; }

        public int ClassCourseId { get; set; }


        public CourseContent(int objectivesId, int gcriteriaId, int vGcriteriaId, int point, int classcourseId)
        {
            ObjectivesId = ObjectivesId;
            GCriteriaId = gcriteriaId;
            VGCriteriaId = vGcriteriaId;
            Point = point;
            ClassCourseId = classcourseId;
        }
    }
}
