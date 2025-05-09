using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCasosDeUso
{
    public interface IEliminarEmpleado
    {
        void Eliminar(int id);
        EmpleadoDTO Buscar(int id);
    }

}
