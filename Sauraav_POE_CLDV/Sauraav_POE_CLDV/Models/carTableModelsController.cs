using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sauraav_POE_CLDV.Data;

namespace Sauraav_POE_CLDV.Models
{
    public class carTableModelsController : Controller
    {
        private readonly ConnectDB _context;

        public carTableModelsController(ConnectDB context)
        {
            _context = context;
        }

        // GET: carTableModels
        public async Task<IActionResult> Index()
        {
              return _context.car != null ? 
                          View(await _context.car.ToListAsync()) :
                          Problem("Entity set 'ConnectDB.car'  is null.");
        }

        // GET: carTableModels/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.car == null)
            {
                return NotFound();
            }

            var carTableModel = await _context.car
                .FirstOrDefaultAsync(m => m.carNo == id);
            if (carTableModel == null)
            {
                return NotFound();
            }

            return View(carTableModel);
        }

        // GET: carTableModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: carTableModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("carNo,carmake,carModel,carBodyType,kilometresTraveled,kilometresServiced,available")] carTableModel carTableModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carTableModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carTableModel);
        }

        // GET: carTableModels/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.car == null)
            {
                return NotFound();
            }

            var carTableModel = await _context.car.FindAsync(id);
            if (carTableModel == null)
            {
                return NotFound();
            }
            return View(carTableModel);
        }

        // POST: carTableModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("carNo,carmake,carModel,carBodyType,kilometresTraveled,kilometresServiced,available")] carTableModel carTableModel)
        {
            if (id != carTableModel.carNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carTableModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!carTableModelExists(carTableModel.carNo))
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
            return View(carTableModel);
        }

        // GET: carTableModels/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.car == null)
            {
                return NotFound();
            }

            var carTableModel = await _context.car
                .FirstOrDefaultAsync(m => m.carNo == id);
            if (carTableModel == null)
            {
                return NotFound();
            }

            return View(carTableModel);
        }

        // POST: carTableModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.car == null)
            {
                return Problem("Entity set 'ConnectDB.car'  is null.");
            }
            var carTableModel = await _context.car.FindAsync(id);
            if (carTableModel != null)
            {
                _context.car.Remove(carTableModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool carTableModelExists(string id)
        {
          return (_context.car?.Any(e => e.carNo == id)).GetValueOrDefault();
        }
    }
}
