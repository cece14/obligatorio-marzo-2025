using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesDominio
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Documento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public Usuario Usuario { get; set; }
        public List<Envio> Envios { get; set; } = new();

        public Cliente() { }

        public Cliente(string nombre, string apellido, string documento, string telefono, string direccion, string email, Usuario usuario)
        {
            Nombre = nombre;
            Apellido = apellido;
            Documento = documento;
            Telefono = telefono;
            Direccion = direccion;
            Email = email;
            Usuario = usuario;
        }
    }
}
