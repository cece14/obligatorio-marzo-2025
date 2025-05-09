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
    public class ObtenerEmpleados : IObtenerEmpleados
    {
        public IRepositorioEmpleados Repo { get; set; }

        public ObtenerEmpleados(IRepositorioEmpleados repo)
        {
            Repo = repo;
        }
        public Empleado FindById(int id)
        {
            return Repo.FindById(id);  // Usar el método FindById del repositorio
        }

        public List<EmpleadoDTO> ObtenerTodos()
        {
            var lista = Repo.FindAll(); 

            return lista.Select(e => new EmpleadoDTO
            {
                Id = e.Id, 
                Nombre = e.Nombre,
                Apellido = e.Apellido,
                Email = e.Email.Valor,
                Rol = e.Usuario?.Rol ?? Rol.Funcionario,
                FechaAlta = e.Usuario?.FechaAlta ?? DateTime.MinValue,
                Telefono = e.Telefono
            }).ToList();
        }
    }
}
