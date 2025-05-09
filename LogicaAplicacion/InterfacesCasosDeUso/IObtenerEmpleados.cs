using DTO;
using LogicaNegocio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCasosDeUso
{
    public interface IObtenerEmpleados
    {
        List<EmpleadoDTO> ObtenerTodos();
        Empleado FindById(int id);
    }
}
