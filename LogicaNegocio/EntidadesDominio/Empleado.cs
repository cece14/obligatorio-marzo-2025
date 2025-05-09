using LogicaNegocio.ValueObjects;
using ExcepcionesPropias;
using LogicaNegocio.InterfacesDominio;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LogicaNegocio.EntidadesDominio
{
    public  class  Empleado 
    {
        [Key]
        public int Id { get; set; }
        public Email Email { get; set; } //Value Object 
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Rol Rol { get; set; }
        public Usuario Usuario { get; private set; }

        public string Telefono { get; set; }

        public Empleado() { }

        public Empleado(string nombre, string apellido, Email email, string password, Rol rol, string telefono)
        {
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Password = password;

            Usuario = new Usuario(nombre, apellido, email, password, rol, telefono, DateTime.Now);
            Telefono = telefono;
            Rol = rol;
            Validar();
        }
        public void Validar()
        {
            if (string.IsNullOrWhiteSpace(Nombre))
                throw new DatosInvalidosException("El nombre es obligatorio.");

            if (string.IsNullOrWhiteSpace(Apellido))
                throw new DatosInvalidosException("El apellido es obligatorio.");

            if (Email == null || string.IsNullOrWhiteSpace(Email.Valor))
                throw new DatosInvalidosException("El email es obligatorio.");

            if (string.IsNullOrWhiteSpace(Password))
                throw new DatosInvalidosException("La contraseña es obligatoria.");

            if (string.IsNullOrWhiteSpace(Telefono))
                throw new DatosInvalidosException("El teléfono es obligatorio.");

            // Podés agregar más validaciones si querés (longitud mínima, regex, etc.)
        }
    }
}
