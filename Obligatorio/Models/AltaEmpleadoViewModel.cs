using DTO;
using System.ComponentModel.DataAnnotations;

namespace Obligatorio.Models
{
    public class AltaEmpleadoViewModel
    {
        public EmpleadoDTO DTO { get; set; }
        public List<EmpleadoDTO> Empleados { get; set; } = new List<EmpleadoDTO>();
    }
}
