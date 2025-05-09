using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Mappers;
using DTO;
using LogicaAplicacion.InterfacesCasosDeUso;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;
using LogicaDatos.Repositorios;
using ExcepcionesPropias;


namespace LogicaAplicacion.CasosDeUso
{
    public class EditarEmpleado: IEditarEmpleado
    {
        public IRepositorioEmpleados RepoEmpleados { get; set; }

        public EditarEmpleado(IRepositorioEmpleados repo)
        {
            RepoEmpleados = repo;
        }

        public void Editar(EmpleadoDTO dto)
        {
            // Convertir el DTO a un objeto Empleado
            var empleado = EmpleadosMapper.ToEmpleado(dto);

            // Buscar el empleado existente en la base de datos
            var empleadoExistente = RepoEmpleados.FindById(dto.Id);
            if (empleadoExistente == null)
            {
                throw new DatosInvalidosException("Empleado no encontrado.");
            }

            // Solo actualizamos los campos que han cambiado
            if (empleado.Nombre != empleadoExistente.Nombre)
                empleadoExistente.Nombre = empleado.Nombre;

            if (empleado.Apellido != empleadoExistente.Apellido)
                empleadoExistente.Apellido = empleado.Apellido;

            if (empleado.Email != empleadoExistente.Email)
                empleadoExistente.Email = empleado.Email;

            if (empleado.Telefono != empleadoExistente.Telefono)
                empleadoExistente.Telefono = empleado.Telefono;

            if (empleado.Rol != empleadoExistente.Rol)
                empleadoExistente.Rol = empleado.Rol;

            // Guardar los cambios en la base de datos
            RepoEmpleados.Update(empleadoExistente);
        }
        public EmpleadoDTO ObtenerEmpleadoPorId(int id)
        {
            var empleado = RepoEmpleados.FindById(id);
            if (empleado == null)
                return null;

            return EmpleadosMapper.ToEmpleadoDTO(empleado);  

    }
}
}