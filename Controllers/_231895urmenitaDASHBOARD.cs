using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using _231895urmenitaMVCCRUDOPERATION.Data;

namespace _231895urmenitaMVCCRUDOPERATION.Controllers
{
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("LoggedUser")))
                return RedirectToAction("Login", "Account");

            var totalStudents = _context.Students.Count();
            var totalCourses = _context.Courses.Count();
            var maleCount = _context.Students.Count(s => s.GENDER == "Male");
            var femaleCount = _context.Students.Count(s => s.GENDER == "Female");

            var studentsPerCourse = _context.Students
                .GroupBy(s => s.Course.DESCRIPTION)
                .Select(g => new { Course = g.Key, Count = g.Count() })
                .ToList();

            ViewBag.TotalStudents = totalStudents;
            ViewBag.TotalCourses = totalCourses;
            ViewBag.MaleCount = maleCount;
            ViewBag.FemaleCount = femaleCount;
            ViewBag.StudentsPerCourse = studentsPerCourse;

            return View("_231895urmenitaDASHBOARD");
        }
    }
}
