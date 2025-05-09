using ExcepcionesPropias;
using LogicaNegocio.InterfacesDominio;
using LogicaNegocio.ValueObjects;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesDominio
{
    public class Usuario

    {
        public int Id { get; set; }
        public Email Email { get; set; } //Value Object 
        public string Password { get; set; }
        public Rol Rol { get; set; } //Enum
        public int EmpleadoId { get; set; } // FK explícita
        public Empleado Empleado { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public string Telefono { get; set; }

        public DateTime FechaAlta { get; set; }

        public Usuario() { }

        public Usuario(string nombre, string apellido, Email email, string password, Rol rol, string telefono, DateTime fechaAlta)
        {
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Password = password;
            Rol = rol;
            Telefono = telefono;

            Validar();
            FechaAlta = fechaAlta;
        }
        public void Validar()
        {
            if (Email == null)
            {
                throw new UsuarioInvalidoException("Debe completar el email");
            }
            if (Password == null)
            {
                throw new UsuarioInvalidoException("DEbe completar la contraseña");
            }
        }
    }
}
