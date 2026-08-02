using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using _231895urmenitaMVCCRUDOPERATION.Data;
using _231895urmenitaMVCCRUDOPERATION.Models;

namespace _231895urmenitaMVCCRUDOPERATION.Controllers
{
    public class CoursesController : Controller
    {
        private readonly AppDbContext _context;

        public CoursesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            var courses = await _context.Courses.ToListAsync();
            return View("_231895urmenitaCOURSEINDEX", courses);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            return View("_231895urmenitaCOURSECREATE", new _231895urmenitaCOURSE());
        }

        // POST: Courses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(_231895urmenitaCOURSE course)
        {
            // server-side duplicate check (case-insensitive, trimmed)
            var normalizedDesc = course.DESCRIPTION?.Trim().ToLower();

            bool exists = await _context.Courses
                .AnyAsync(c => c.DESCRIPTION.Trim().ToLower() == normalizedDesc);

            if (exists)
            {
                ModelState.AddModelError("DESCRIPTION", "This course is already existing.");
            }

            if (!ModelState.IsValid)
            {
                return View("_231895urmenitaCOURSECREATE", course);
            }

            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null) return NotFound();

            return View("_231895urmenitaCOURSEEDIT", course);
        }

        // POST: Courses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, _231895urmenitaCOURSE course)
        {
            if (id != course.COURSEID) return NotFound();

            var normalizedDesc = course.DESCRIPTION?.Trim().ToLower();

            bool exists = await _context.Courses
                .AnyAsync(c =>
                    c.COURSEID != course.COURSEID &&           // exclude itself
                    c.DESCRIPTION.Trim().ToLower() == normalizedDesc);

            if (exists)
            {
                ModelState.AddModelError("DESCRIPTION", "This course is already existing.");
            }

            if (!ModelState.IsValid)
            {
                return View("_231895urmenitaCOURSEEDIT", course);
            }

            _context.Update(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var course = await _context.Courses
                .FirstOrDefaultAsync(c => c.COURSEID == id);

            if (course == null) return NotFound();

            return View("_231895urmenitaCOURSEDELETE", course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                // nothing to delete, just go back to list
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                // Friendly message when there are related students
                ModelState.AddModelError(string.Empty,
                    "You cannot delete this course because there are students enrolled in it.");

                // Show the same delete page again with the error
                return View("_231895urmenitaCOURSEDELETE", course);
            }
        }
    }
}
