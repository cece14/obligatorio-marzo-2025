using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCasosDeUso
{
    public interface ILoginUsuario
    {
        ListadoUsuariosDTO Login(string email, string password);
    }
}
