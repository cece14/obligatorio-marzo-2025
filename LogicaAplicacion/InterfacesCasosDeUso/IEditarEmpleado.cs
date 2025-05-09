using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCasosDeUso
{
    public interface IEditarEmpleado
    {
        EmpleadoDTO ObtenerEmpleadoPorId(int id);
        void Editar(EmpleadoDTO dto);
    }
}
