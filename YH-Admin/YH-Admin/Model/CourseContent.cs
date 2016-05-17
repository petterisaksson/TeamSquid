using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YH_Admin.Model
{
    class CourseContent
    {
        public String Målsättning { get; set; }

        public String GKriterier { get; set; }

        public String VGKriterier { get; set; }

        public int Poäng { get; set; }

        public int CourseId { get; set; }


        public CourseContent(string målsättnig, string gKriterier, string vGKriterier, int poäng, int courseId)
        {
            Målsättning = målsättnig;
            GKriterier = gKriterier;
            VGKriterier = vGKriterier;
            Poäng = poäng;
            CourseId = courseId;
        }





    }
}
