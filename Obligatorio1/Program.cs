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

            //ATLETAS Y DISCIPLINAS
           


            //REPOSITORIOS
            builder.Services.AddScoped<IRepositorioUsuarios, RepositorioUsuarios>();
           

    



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
                pattern: "{controller=Usuarios}/{action=Index}/{id?}");

            app.Run();
        }
    }
}

