using LogicaNegocio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ListadoUsuariosDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Password { get; set; }
        public Rol Rol { get; set; }  // Enum Rol
        public string Correo { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
