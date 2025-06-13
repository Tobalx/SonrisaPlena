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
    public class UsuariosController : Controller
    {
        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Usuarios.Include(u => u.Administrador).Include(u => u.Odontologo).Include(u => u.Paciente).Include(u => u.Recepcionista).Include(u => u.Rol);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .Include(u => u.Administrador)
                .Include(u => u.Odontologo)
                .Include(u => u.Paciente)
                .Include(u => u.Recepcionista)
                .Include(u => u.Rol)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            ViewData["AdministradorId"] = new SelectList(_context.Administradores, "Id", "Email");
            ViewData["OdontologoId"] = new SelectList(_context.Odontologos, "Id", "Email");
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Email");
            ViewData["RecepcionistaId"] = new SelectList(_context.Recepcionistas, "Id", "Email");
            ViewData["RolId"] = new SelectList(_context.Roles, "Id", "Nombre");
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreUsuario,Contrasena,RolId,PacienteId,OdontologoId,AdministradorId,RecepcionistaId")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdministradorId"] = new SelectList(_context.Administradores, "Id", "Email", usuario.AdministradorId);
            ViewData["OdontologoId"] = new SelectList(_context.Odontologos, "Id", "Email", usuario.OdontologoId);
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Email", usuario.PacienteId);
            ViewData["RecepcionistaId"] = new SelectList(_context.Recepcionistas, "Id", "Email", usuario.RecepcionistaId);
            ViewData["RolId"] = new SelectList(_context.Roles, "Id", "Email", usuario.RolId);
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            ViewData["AdministradorId"] = new SelectList(_context.Administradores, "Id", "Nombre", usuario.AdministradorId);
            ViewData["OdontologoId"] = new SelectList(_context.Odontologos, "Id", "Nombre", usuario.OdontologoId);
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Nombre", usuario.PacienteId);
            ViewData["RecepcionistaId"] = new SelectList(_context.Recepcionistas, "Id", "Nombre", usuario.RecepcionistaId);
            ViewData["RolId"] = new SelectList(_context.Roles, "Id", "Nombre", usuario.RolId);
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreUsuario,Contrasena,RolId,PacienteId,OdontologoId,AdministradorId,RecepcionistaId")] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.Id))
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
            ViewData["AdministradorId"] = new SelectList(_context.Administradores, "Id", "Email", usuario.AdministradorId);
            ViewData["OdontologoId"] = new SelectList(_context.Odontologos, "Id", "Email", usuario.OdontologoId);
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Nombre", usuario.PacienteId);
            ViewData["RecepcionistaId"] = new SelectList(_context.Recepcionistas, "Id", "Nombre", usuario.RecepcionistaId);
            ViewData["RolId"] = new SelectList(_context.Roles, "Id", "Nombre", usuario.RolId);
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .Include(u => u.Administrador)
                .Include(u => u.Odontologo)
                .Include(u => u.Paciente)
                .Include(u => u.Recepcionista)
                .Include(u => u.Rol)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }
    }
}
