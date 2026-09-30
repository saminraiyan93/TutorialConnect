using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class CourseModel
    {
        public int CourseId { get; set; }

        public int DepartmentId { get; set; }

        public string? CourseCode { get; set; }

        public string CourseName { get; set; } = null!;

        public string? IsActive { get; set; }
    }
}
