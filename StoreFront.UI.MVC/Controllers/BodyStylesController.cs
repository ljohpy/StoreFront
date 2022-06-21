using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StoreFront.DATA.EF.Models;
using Microsoft.AspNetCore.Authorization;

namespace StoreFront.UI.MVC.Controllers
{
    [Authorize(Roles ="Admin")]

    public class BodyStylesController : Controller
    {
        private readonly StoreFrontContext _context;

        public BodyStylesController(StoreFrontContext context)
        {
            _context = context;
        }

        // GET: BodyStyles
        public async Task<IActionResult> Index()
        {
              return _context.BodyStyles != null ? 
                          View(await _context.BodyStyles.ToListAsync()) :
                          Problem("Entity set 'StoreFrontContext.BodyStyles'  is null.");
        }

        // GET: BodyStyles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BodyStyles == null)
            {
                return NotFound();
            }

            var bodyStyle = await _context.BodyStyles
                .FirstOrDefaultAsync(m => m.StyleId == id);
            if (bodyStyle == null)
            {
                return NotFound();
            }

            return View(bodyStyle);
        }

        // GET: BodyStyles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BodyStyles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StyleId,StyleName,Description")] BodyStyle bodyStyle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bodyStyle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bodyStyle);
        }

        // GET: BodyStyles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BodyStyles == null)
            {
                return NotFound();
            }

            var bodyStyle = await _context.BodyStyles.FindAsync(id);
            if (bodyStyle == null)
            {
                return NotFound();
            }
            return View(bodyStyle);
        }

        // POST: BodyStyles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StyleId,StyleName,Description")] BodyStyle bodyStyle)
        {
            if (id != bodyStyle.StyleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bodyStyle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BodyStyleExists(bodyStyle.StyleId))
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
            return View(bodyStyle);
        }

        // GET: BodyStyles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BodyStyles == null)
            {
                return NotFound();
            }

            var bodyStyle = await _context.BodyStyles
                .FirstOrDefaultAsync(m => m.StyleId == id);
            if (bodyStyle == null)
            {
                return NotFound();
            }

            return View(bodyStyle);
        }

        // POST: BodyStyles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BodyStyles == null)
            {
                return Problem("Entity set 'StoreFrontContext.BodyStyles'  is null.");
            }
            var bodyStyle = await _context.BodyStyles.FindAsync(id);
            if (bodyStyle != null)
            {
                _context.BodyStyles.Remove(bodyStyle);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BodyStyleExists(int id)
        {
          return (_context.BodyStyles?.Any(e => e.StyleId == id)).GetValueOrDefault();
        }
    }
}
