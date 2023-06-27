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
    public class carMakeModelsController : Controller
    {
        private readonly ConnectDB _context;

        public carMakeModelsController(ConnectDB context)
        {
            _context = context;
        }

        // GET: carMakeModels
        public async Task<IActionResult> Index()
        {
              return _context.carMake != null ? 
                          View(await _context.carMake.ToListAsync()) :
                          Problem("Entity set 'ConnectDB.carMake'  is null.");
        }

        // GET: carMakeModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.carMake == null)
            {
                return NotFound();
            }

            var carMakeModel = await _context.carMake
                .FirstOrDefaultAsync(m => m.carMakeID == id);
            if (carMakeModel == null)
            {
                return NotFound();
            }

            return View(carMakeModel);
        }

        // GET: carMakeModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: carMakeModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("carMakeID,carMakeDescription")] carMakeModel carMakeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carMakeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carMakeModel);
        }

        // GET: carMakeModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.carMake == null)
            {
                return NotFound();
            }

            var carMakeModel = await _context.carMake.FindAsync(id);
            if (carMakeModel == null)
            {
                return NotFound();
            }
            return View(carMakeModel);
        }

        // POST: carMakeModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("carMakeID,carMakeDescription")] carMakeModel carMakeModel)
        {
            if (id != carMakeModel.carMakeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carMakeModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!carMakeModelExists(carMakeModel.carMakeID))
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
            return View(carMakeModel);
        }

        // GET: carMakeModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.carMake == null)
            {
                return NotFound();
            }

            var carMakeModel = await _context.carMake
                .FirstOrDefaultAsync(m => m.carMakeID == id);
            if (carMakeModel == null)
            {
                return NotFound();
            }

            return View(carMakeModel);
        }

        // POST: carMakeModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.carMake == null)
            {
                return Problem("Entity set 'ConnectDB.carMake'  is null.");
            }
            var carMakeModel = await _context.carMake.FindAsync(id);
            if (carMakeModel != null)
            {
                _context.carMake.Remove(carMakeModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool carMakeModelExists(int id)
        {
          return (_context.carMake?.Any(e => e.carMakeID == id)).GetValueOrDefault();
        }
    }
}
