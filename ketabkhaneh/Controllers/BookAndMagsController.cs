using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ketabkhaneh.Models.DB;
using Microsoft.AspNetCore.Authorization;

namespace ketabkhaneh.Controllers
{
    [Authorize(Roles ="Admin")]
    public class BookAndMagsController : Controller
    {
        private readonly EduDBContext _context;

        public BookAndMagsController(EduDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.BooksAndMags.ToListAsync());
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookAndMag = await _context.BooksAndMags
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookAndMag == null)
            {
                return NotFound();
            }

            return View(bookAndMag);
        }

        public IActionResult Create()
        {
            var enumData = from BookAndMag.Types e in Enum.GetValues(typeof(BookAndMag.Types))
                           select new
                           {
                               ID = (int)e,
                               Name = e.ToString()
                           };
            ViewBag.Types = new SelectList(enumData, "ID", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Author,Category,Type,Id")] BookAndMag bookAndMag)
        {
            if (ModelState.IsValid)
            {
                bookAndMag.Id = Guid.NewGuid();
                _context.Add(bookAndMag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookAndMag);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookAndMag = await _context.BooksAndMags.FindAsync(id);
            if (bookAndMag == null)
            {
                return NotFound();
            }
            var enumData = from BookAndMag.Types e in Enum.GetValues(typeof(BookAndMag.Types))
                           select new
                           {
                               ID = (int)e,
                               Name = e.ToString()
                           };
            ViewBag.Types = new SelectList(enumData, "ID", "Name");
            return View(bookAndMag);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Author,Category,Type,Id")] BookAndMag bookAndMag)
        {
            if (id != bookAndMag.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookAndMag);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookAndMagExists(bookAndMag.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bookAndMag);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookAndMag = await _context.BooksAndMags
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookAndMag == null)
            {
                return NotFound();
            }

            return View(bookAndMag);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var bookAndMag = await _context.BooksAndMags.FindAsync(id);
            _context.BooksAndMags.Remove(bookAndMag);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookAndMagExists(Guid id)
        {
            return _context.BooksAndMags.Any(e => e.Id == id);
        }
    }
}
