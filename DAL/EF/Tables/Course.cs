using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class Course
{
    public int CourseId { get; set; }

    public int DepartmentId { get; set; }

    public string? CourseCode { get; set; }

    public string CourseName { get; set; } = null!;

    public string? IsActive { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<StudentRequest> StudentRequests { get; set; } = new List<StudentRequest>();

    public virtual ICollection<TutorOffering> TutorOfferings { get; set; } = new List<TutorOffering>();
}
