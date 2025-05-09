using DTO;
using LogicaAplicacion.InterfacesCasosDeUso;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso
{
    public class EliminarEmpleado : IEliminarEmpleado
    {
        public IRepositorioEmpleados Repo { get; set; }

        public EliminarEmpleado(IRepositorioEmpleados repo)
        {
            Repo = repo;
        }

        public void Eliminar(int id)
        {
            var emp = Repo.FindById(id);
            if (emp != null)
            {
                Repo.Remove(id); 
            }

        }

        public EmpleadoDTO Buscar(int id)
        {
            var emp = Repo.FindById(id);
            if (emp == null) return null;

            return new EmpleadoDTO
            {
                Id = emp.Id,
                Nombre = emp.Nombre,
                Apellido = emp.Apellido,
                Email = emp.Email.Valor,
                Rol = emp.Usuario?.Rol ?? Rol.Funcionario
            };
        }
    }
}
