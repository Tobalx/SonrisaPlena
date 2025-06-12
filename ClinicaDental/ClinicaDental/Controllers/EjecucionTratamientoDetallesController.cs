using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClinicaDental.Models.Data;
using ClinicaDental.Models.Entities;

namespace ClinicaDental.Controllers
{
    public class EjecucionTratamientoDetallesController : Controller
    {
        private readonly AppDbContext _context;

        public EjecucionTratamientoDetallesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: EjecucionTratamientoDetalles
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.EjecucionTratamientoDetalle.Include(e => e.EjecucionTratamiento).Include(e => e.Tratamiento);
            return View(await appDbContext.ToListAsync());
        }

        // GET: EjecucionTratamientoDetalles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ejecucionTratamientoDetalle = await _context.EjecucionTratamientoDetalle
                .Include(e => e.EjecucionTratamiento)
                .Include(e => e.Tratamiento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ejecucionTratamientoDetalle == null)
            {
                return NotFound();
            }

            return View(ejecucionTratamientoDetalle);
        }

        // GET: EjecucionTratamientoDetalles/Create
        public IActionResult Create()
        {
            ViewData["EjecucionTratamientoId"] = new SelectList(_context.EjecucionesTratamiento, "Id", "Id");
            ViewData["TratamientoId"] = new SelectList(_context.Tratamientos, "Id", "Nombre");
            return View();
        }

        // POST: EjecucionTratamientoDetalles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EjecucionTratamientoId,TratamientoId")] EjecucionTratamientoDetalle ejecucionTratamientoDetalle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ejecucionTratamientoDetalle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EjecucionTratamientoId"] = new SelectList(_context.EjecucionesTratamiento, "Id", "Id", ejecucionTratamientoDetalle.EjecucionTratamientoId);
            ViewData["TratamientoId"] = new SelectList(_context.Tratamientos, "Id", "Nombre", ejecucionTratamientoDetalle.TratamientoId);
            return View(ejecucionTratamientoDetalle);
        }

        // GET: EjecucionTratamientoDetalles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ejecucionTratamientoDetalle = await _context.EjecucionTratamientoDetalle.FindAsync(id);
            if (ejecucionTratamientoDetalle == null)
            {
                return NotFound();
            }
            ViewData["EjecucionTratamientoId"] = new SelectList(_context.EjecucionesTratamiento, "Id", "Id", ejecucionTratamientoDetalle.EjecucionTratamientoId);
            ViewData["TratamientoId"] = new SelectList(_context.Tratamientos, "Id", "Nombre", ejecucionTratamientoDetalle.TratamientoId);
            return View(ejecucionTratamientoDetalle);
        }

        // POST: EjecucionTratamientoDetalles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EjecucionTratamientoId,TratamientoId")] EjecucionTratamientoDetalle ejecucionTratamientoDetalle)
        {
            if (id != ejecucionTratamientoDetalle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ejecucionTratamientoDetalle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EjecucionTratamientoDetalleExists(ejecucionTratamientoDetalle.Id))
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
            ViewData["EjecucionTratamientoId"] = new SelectList(_context.EjecucionesTratamiento, "Id", "Id", ejecucionTratamientoDetalle.EjecucionTratamientoId);
            ViewData["TratamientoId"] = new SelectList(_context.Tratamientos, "Id", "Nombre", ejecucionTratamientoDetalle.TratamientoId);
            return View(ejecucionTratamientoDetalle);
        }

        // GET: EjecucionTratamientoDetalles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ejecucionTratamientoDetalle = await _context.EjecucionTratamientoDetalle
                .Include(e => e.EjecucionTratamiento)
                .Include(e => e.Tratamiento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ejecucionTratamientoDetalle == null)
            {
                return NotFound();
            }

            return View(ejecucionTratamientoDetalle);
        }

        // POST: EjecucionTratamientoDetalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ejecucionTratamientoDetalle = await _context.EjecucionTratamientoDetalle.FindAsync(id);
            if (ejecucionTratamientoDetalle != null)
            {
                _context.EjecucionTratamientoDetalle.Remove(ejecucionTratamientoDetalle);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EjecucionTratamientoDetalleExists(int id)
        {
            return _context.EjecucionTratamientoDetalle.Any(e => e.Id == id);
        }
    }
}
