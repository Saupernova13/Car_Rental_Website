//Sauraav Jayrajh
//ST100024620
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sauraav_POE_CLDV.Data;

namespace Sauraav_POE_CLDV.Models
{
    [Authorize]
    public class inspectorModelsController : Controller
    {
        private readonly ConnectDB _context;

        public inspectorModelsController(ConnectDB context)
        {
            _context = context;
        }

        // GET: inspectorModels
        public async Task<IActionResult> Index()
        {
              return _context.inspector != null ? 
                          View(await _context.inspector.ToListAsync()) :
                          Problem("Entity set 'ConnectDB.inspector'  is null.");
        }

        // GET: inspectorModels/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.inspector == null)
            {
                return NotFound();
            }

            var inspectorModel = await _context.inspector
                .FirstOrDefaultAsync(m => m.inspectorNo == id);
            if (inspectorModel == null)
            {
                return NotFound();
            }

            return View(inspectorModel);
        }

        // GET: inspectorModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: inspectorModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("inspectorNo,inspectorName,inspectorEmail,inspectorMobile")] inspectorModel inspectorModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inspectorModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inspectorModel);
        }

        // GET: inspectorModels/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.inspector == null)
            {
                return NotFound();
            }

            var inspectorModel = await _context.inspector.FindAsync(id);
            if (inspectorModel == null)
            {
                return NotFound();
            }
            return View(inspectorModel);
        }

        // POST: inspectorModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("inspectorNo,inspectorName,inspectorEmail,inspectorMobile")] inspectorModel inspectorModel)
        {
            if (id != inspectorModel.inspectorNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inspectorModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!inspectorModelExists(inspectorModel.inspectorNo))
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
            return View(inspectorModel);
        }

        // GET: inspectorModels/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.inspector == null)
            {
                return NotFound();
            }

            var inspectorModel = await _context.inspector
                .FirstOrDefaultAsync(m => m.inspectorNo == id);
            if (inspectorModel == null)
            {
                return NotFound();
            }

            return View(inspectorModel);
        }

        // POST: inspectorModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.inspector == null)
            {
                return Problem("Entity set 'ConnectDB.inspector'  is null.");
            }
            var inspectorModel = await _context.inspector.FindAsync(id);
            if (inspectorModel != null)
            {
                _context.inspector.Remove(inspectorModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool inspectorModelExists(string id)
        {
          return (_context.inspector?.Any(e => e.inspectorNo == id)).GetValueOrDefault();
        }
    }
}
