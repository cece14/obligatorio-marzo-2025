using LogicaNegocio.EntidadesDominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios
{
    public class LogisticaContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Envio> Envios { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<EnvioEstandar> EnvioEstandar { get; set; }
        public DbSet<EnvioUrgente> EnvioUrgente { get; set; }


        public LogisticaContext(DbContextOptions<LogisticaContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empleado>()
       .HasOne(e => e.Usuario)
       .WithOne(u => u.Empleado)
       .HasForeignKey<Usuario>(u => u.EmpleadoId)
       .OnDelete(DeleteBehavior.Cascade);
        }
    }
}