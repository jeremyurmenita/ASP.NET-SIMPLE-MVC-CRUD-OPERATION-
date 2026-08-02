using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using _231895urmenitaMVCCRUDOPERATION.Data;

namespace _231895urmenitaMVCCRUDOPERATION.Controllers
{
    public class ReportsController : Controller
    {
        private readonly AppDbContext _context;

        public ReportsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult AllStudents()
        {
            var students = _context.Students
                .Include(s => s.Course)
                .OrderBy(s => s.LNAME)
                .ToList();

            return View("_231895urmenitaALLSTUDENTS", students);
        }

        public IActionResult StudentsPerCourse(int? courseId)
        {
            var courses = _context.Courses.ToList();
            ViewBag.Courses = courses;

            var query = _context.Students.Include(s => s.Course).AsQueryable();

            if (courseId.HasValue)
                query = query.Where(s => s.COURSEID == courseId.Value);

            return View("_231895urmenitaSTUDENTSPERCOURSE", query.ToList());
        }

        public IActionResult BirthdayCelebrants(int? month)
        {
            var months = Enumerable.Range(1, 12)
                .Select(m => new { Value = m, Name = new DateTime(2000, m, 1).ToString("MMMM") })
                .ToList();

            ViewBag.Months = months;

            var query = _context.Students.Include(s => s.Course).AsQueryable();

            if (month.HasValue)
                query = query.Where(s => s.BDAY.Month == month.Value);

            return View("_231895urmenitaBDAYCELEBRANTS", query.ToList());
        }
    }
}
