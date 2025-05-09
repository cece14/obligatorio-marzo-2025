using DTO;
using ExcepcionesPropias;
using LogicaAplicacion.CasosDeUso;
using LogicaAplicacion.InterfacesCasosDeUso;
using LogicaNegocio.EntidadesDominio;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.Models;

public class UsuariosController : Controller
{
    public ILoginUsuario CuLoginUsuario { get; set; }


    public UsuariosController(ILoginUsuario cuLoginUsuario)
    { 
        CuLoginUsuario = cuLoginUsuario;
        }

    [HttpGet] 
    public IActionResult Login()
    {
        return View(); 
    }

    public ActionResult Login(LoginDTO usu)
    {
        try
        {
            ListadoUsuariosDTO logueado = CuLoginUsuario.Login(usu.Email, usu.Password);

            if (logueado == null)
            {
                ViewBag.Error = "Usuario no encontrado o credenciales incorrectas.";
                return View(usu);
            }

            // Verificar si el rol es 'Cliente'
            if (logueado.Rol == Rol.Cliente) // Aquí comparas correctamente con el enum
            {
                ViewBag.Error = "El acceso está restringido para usuarios con rol 'Cliente'.";
                return View(usu);
            }

            if (string.IsNullOrEmpty(logueado.Email) || string.IsNullOrEmpty(logueado.Nombre) || string.IsNullOrEmpty(logueado.Apellido))
            {
                ViewBag.Error = "El usuario no tiene nombre, apellido o email.";
                return View(usu);
            }

            // Guardar los datos en la sesión
            HttpContext.Session.SetString("correo", logueado.Email);
            HttpContext.Session.SetString("nombreUsuario", logueado.Nombre);
            HttpContext.Session.SetString("apellidoUsuario", logueado.Apellido);
            HttpContext.Session.SetString("rol", logueado.Rol.ToString());

            // Redirigir a la página de perfil
            return RedirectToAction("Perfil");
        }
        catch (UsuarioInvalidoException ex)
        {
            ViewBag.Error = ex.Message;
        }
        catch (Exception ex)
        {
            ViewBag.Error = $"Ocurrió un error inesperado: {ex.Message}";
        }

        return View(usu);
    }
    public ActionResult Perfil()
    {
        // Obtener los valores de la sesión
        string nombreUsuario = HttpContext.Session.GetString("nombreUsuario");
        string apellidoUsuario = HttpContext.Session.GetString("apellidoUsuario");

        // Comprobar si los valores son nulos o vacíos
        if (string.IsNullOrEmpty(nombreUsuario) || string.IsNullOrEmpty(apellidoUsuario))
        {
            ViewBag.Error = "No se pudo cargar la información del usuario. Por favor, inicie sesión nuevamente.";
            return RedirectToAction("Login");
        }

        // Crear el ViewModel y asignar los valores
        var viewModel = new UsuarioViewModel
        {
            NombreUsuario = nombreUsuario,
            ApellidoUsuario = apellidoUsuario
        };

        // Pasar el ViewModel a la vista
        return View(viewModel);
    }
}

