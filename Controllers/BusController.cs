using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Busero.Data;
using Busero.Models;

namespace Busero.Controllers
{
    public class BusController : Controller
    {
        private readonly BusDbContext _context;

        public BusController(BusDbContext context)
        {
            _context = context;
        }

        // GET: Bus
        public async Task<IActionResult> Index()
        {
            var busDbContext = _context.buses.Include(b => b.Driver);
            return View(await busDbContext.ToListAsync());
        }

        // GET: Bus/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bus = await _context.buses
                .Include(b => b.Driver)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bus == null)
            {
                return NotFound();
            }

            return View(bus);
        }

        // GET: Bus/Create
        public IActionResult Create()
        {
            ViewData["DriverId"] = new SelectList(_context.drivers, "DriverId", "Contact");
            return View();
        }

        // POST: Bus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Placa,Anho,Brand,Model,DriverId")] Bus bus)
        {
            if (ModelState.IsValid)
            {
                bus.Id = Guid.NewGuid();
                _context.Add(bus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DriverId"] = new SelectList(_context.drivers, "DriverId", "Contact", bus.DriverId);
            return View(bus);
        }

        // GET: Bus/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bus = await _context.buses.FindAsync(id);
            if (bus == null)
            {
                return NotFound();
            }
            ViewData["DriverId"] = new SelectList(_context.drivers, "DriverId", "Contact", bus.DriverId);
            return View(bus);
        }

        // POST: Bus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Placa,Anho,Brand,Model,DriverId")] Bus bus)
        {
            if (id != bus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BusExists(bus.Id))
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
            ViewData["DriverId"] = new SelectList(_context.drivers, "DriverId", "Contact", bus.DriverId);
            return View(bus);
        }

        // GET: Bus/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bus = await _context.buses
                .Include(b => b.Driver)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bus == null)
            {
                return NotFound();
            }

            return View(bus);
        }

        // POST: Bus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var bus = await _context.buses.FindAsync(id);
            if (bus != null)
            {
                _context.buses.Remove(bus);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BusExists(Guid id)
        {
            return _context.buses.Any(e => e.Id == id);
        }
    }
}
