using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NTNQCau3.Models;

namespace BaiThiNTNQ.Controllers
{
    public class NTNQCau3Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public string StudentID { get; private set; }

        public NTNQCau3Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NTNQCau3
        public async Task<IActionResult> Index()
        {
              return _context.NTNQCau3 != null ? 
                          View(await _context.NTNQCau3.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.NTNQCau3'  is null.");
        }

        // GET: NTNQCau3/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.NTNQCau3 == null)
            {
                return NotFound();
            }

            var nTNQCau3 = await _context.NTNQCau3
                .FirstOrDefaultAsync(m => m.StudentID == id);
            if (nTNQCau3 == null)
            {
                return NotFound();
            }

            return View(nTNQCau3);
        }

        // GET: NTNQCau3/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NTNQCau3/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentID,StudentName,Address")] NTNQCau3Controller nTNQCau3)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nTNQCau3);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nTNQCau3);
        }

        // GET: NTNQCau3/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.NTNQCau3 == null)
            {
                return NotFound();
            }

            var nTNQCau3 = await _context.NTNQCau3.FindAsync(id);
            if (nTNQCau3 == null)
            {
                return NotFound();
            }
            return View(nTNQCau3);
        }

        // POST: NTNQCau3/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("StudentID,StudentName,Address")] NTNQCau3Controller nTNQCau3)
        {
            if (id != nTNQCau3.StudentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nTNQCau3);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NTNQCau3Exists(nTNQCau3.StudentID))
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
            return View(nTNQCau3);
        }

        // GET: NTNQCau3/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.NTNQCau3 == null)
            {
                return NotFound();
            }

            var nTNQCau3 = await _context.NTNQCau3
                .FirstOrDefaultAsync(m => m.StudentID == id);
            if (nTNQCau3 == null)
            {
                return NotFound();
            }

            return View(nTNQCau3);
        }

        // POST: NTNQCau3/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.NTNQCau3 == null)
            {
                return Problem("Entity set 'ApplicationDbContext.NTNQCau3'  is null.");
            }
            var nTNQCau3 = await _context.NTNQCau3.FindAsync(id);
            if (nTNQCau3 != null)
            {
                _context.NTNQCau3.Remove(nTNQCau3);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NTNQCau3Exists(string id)
        {
          return (_context.NTNQCau3?.Any(e => e.StudentID == id)).GetValueOrDefault();
        }
    }
}
