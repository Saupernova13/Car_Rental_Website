//Sauraav Jayrajh
//ST100024620
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
    public class returnTableModelsController : Controller
    {
        private readonly ConnectDB _context;


        public returnTableModelsController(ConnectDB context)
        {
            _context = context;
        }

        // GET: returnTableModels
        public async Task<IActionResult> Index()
        {
              return _context.returnTable != null ? 
                          View(await _context.returnTable.ToListAsync()) :
                          Problem("Entity set 'ConnectDB.returnTable'  is null.");
        }

        // GET: returnTableModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.returnTable == null)
            {
                return NotFound();
            }

            var returnTableModel = await _context.returnTable
                .FirstOrDefaultAsync(m => m.returnID == id);
            if (returnTableModel == null)
            {
                return NotFound();
            }

            return View(returnTableModel);
        }

        // GET: returnTableModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: returnTableModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("returnID,rentalID,inspectorNo,dateReturn,daysElapsed,fineValue")] returnTableModel returnTableModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(returnTableModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(returnTableModel);
        }

        // GET: returnTableModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.returnTable == null)
            {
                return NotFound();
            }

            var returnTableModel = await _context.returnTable.FindAsync(id);
            if (returnTableModel == null)
            {
                return NotFound();
            }
            return View(returnTableModel);
        }

        // POST: returnTableModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("returnID,rentalID,inspectorNo,dateReturn,daysElapsed,fineValue")] returnTableModel returnTableModel)
        {
            if (id != returnTableModel.returnID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(returnTableModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!returnTableModelExists(returnTableModel.returnID))
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
            return View(returnTableModel);
        }

        // GET: returnTableModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.returnTable == null)
            {
                return NotFound();
            }

            var returnTableModel = await _context.returnTable
                .FirstOrDefaultAsync(m => m.returnID == id);
            if (returnTableModel == null)
            {
                return NotFound();
            }

            return View(returnTableModel);
        }

        // POST: returnTableModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.returnTable == null)
            {
                return Problem("Entity set 'ConnectDB.returnTable'  is null.");
            }
            var returnTableModel = await _context.returnTable.FindAsync(id);
            if (returnTableModel != null)
            {
                _context.returnTable.Remove(returnTableModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool returnTableModelExists(int id)
        {
          return (_context.returnTable?.Any(e => e.returnID == id)).GetValueOrDefault();
        }
    }
}
