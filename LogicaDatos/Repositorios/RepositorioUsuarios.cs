using ExcepcionesPropias;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios
{
    public class RepositorioUsuarios : IRepositorioUsuarios
    { 

    public LogisticaContext Contexto { get; set; }

    public RepositorioUsuarios(LogisticaContext ctx)
    {
        Contexto = ctx;
    }
        public void Add(Usuario obj)
        {
            if (obj == null)
            {
                throw new UsuarioInvalidoException("No se proporciona información del usuario.");
            }

            obj.Validar(); 
            
            Usuario usuarioExistente = BuscarPorMail(obj.Email.Valor);
            if (usuarioExistente != null)
            {
                throw new UsuarioInvalidoException("Ya existe un usuario registrado con este correo electrónico.");
            }

            Contexto.Usuarios.Add(obj);
            Contexto.SaveChanges();
        }
        public Usuario BuscarPorMail(string mail)
        {
            return Contexto.Usuarios
                    .Include(usu => usu.Rol)
                    .Where(usu => usu.Email.Valor == mail)
                    .SingleOrDefault();
        }
       

        public IEnumerable<Usuario> FindAll()
        {
            throw new NotImplementedException();
        }
        public Usuario FindById(int id)
        {
            throw new NotImplementedException();
        }
        public Usuario Login(string email, string contrasenia)
        {
            Usuario buscado = Contexto.Usuarios
                .Where(usu => usu.Email.Valor == email && usu.Password == contrasenia)
                .SingleOrDefault();
            if (buscado == null)
            {
                throw new UsuarioInvalidoException("El usuario o contraseña no son válidos");
            }
            return buscado;
        }
        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Usuario obj)
        {
            throw new NotImplementedException();
        }
    }
}
