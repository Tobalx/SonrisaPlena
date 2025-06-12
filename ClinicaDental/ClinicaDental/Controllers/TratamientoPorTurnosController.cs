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
    public class TratamientoPorTurnosController : Controller
    {
        private readonly AppDbContext _context;

        public TratamientoPorTurnosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TratamientoPorTurnos
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.TratamientosPorTurno.Include(t => t.EjecucionTratamiento).Include(t => t.Turno);
            return View(await appDbContext.ToListAsync());
        }

        // GET: TratamientoPorTurnos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tratamientoPorTurno = await _context.TratamientosPorTurno
                .Include(t => t.EjecucionTratamiento)
                .Include(t => t.Turno)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tratamientoPorTurno == null)
            {
                return NotFound();
            }

            return View(tratamientoPorTurno);
        }

        // GET: TratamientoPorTurnos/Create
        public IActionResult Create()
        {
            ViewData["EjecucionTratamientoId"] = new SelectList(_context.EjecucionesTratamiento, "Id", "Id");
            ViewData["TurnoId"] = new SelectList(_context.Turnos, "Id", "Id");
            return View();
        }

        // POST: TratamientoPorTurnos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TurnoId,EjecucionTratamientoId,EstadoPaso,ObservacionesTurno")] TratamientoPorTurno tratamientoPorTurno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tratamientoPorTurno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EjecucionTratamientoId"] = new SelectList(_context.EjecucionesTratamiento, "Id", "Id", tratamientoPorTurno.EjecucionTratamientoId);
            ViewData["TurnoId"] = new SelectList(_context.Turnos, "Id", "Id", tratamientoPorTurno.TurnoId);
            return View(tratamientoPorTurno);
        }

        // GET: TratamientoPorTurnos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tratamientoPorTurno = await _context.TratamientosPorTurno.FindAsync(id);
            if (tratamientoPorTurno == null)
            {
                return NotFound();
            }
            ViewData["EjecucionTratamientoId"] = new SelectList(_context.EjecucionesTratamiento, "Id", "Id", tratamientoPorTurno.EjecucionTratamientoId);
            ViewData["TurnoId"] = new SelectList(_context.Turnos, "Id", "Id", tratamientoPorTurno.TurnoId);
            return View(tratamientoPorTurno);
        }

        // POST: TratamientoPorTurnos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TurnoId,EjecucionTratamientoId,EstadoPaso,ObservacionesTurno")] TratamientoPorTurno tratamientoPorTurno)
        {
            if (id != tratamientoPorTurno.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tratamientoPorTurno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TratamientoPorTurnoExists(tratamientoPorTurno.Id))
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
            ViewData["EjecucionTratamientoId"] = new SelectList(_context.EjecucionesTratamiento, "Id", "Id", tratamientoPorTurno.EjecucionTratamientoId);
            ViewData["TurnoId"] = new SelectList(_context.Turnos, "Id", "Id", tratamientoPorTurno.TurnoId);
            return View(tratamientoPorTurno);
        }

        // GET: TratamientoPorTurnos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tratamientoPorTurno = await _context.TratamientosPorTurno
                .Include(t => t.EjecucionTratamiento)
                .Include(t => t.Turno)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tratamientoPorTurno == null)
            {
                return NotFound();
            }

            return View(tratamientoPorTurno);
        }

        // POST: TratamientoPorTurnos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tratamientoPorTurno = await _context.TratamientosPorTurno.FindAsync(id);
            if (tratamientoPorTurno != null)
            {
                _context.TratamientosPorTurno.Remove(tratamientoPorTurno);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TratamientoPorTurnoExists(int id)
        {
            return _context.TratamientosPorTurno.Any(e => e.Id == id);
        }
    }
}
