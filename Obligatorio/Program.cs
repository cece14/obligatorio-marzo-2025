using LogicaAplicacion.InterfacesCasosDeUso;
using LogicaAplicacion.CasosDeUso;
using LogicaDatos.Repositorios;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;

namespace Obligatorio
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //REPOSITORIOS
            builder.Services.AddScoped<IRepositorioUsuarios, RepositorioUsuarios>();
            builder.Services.AddScoped<IRepositorioEmpleados, RepositorioEmpleados>();
            builder.Services.AddScoped<IRepositorioEmpleados, RepositorioEmpleados>();

            //USUARIOS-GESTION DE ROLES
            builder.Services.AddScoped<ILoginUsuario, LoginUsuario>();
           

            //EMPLEADOS
            builder.Services.AddScoped<IAltaEmpleado, AltaEmpleado>();
            builder.Services.AddScoped<IObtenerEmpleados, ObtenerEmpleados>();
            builder.Services.AddScoped<IEliminarEmpleado, EliminarEmpleado>();
            builder.Services.AddScoped<IEditarEmpleado, EditarEmpleado>();



            builder.Services.AddSession();

            string maquina = builder.Configuration.GetValue<string>("Maquina");
            string strCon = "";

            if (maquina == "Pepe")
            {
                strCon = builder.Configuration.GetConnectionString("MiConexion");
            }
            else
            {
                strCon = builder.Configuration.GetConnectionString("OtraConexion");
            }

            builder.Services.AddDbContext<LogisticaContext>(options => options.UseSqlServer(strCon));

            var app = builder.Build();
            app.UseSession();
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Usuarios}/{action=Login}/{id?}");

            app.Run();
        }
    }
}