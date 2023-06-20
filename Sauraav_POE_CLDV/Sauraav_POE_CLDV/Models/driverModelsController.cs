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
    public class driverModelsController : Controller
    {
        private readonly ConnectDB _context;

        public driverModelsController(ConnectDB context)
        {
            _context = context;
        }

        // GET: driverModels
        public async Task<IActionResult> Index()
        {
              return _context.driver != null ? 
                          View(await _context.driver.ToListAsync()) :
                          Problem("Entity set 'ConnectDB.driver'  is null.");
        }

        // GET: driverModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.driver == null)
            {
                return NotFound();
            }

            var driverModel = await _context.driver
                .FirstOrDefaultAsync(m => m.driverID == id);
            if (driverModel == null)
            {
                return NotFound();
            }

            return View(driverModel);
        }

        // GET: driverModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: driverModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("driverID,driverName,driverAddress,driverEmail,driverMobile")] driverModel driverModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(driverModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(driverModel);
        }

        // GET: driverModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.driver == null)
            {
                return NotFound();
            }

            var driverModel = await _context.driver.FindAsync(id);
            if (driverModel == null)
            {
                return NotFound();
            }
            return View(driverModel);
        }

        // POST: driverModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("driverID,driverName,driverAddress,driverEmail,driverMobile")] driverModel driverModel)
        {
            if (id != driverModel.driverID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(driverModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!driverModelExists(driverModel.driverID))
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
            return View(driverModel);
        }

        // GET: driverModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.driver == null)
            {
                return NotFound();
            }

            var driverModel = await _context.driver
                .FirstOrDefaultAsync(m => m.driverID == id);
            if (driverModel == null)
            {
                return NotFound();
            }

            return View(driverModel);
        }

        // POST: driverModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.driver == null)
            {
                return Problem("Entity set 'ConnectDB.driver'  is null.");
            }
            var driverModel = await _context.driver.FindAsync(id);
            if (driverModel != null)
            {
                _context.driver.Remove(driverModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool driverModelExists(int id)
        {
          return (_context.driver?.Any(e => e.driverID == id)).GetValueOrDefault();
        }
    }
}
