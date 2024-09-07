using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartloop_Feedback.Objects
{
    public class Coordinator
    {
        public Dictionary<int, Course> courseList { get; set; }

        public Coordinator()
        {
            courseList = new Dictionary<int, Course>();
            LoadCourseList();
        }

        private void LoadCourseList()
        {
            return;
        }
    }
}
