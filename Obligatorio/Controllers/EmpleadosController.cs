using DTO;
using DTO.Mappers;
using ExcepcionesPropias;
using LogicaAplicacion.CasosDeUso;
using LogicaAplicacion.InterfacesCasosDeUso;
using LogicaNegocio.EntidadesDominio;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.Models;       
    public class EmpleadosController : Controller
    {
    public IAltaEmpleado CuAltaEmpleado { get; set; }
    public IObtenerEmpleados CuListaEmpleado { get; set; }

    public IEliminarEmpleado CuEliminarEmpleado { get; set; }

    public IEditarEmpleado CuEditarEmpleado { get; set; }

    public EmpleadosController(IAltaEmpleado cuAltaEmpleado, IObtenerEmpleados cuListaEmpleado, IEliminarEmpleado cuEliminarEmpleado, IEditarEmpleado cuEditarEmpleado)
    {
        CuAltaEmpleado = cuAltaEmpleado;
        CuListaEmpleado = cuListaEmpleado;
        CuEliminarEmpleado = cuEliminarEmpleado;
        CuEditarEmpleado = cuEditarEmpleado;
      
    }


    // GET: EmpleadosController
    public ActionResult Index()
    {
        var lista = CuListaEmpleado.ObtenerTodos(); // Devuelve List<EmpleadoDTO>

        var vm = new AltaEmpleadoViewModel
        {
            Empleados = lista
        };

        return View(vm);
    }
    // GET: EmpleadosController/Details/5
    public ActionResult Details(int id)
        {
            return View();
        }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        Console.WriteLine($"🔍 Recibido ID: {id}");

        var emp = CuEliminarEmpleado.Buscar(id);

        if (emp == null)
        {
            Console.WriteLine($"❌ Empleado no encontrado en la BD con id {id}");
            TempData["Error"] = "El empleado no existe o ya fue eliminado.";
            return RedirectToAction("Index");
        }

        CuEliminarEmpleado.Eliminar(id);
        TempData["Success"] = $"Empleado '{emp.Nombre} {emp.Apellido}' eliminado correctamente.";
        return RedirectToAction("Index");
    }
    [HttpGet]
    public IActionResult Create()
    {
        var vm = new AltaEmpleadoViewModel(); 
        return View(vm);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(AltaEmpleadoViewModel vm)
    {
        if (!ModelState.IsValid)
            return View(vm);

        try
        {
            CuAltaEmpleado.EjecutarAlta(vm.DTO); // Se pasa el DTO directamente
            return RedirectToAction("Index");
        }
        catch (EmailYaRegistradoException ex)
        {
            ViewBag.MensajeError = ex.Message;
            return View(vm);
        }
        catch (RolInvalidoException ex)
        {
            ViewBag.MensajeError = ex.Message;
            return View(vm);
        }
    }
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var emp = CuListaEmpleado.FindById(id);
        if (emp == null)
        {
            TempData["Error"] = "El empleado no existe.";
            return RedirectToAction("Index");
        }

        var empleadoDTO = EmpleadosMapper.ToEditarEmpleadoDTO(emp);
        var viewModel = new EditarEmpleadoViewModel
        {
            DTO = empleadoDTO
        };

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, EditarEmpleadoViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(viewModel);
        }

        try
        {
            var dtoParcial = viewModel.DTO;

            var original = CuListaEmpleado.FindById(dtoParcial.Id);
            if (original == null)
            {
                TempData["Error"] = "Empleado no encontrado.";
                return RedirectToAction("Index");
            }

            // Mapear el EditarEmpleadoDTO al EmpleadoDTO completo
            var dtoCompleto = EmpleadosMapper.MapEditarDTOToEmpleadoDTO(dtoParcial, original);

            // Llamar al caso de uso con el DTO completo
            CuEditarEmpleado.Editar(dtoCompleto);

            TempData["Success"] = "Empleado actualizado correctamente";
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            TempData["Error"] = $"Error al actualizar el empleado: {ex.Message}";
            return View(viewModel);
        }
    }

}



