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
    public class carBodyTypeModelsController : Controller
    {
        
        private readonly ConnectDB _context;

        public carBodyTypeModelsController(ConnectDB context)
        {
            _context = context;
        }

        // GET: carBodyTypeModels
        public async Task<IActionResult> Index()
        {
              return _context.carBodyType != null ? 
                          View(await _context.carBodyType.ToListAsync()) :
                          Problem("Entity set 'ConnectDB.carBodyType'  is null.");
        }

        // GET: carBodyTypeModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.carBodyType == null)
            {
                return NotFound();
            }

            var carBodyTypeModel = await _context.carBodyType
                .FirstOrDefaultAsync(m => m.carBodyTypeID == id);
            if (carBodyTypeModel == null)
            {
                return NotFound();
            }

            return View(carBodyTypeModel);
        }

        // GET: carBodyTypeModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: carBodyTypeModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("carBodyTypeID,carBodyTypeDescription")] carBodyTypeModel carBodyTypeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carBodyTypeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carBodyTypeModel);
        }

        // GET: carBodyTypeModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.carBodyType == null)
            {
                return NotFound();
            }

            var carBodyTypeModel = await _context.carBodyType.FindAsync(id);
            if (carBodyTypeModel == null)
            {
                return NotFound();
            }
            return View(carBodyTypeModel);
        }

        // POST: carBodyTypeModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("carBodyTypeID,carBodyTypeDescription")] carBodyTypeModel carBodyTypeModel)
        {
            if (id != carBodyTypeModel.carBodyTypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carBodyTypeModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!carBodyTypeModelExists(carBodyTypeModel.carBodyTypeID))
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
            return View(carBodyTypeModel);
        }

        // GET: carBodyTypeModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.carBodyType == null)
            {
                return NotFound();
            }

            var carBodyTypeModel = await _context.carBodyType
                .FirstOrDefaultAsync(m => m.carBodyTypeID == id);
            if (carBodyTypeModel == null)
            {
                return NotFound();
            }

            return View(carBodyTypeModel);
        }

        // POST: carBodyTypeModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.carBodyType == null)
            {
                return Problem("Entity set 'ConnectDB.carBodyType'  is null.");
            }
            var carBodyTypeModel = await _context.carBodyType.FindAsync(id);
            if (carBodyTypeModel != null)
            {
                _context.carBodyType.Remove(carBodyTypeModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool carBodyTypeModelExists(int id)
        {
          return (_context.carBodyType?.Any(e => e.carBodyTypeID == id)).GetValueOrDefault();
        }
    }
}
