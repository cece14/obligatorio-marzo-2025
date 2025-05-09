using ExcepcionesPropias;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LogicaDatos.Repositorios
{
    public class RepositorioEmpleados : IRepositorioEmpleados
    {
        public LogisticaContext Contexto { get; set; }

        public RepositorioEmpleados(LogisticaContext ctx)
        {
            Contexto = ctx;
        }
        public void Add(Empleado obj)
        {
            Contexto.Empleados.Add(obj);
            Contexto.SaveChanges();
        }
        public void Remove(int id)
        {
            var emp = Contexto.Empleados
                .Include(e => e.Usuario) // ← si hay relación
                .FirstOrDefault(e => e.Id == id);

            if (emp != null)
            {
                Contexto.Empleados.Remove(emp);
                Contexto.SaveChanges();
            }
        }
        public Empleado FindById(int id)
        {
            return Contexto.Empleados
                .Include(e => e.Usuario) 
                .FirstOrDefault(e => e.Id == id); 
        }
        public IEnumerable<Empleado> FindAll()
        {
            return Contexto.Empleados.Include(e => e.Usuario).ToList();
        }
        public void Update(Empleado obj)
        {
            if (obj == null)
                throw new DatosInvalidosException("No se proporcionan datos para el alta del empleado");

            obj.Validar();

            var aModificar = FindById(obj.Id);

            if (aModificar == null)
                throw new DatosInvalidosException("El empleado no existe en la base de datos");


            if (aModificar.Email.Valor != obj.Email.Valor)
            {
                if (ExisteEmailEmpleado(obj.Email.Valor, obj.Id))
                    throw new DatosInvalidosException("Ya existe otro empleado con ese email");
            }


            Contexto.Entry(aModificar).State = EntityState.Detached;

         
            Contexto.Empleados.Update(obj);

            Contexto.SaveChanges();
        }
        public bool ExisteEmail(string email)
        {
            return Contexto.Empleados.Any(e => e.Email.Valor == email);
        }
        public bool ExisteEmailEmpleado(string email, int idEmpleado)
        {
            return Contexto.Empleados.Any(e => e.Email.Valor == email && e.Id != idEmpleado);
        }

    }
}   
