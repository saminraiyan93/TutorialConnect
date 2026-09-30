using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class TutorOfferingInfoModel : TutorOfferingModel
    {
        public string UserName { get; set; }
        public string CourseName { get; set; }

        public string DepartmentName { get; set; }
    }
}
