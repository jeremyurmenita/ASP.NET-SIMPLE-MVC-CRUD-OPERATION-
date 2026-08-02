using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using _231895urmenitaMVCCRUDOPERATION.Data;
using _231895urmenitaMVCCRUDOPERATION.Models;

namespace _231895urmenitaMVCCRUDOPERATION.Controllers
{
    public class StudentsController : Controller
    {
        private readonly AppDbContext _context;

        public StudentsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var students = await _context.Students.Include(s => s.Course).ToListAsync();
            return View("_231895urmenitaSTUDENTINDEX", students);
        }

        public IActionResult Create()
        {
            ViewBag.Courses = _context.Courses.ToList();
            return View("_231895urmenitaSTUDENTCREATE");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(_231895urmenitaSTUDENT student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Courses = _context.Courses.ToList();
            return View("_231895urmenitaSTUDENTCREATE", student);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return NotFound();

            ViewBag.Courses = _context.Courses.ToList();
            return View("_231895urmenitaSTUDENTEDIT", student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, _231895urmenitaSTUDENT student)
        {
            if (id != student.STUDENTID) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Courses = _context.Courses.ToList();
            return View("_231895urmenitaSTUDENTEDIT", student);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var student = await _context.Students
                .Include(s => s.Course)
                .FirstOrDefaultAsync(s => s.STUDENTID == id);

            if (student == null) return NotFound();

            return View("_231895urmenitaSTUDENTDELETE", student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var student = await _context.Students
                .Include(s => s.Course)
                .FirstOrDefaultAsync(s => s.STUDENTID == id);

            if (student == null) return NotFound();

            return View("_231895urmenitaSTUDENTDETAILS", student);
        }
    }
}
