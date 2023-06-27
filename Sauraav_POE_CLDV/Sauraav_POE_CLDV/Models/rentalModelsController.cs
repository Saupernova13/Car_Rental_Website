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
    public class rentalModelsController : Controller
    {
        private readonly ConnectDB _context;

        public rentalModelsController(ConnectDB context)
        {
            _context = context;
        }

        // GET: rentalModels
        public async Task<IActionResult> Index()
        {
              return _context.rental != null ? 
                          View(await _context.rental.ToListAsync()) :
                          Problem("Entity set 'ConnectDB.rental'  is null.");
        }

        // GET: rentalModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.rental == null)
            {
                return NotFound();
            }

            var rentalModel = await _context.rental
                .FirstOrDefaultAsync(m => m.rentalID == id);
            if (rentalModel == null)
            {
                return NotFound();
            }

            return View(rentalModel);
        }

        // GET: rentalModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: rentalModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("rentalID,carNo,inspectorNo,driver,rentalFee,dateStart,dateEnd")] rentalModel rentalModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rentalModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rentalModel);
        }

        // GET: rentalModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.rental == null)
            {
                return NotFound();
            }

            var rentalModel = await _context.rental.FindAsync(id);
            if (rentalModel == null)
            {
                return NotFound();
            }
            return View(rentalModel);
        }

        // POST: rentalModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("rentalID,carNo,inspectorNo,driver,rentalFee,dateStart,dateEnd")] rentalModel rentalModel)
        {
            if (id != rentalModel.rentalID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rentalModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!rentalModelExists(rentalModel.rentalID))
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
            return View(rentalModel);
        }

        // GET: rentalModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.rental == null)
            {
                return NotFound();
            }

            var rentalModel = await _context.rental
                .FirstOrDefaultAsync(m => m.rentalID == id);
            if (rentalModel == null)
            {
                return NotFound();
            }

            return View(rentalModel);
        }

        // POST: rentalModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.rental == null)
            {
                return Problem("Entity set 'ConnectDB.rental'  is null.");
            }
            var rentalModel = await _context.rental.FindAsync(id);
            if (rentalModel != null)
            {
                _context.rental.Remove(rentalModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool rentalModelExists(int id)
        {
          return (_context.rental?.Any(e => e.rentalID == id)).GetValueOrDefault();
        }
    }
}
