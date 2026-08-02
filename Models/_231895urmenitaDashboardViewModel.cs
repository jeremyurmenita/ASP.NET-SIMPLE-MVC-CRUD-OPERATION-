using System.Collections.Generic;

namespace _231895urmenitaMVCCRUDOPERATION.Models
{
    public class _231895urmenitaDashboardViewModel
{
    public int TotalStudents { get; set; }
    public int TotalCourses { get; set; }
    public int MaleCount { get; set; }
    public int FemaleCount { get; set; }

    public List<string> CourseNames { get; set; } = new();
    public List<int> StudentCountPerCourse { get; set; } = new();
}
}
