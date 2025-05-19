using LogicaAccesoDatos;
using LogicaAccesoDatos.Repositorio;
using LogicaAplicacion.CasosUso;
using LogicaAplicacion.CasosUso.AgenciaCU;
using LogicaAplicacion.CasosUso.EnvioCU;
using LogicaAplicacion.CasosUso.FuncionarioCU;
using LogicaAplicacion.CasosUso.UsuarioCU;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaAplicacion.InterfacesCasosUso.AgenciaCU;
using LogicaAplicacion.InterfacesCasosUso.EnvioCU;
using LogicaAplicacion.InterfacesCasosUso.FuncionarioCU;
using LogicaAplicacion.InterfacesCasosUso.UsuarioCU;
using LogicaNegocio.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;

namespace MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession();

            //Repositorios
            builder.Services.AddScoped<IRepositorioEnvioUrgente, RepositorioEnvioUrgente>();
            builder.Services.AddScoped<IRepositorioEnvioComun, RepositorioEnvioComun>();
            builder.Services.AddScoped<IRepositorioAuditoria, RepositorioAuditoria>();
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
            builder.Services.AddScoped<IRepositorioAgencia, RepositorioAgencia>();
            builder.Services.AddScoped<IRepositorioEnvio, RepositorioEnvio>();
            builder.Services.AddScoped<IRepositorioRol, RepositorioRol>();

            //Casos de uso
            //Usuario
            builder.Services.AddScoped<IUsuarioLogin, UsuarioLogin>();
            builder.Services.AddScoped<IListarSelectUsuario, ListarSelectUsuario>();
            
            builder.Services.AddScoped<IDetalleUpdateFuncionario, DetalleUpdateFuncionario>();
            builder.Services.AddScoped<IEliminarFuncionario, EliminarFuncionario>();
            builder.Services.AddScoped<IListarFuncionarios, ListarFuncionarios>();
            builder.Services.AddScoped<IDetalleFuncionario, DetalleFuncionario>();
            builder.Services.AddScoped<IUpdateFuncionario, UpdateFuncionario>();
            builder.Services.AddScoped<IAltaFuncionario, AltaFuncionario>();
            //Role
            builder.Services.AddScoped<IListarRoles, ListarRoles>();
            //Envio
            builder.Services.AddScoped<IAgregarComentario, AgregarComentario>();
            builder.Services.AddScoped<IAltaEnvioUrgente, AltaEnvioUrgente>();
            builder.Services.AddScoped<IAltaEnvioComun, AltaEnvioComun>();
            builder.Services.AddScoped<IListarEnvios, ListarEnvios>();
            builder.Services.AddScoped<IDetalleEnvio, DetalleEnvio>();
            builder.Services.AddScoped<IUpdateEnvio, UpdateEnvio>();
            //Agencia
            builder.Services.AddScoped<IListarSAgencia, ListarSAgencia>();

            //Contexto
            builder.Services.AddDbContext<Context>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();

            app.UseAuthorization();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
