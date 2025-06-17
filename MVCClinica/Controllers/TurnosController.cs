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
    public class TurnosController : Controller
    {
        private readonly AppDbContext _context;

        public TurnosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Turnos
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Turnos.Include(t => t.Odontologo).Include(t => t.Paciente);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Turnos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turno = await _context.Turnos
                .Include(t => t.Odontologo)
                .Include(t => t.Paciente)
                .FirstOrDefaultAsync(m => m.IdTurno == id);
            if (turno == null)
            {
                return NotFound();
            }

            return View(turno);
        }

        // GET: Turnos/Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Pacientes"] = _context.Pacientes.ToList();
            ViewData["IdOdontologo"] = new SelectList(_context.Odontologos, "Id", "Nombre");

            return View();
        }

        // POST: Turnos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FechaHora,Duracion,Estado,IdOdontologo")] Turno turno, string pacienteRut)
        {
            if (ModelState.IsValid)
            {
                var paciente = await _context.Pacientes.FirstOrDefaultAsync(p => p.RUT == pacienteRut);

                if (paciente == null)
                {
                    ModelState.AddModelError("PacienteRut", "Paciente no encontrado con ese RUT.");
                    ViewData["Pacientes"] = _context.Pacientes.ToList();
                    ViewData["IdOdontologo"] = new SelectList(_context.Odontologos, "Id", "Nombre", turno.IdOdontologo);
                    return View(turno);
                }

                turno.IdPaciente = paciente.Id;

                _context.Add(turno);
                await _context.SaveChangesAsync();

                // 🔁 Redirección según el rol
                if (User.IsInRole("Paciente"))
                {
                    return RedirectToAction("Index", "Home");
                }
                else if (User.IsInRole("Odontologo"))
                {
                    return RedirectToAction("ListaTurnos", "Turnos");
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            // Si hay errores, recargar datos para la vista
            ViewData["Pacientes"] = _context.Pacientes.ToList();
            ViewData["IdOdontologo"] = new SelectList(_context.Odontologos, "Id", "Nombre", turno.IdOdontologo);
            return View(turno);
        }

        // GET: Turnos/Edit/5
        [HttpGet("Turnos/Edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var turno = await _context.Turnos.FindAsync(id);
            if (turno == null) return NotFound();

            var paciente = await _context.Pacientes.FindAsync(turno.IdPaciente);
            ViewData["PacienteRUT"] = paciente?.RUT;
            ViewData["Pacientes"] = _context.Pacientes.ToList();
            ViewData["IdOdontologo"] = new SelectList(_context.Odontologos, "Id", "Nombre", turno.IdOdontologo);

            return View(turno);
        }

        // POST: Turnos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Turnos/Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTurno,FechaHora,Duracion,Estado,IdPaciente,IdOdontologo")] Turno turno, string PacienteRut)
        {
            if (id != turno.IdTurno) return NotFound();

            if (!string.IsNullOrEmpty(PacienteRut))
            {
                var paciente = await _context.Pacientes.FirstOrDefaultAsync(p => p.RUT == PacienteRut);
                if (paciente != null)
                {
                    turno.IdPaciente = paciente.Id;
                }
                else
                {
                    ModelState.AddModelError("PacienteRut", "No se encontró un paciente con ese RUT.");
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(turno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TurnoExists(turno.IdTurno)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["PacienteRUT"] = PacienteRut;
            ViewData["Pacientes"] = _context.Pacientes.ToList();
            ViewData["IdOdontologo"] = new SelectList(_context.Odontologos, "Id", "Nombre", turno.IdOdontologo);
            return View(turno);
        }

        // GET: Turnos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turno = await _context.Turnos
                .Include(t => t.Odontologo)
                .Include(t => t.Paciente)
                .FirstOrDefaultAsync(m => m.IdTurno == id);
            if (turno == null)
            {
                return NotFound();
            }

            return View(turno);
        }

        // POST: Turnos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var turno = await _context.Turnos.FindAsync(id);
            if (turno != null)
            {
                _context.Turnos.Remove(turno);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TurnoExists(int id)
        {
            return _context.Turnos.Any(e => e.IdTurno == id);
        }
    }
}