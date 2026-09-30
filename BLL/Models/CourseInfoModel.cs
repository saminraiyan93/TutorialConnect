using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class CourseInfoModel : CourseModel      // To show course with Department Info
    {
        public string CourseDepartmentName { get; set; }
    }
}
