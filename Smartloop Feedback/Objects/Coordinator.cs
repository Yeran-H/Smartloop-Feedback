using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartloop_Feedback.Objects
{
    public class Coordinator
    {
        public List<Course> courseList { get; set; }

        public Coordinator()
        {
            courseList = new List<Course>();
            LoadCourseList();
        }

        private void LoadCourseList()
        {
            return;
        }
    }
}
