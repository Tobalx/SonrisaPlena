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
    public class RecepcionistasController : Controller
    {
        private readonly AppDbContext _context;

        public RecepcionistasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Recepcionista/CreateDesdeAdmin
        public IActionResult CreateDesdeAdmin()
        {
            return View("Create");
        }

        // POST: Recepcionista/CreateDesdeAdmin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDesdeAdmin(Recepcionista recepcionista)
        {
            if (ModelState.IsValid)
            {
                recepcionista.Rol = "Recepcionista"; // Seguridad extra
                _context.Add(recepcionista);

                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Personas");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error al guardar el recepcionista: " + ex.Message);
                }
            }

            return View("Create", recepcionista);
        }

        // GET: Recepcionistas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Recepcionistas.ToListAsync());
        }

        // GET: Recepcionistas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recepcionista = await _context.Recepcionistas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recepcionista == null)
            {
                return NotFound();
            }

            return View(recepcionista);
        }

        // GET: Recepcionistas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Recepcionistas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Interno,Id,Nombre,Email,Clave,Rol")] Recepcionista recepcionista)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recepcionista);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recepcionista);
        }

        // GET: Recepcionistas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recepcionista = await _context.Recepcionistas.FindAsync(id);
            if (recepcionista == null)
            {
                return NotFound();
            }
            return View(recepcionista);
        }

        // POST: Recepcionistas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Interno,Id,Nombre,Email,Clave,Rol")] Recepcionista recepcionista)
        {
            if (id != recepcionista.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recepcionista);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecepcionistaExists(recepcionista.Id))
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
            return View(recepcionista);
        }

        // GET: Recepcionistas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recepcionista = await _context.Recepcionistas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recepcionista == null)
            {
                return NotFound();
            }

            return View(recepcionista);
        }

        // POST: Recepcionistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recepcionista = await _context.Recepcionistas.FindAsync(id);
            if (recepcionista != null)
            {
                _context.Recepcionistas.Remove(recepcionista);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecepcionistaExists(int id)
        {
            return _context.Recepcionistas.Any(e => e.Id == id);
        }
    }
}
