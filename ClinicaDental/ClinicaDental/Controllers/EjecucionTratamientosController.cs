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
    public class EjecucionTratamientosController : Controller
    {
        private readonly AppDbContext _context;

        public EjecucionTratamientosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: EjecucionTratamientos
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.EjecucionesTratamiento.Include(e => e.Odontologo).Include(e => e.Paciente);
            return View(await appDbContext.ToListAsync());
        }

        // GET: EjecucionTratamientos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ejecucionTratamiento = await _context.EjecucionesTratamiento
                .Include(e => e.Odontologo)
                .Include(e => e.Paciente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ejecucionTratamiento == null)
            {
                return NotFound();
            }

            return View(ejecucionTratamiento);
        }

        // GET: EjecucionTratamientos/Create
        public IActionResult Create()
        {
            ViewData["OdontologoId"] = new SelectList(_context.Odontologos, "Id", "Nombre");
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Nombre");
            return View();
        }

        // POST: EjecucionTratamientos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PacienteId,OdontologoId,FechaEstimada,FechaRealizacion,Estado,Observaciones,ObservacionesGenerales")] EjecucionTratamiento ejecucionTratamiento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ejecucionTratamiento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OdontologoId"] = new SelectList(_context.Odontologos, "Id", "Nombre", ejecucionTratamiento.OdontologoId);
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Nombre", ejecucionTratamiento.PacienteId);
            return View(ejecucionTratamiento);
        }

        // GET: EjecucionTratamientos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ejecucionTratamiento = await _context.EjecucionesTratamiento.FindAsync(id);
            if (ejecucionTratamiento == null)
            {
                return NotFound();
            }
            ViewData["OdontologoId"] = new SelectList(_context.Odontologos, "Id", "Nombre", ejecucionTratamiento.OdontologoId);
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Nombre", ejecucionTratamiento.PacienteId);
            return View(ejecucionTratamiento);
        }

        // POST: EjecucionTratamientos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PacienteId,OdontologoId,FechaEstimada,FechaRealizacion,Estado,Observaciones,ObservacionesGenerales")] EjecucionTratamiento ejecucionTratamiento)
        {
            if (id != ejecucionTratamiento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ejecucionTratamiento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EjecucionTratamientoExists(ejecucionTratamiento.Id))
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
            ViewData["OdontologoId"] = new SelectList(_context.Odontologos, "Id", "Nombre", ejecucionTratamiento.OdontologoId);
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Nombre", ejecucionTratamiento.PacienteId);
            return View(ejecucionTratamiento);
        }

        // GET: EjecucionTratamientos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ejecucionTratamiento = await _context.EjecucionesTratamiento
                .Include(e => e.Odontologo)
                .Include(e => e.Paciente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ejecucionTratamiento == null)
            {
                return NotFound();
            }

            return View(ejecucionTratamiento);
        }

        // POST: EjecucionTratamientos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ejecucionTratamiento = await _context.EjecucionesTratamiento.FindAsync(id);
            if (ejecucionTratamiento != null)
            {
                _context.EjecucionesTratamiento.Remove(ejecucionTratamiento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EjecucionTratamientoExists(int id)
        {
            return _context.EjecucionesTratamiento.Any(e => e.Id == id);
        }
    }
}
