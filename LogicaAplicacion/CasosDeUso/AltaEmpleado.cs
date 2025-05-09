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
    public class AltaEmpleado : IAltaEmpleado
    {
        public IRepositorioEmpleados Repo { get; set; }

        public AltaEmpleado(IRepositorioEmpleados repo)
        {
            Repo = repo;
        }

        public void EjecutarAlta(EmpleadoDTO dto)
        {
            if (Repo.ExisteEmail(dto.Email))
                throw new EmailYaRegistradoException(dto.Email);

            if (dto.Rol == Rol.Cliente)
                throw new RolInvalidoException("No se puede asignar el rol 'Cliente' a un empleado.");

            var empleado = EmpleadosMapper.ToEmpleado(dto);
            Repo.Add(empleado);
        }
    }
}
