using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClinicaSonrrisaPlena.Models.Data;
using ClinicaSonrrisaPlena.Models.Entities;

namespace MVCClinica.Controllers
{
    public class PasoPlanesController : Controller
    {
        private readonly AppDbContext _context;

        public PasoPlanesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PasoPlanes
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Pasos.Include(p => p.Plan).Include(p => p.Tratamiento);
            return View(await appDbContext.ToListAsync());
        }

        // GET: PasoPlanes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pasoPlan = await _context.Pasos
                .Include(p => p.Plan)
                .Include(p => p.Tratamiento)
                .FirstOrDefaultAsync(m => m.IdPaso == id);
            if (pasoPlan == null)
            {
                return NotFound();
            }

            return View(pasoPlan);
        }

        // GET: PasoPlanes/Create
        public IActionResult Create()
        {
            ViewData["IdPlan"] = new SelectList(_context.Planes, "IdPlan", "IdPlan");
            ViewData["IdTratamiento"] = new SelectList(_context.Tratamientos, "IdTratamiento", "IdTratamiento");
            return View();
        }

        // POST: PasoPlanes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPaso,FechaEstimada,Estado,Observaciones,IdPlan,IdTratamiento")] PasoPlan pasoPlan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pasoPlan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPlan"] = new SelectList(_context.Planes, "IdPlan", "IdPlan", pasoPlan.IdPlan);
            ViewData["IdTratamiento"] = new SelectList(_context.Tratamientos, "IdTratamiento", "IdTratamiento", pasoPlan.IdTratamiento);
            return View(pasoPlan);
        }

        // GET: PasoPlanes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pasoPlan = await _context.Pasos.FindAsync(id);
            if (pasoPlan == null)
            {
                return NotFound();
            }
            ViewData["IdPlan"] = new SelectList(_context.Planes, "IdPlan", "IdPlan", pasoPlan.IdPlan);
            ViewData["IdTratamiento"] = new SelectList(_context.Tratamientos, "IdTratamiento", "IdTratamiento", pasoPlan.IdTratamiento);
            return View(pasoPlan);
        }

        // POST: PasoPlanes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPaso,FechaEstimada,Estado,Observaciones,IdPlan,IdTratamiento")] PasoPlan pasoPlan)
        {
            if (id != pasoPlan.IdPaso)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pasoPlan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PasoPlanExists(pasoPlan.IdPaso))
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
            ViewData["IdPlan"] = new SelectList(_context.Planes, "IdPlan", "IdPlan", pasoPlan.IdPlan);
            ViewData["IdTratamiento"] = new SelectList(_context.Tratamientos, "IdTratamiento", "IdTratamiento", pasoPlan.IdTratamiento);
            return View(pasoPlan);
        }

        // GET: PasoPlanes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pasoPlan = await _context.Pasos
                .Include(p => p.Plan)
                .Include(p => p.Tratamiento)
                .FirstOrDefaultAsync(m => m.IdPaso == id);
            if (pasoPlan == null)
            {
                return NotFound();
            }

            return View(pasoPlan);
        }

        // POST: PasoPlanes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pasoPlan = await _context.Pasos.FindAsync(id);
            if (pasoPlan != null)
            {
                _context.Pasos.Remove(pasoPlan);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PasoPlanExists(int id)
        {
            return _context.Pasos.Any(e => e.IdPaso == id);
        }
    }
}
