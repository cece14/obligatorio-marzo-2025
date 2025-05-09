using LogicaNegocio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class EmpleadoDTO
    {
        public int Id { get; set; }

        [StringLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres")]
        public string Nombre { get; set; } // Ahora puede ser null

        [StringLength(50, ErrorMessage = "El apellido no puede tener más de 50 caracteres")]
        public string Apellido { get; set; } // Ahora puede ser null

        [EmailAddress(ErrorMessage = "Debe ingresar un email válido")]
        public string Email { get; set; } // Ahora puede ser null

        public string Telefono { get; set; } // Ahora puede ser null

        public DateTime FechaAlta { get; set; } // Ahora puede ser null

        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "La contraseña debe tener entre 4 y 50 caracteres")]
        public string Password { get; set; } // Ahora puede ser null

        [Required(ErrorMessage = "Debe seleccionar un rol")]
        public Rol Rol { get; set; } // El Rol sigue siendo requerido (si así lo deseas)
    }
}