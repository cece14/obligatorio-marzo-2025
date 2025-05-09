using DTO;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Mappers
{
   public class UsuariosMapper
    {
        public static ListadoUsuariosDTO ToDTO(Usuario usu)
        {

            ListadoUsuariosDTO dto = new ListadoUsuariosDTO()
            {
                Id = usu.Id,
                Email = usu.Email.Valor,
                Password = usu.Password,
                Rol = usu.Rol,
               
                Nombre = usu.Nombre,
                Apellido = usu.Apellido
            };

            return dto;
        }
    }

}
