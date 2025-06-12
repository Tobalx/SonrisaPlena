using ClinicaDental.Models.Data;
using ClinicaDental.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class CuentaController : Controller
{
    private readonly AppDbContext _context;

    public CuentaController(AppDbContext context)
    {
        _context = context;
    }

    // GET: /Cuenta/Login
    public IActionResult Login()
    {
        return View();
    }

    // POST: /Cuenta/Login
    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var usuario = await _context.Usuarios
                .Include(u => u.Rol)
                .FirstOrDefaultAsync(u => u.NombreUsuario == model.NombreUsuario && u.Contrasena == model.Contrasena);

            if (usuario != null)
            {
                // Redireccionar según el rol
                switch (usuario.Rol.Nombre)
                {
                    case "Administrador":
                        return RedirectToAction("Index", "Administradores");
                    case "Recepcionista":
                        return RedirectToAction("Index", "Recepcionistas");
                    case "Odontologo":
                        return RedirectToAction("Index", "Odontologos");
                    case "Paciente":
                        return RedirectToAction("Index", "Pacientes");
                    default:
                        ModelState.AddModelError("", "Rol no reconocido.");
                        break;
                }
            }
            else
            {
                ModelState.AddModelError("", "Usuario o contraseña incorrectos.");
            }
        }

        return View(model);
    }

    public IActionResult Logout()
    {
        // Aquí puedes limpiar sesión, cookies, etc.
        return RedirectToAction("Login");
    }
}
