using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Mappers
{
    public static class EmpleadosMapper
    {
        public static Empleado ToEmpleado(EmpleadoDTO dto)
        {
            return new Empleado(
                dto.Nombre,
                dto.Apellido,
                new Email(dto.Email),  // Convertir el email de string a Email (Value Object)
                dto.Password,
                dto.Rol,
                dto.Telefono
            )
            {
                Id = dto.Id
            };
        }
        public static EditarEmpleadoDTO ToEditarEmpleadoDTO(Empleado emp)
        {
            return new EditarEmpleadoDTO
            {
                Id = emp.Id,
                Nombre = emp.Nombre,
                Apellido = emp.Apellido,
                Email = emp.Email.Valor,  
                Telefono = emp.Telefono,
                Rol = emp.Rol
            };
        }
        public static EmpleadoDTO MapEditarDTOToEmpleadoDTO(EditarEmpleadoDTO dtoParcial, Empleado original)
        {
            if (original.Usuario != null)
            {
                original.Usuario.Rol = dtoParcial.Rol;
            }
            return new EmpleadoDTO
            {
                Id = original.Id,
                Nombre = dtoParcial.Nombre,
                Apellido = dtoParcial.Apellido,
                Email = dtoParcial.Email,
                Telefono = dtoParcial.Telefono,
                Rol = dtoParcial.Rol,
                Password = original.Password // conservar contraseña anterior
            };
        }

        public static EmpleadoDTO ToEmpleadoDTO(Empleado emp)
        {
            return new EmpleadoDTO
            {
                Id = emp.Id,
                Nombre = emp.Nombre,
                Apellido = emp.Apellido,
                Email = emp.Email.Valor,  // Asegurarse de que se obtiene el valor de Email
                Telefono = emp.Telefono,
                FechaAlta = emp.Usuario.FechaAlta, // Asegurarse de que se obtiene la fecha de alta desde Usuario
                Password = emp.Password,  // Este valor probablemente debe ser pasado del Usuario
                Rol = emp.Rol
            };
        }
    }
}

