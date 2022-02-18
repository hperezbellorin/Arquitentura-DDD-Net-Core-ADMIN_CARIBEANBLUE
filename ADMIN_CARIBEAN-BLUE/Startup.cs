using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Contratos;
using Aplicacion.Servicio;
using Dominio.Contratos.Repositorios;
using Dominio.Contratos.UnidadTrabajo;
using Dominio.Entidades.ADMIN;
using Dominio.Negocio;
using Dominio.Servicios;
using Infraestructura.DBContext;
using Infraestructura.DBContext.RRHH;
using Infraestructura.DBContext.Seguridad;
using Infraestructura.Repositorios;
using Infraestructura.UoW;
using InfraestructuraTransversal.General;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace MVC_presentacion
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddRazorPages().AddRazorRuntimeCompilation();

            services.AddControllersWithViews().AddRazorRuntimeCompilation();


            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddDbContext<RRHHContext>(options =>
           options.UseMySQL(Configuration.GetConnectionString("MySQLConnection")
         
          
           ), ServiceLifetime.Transient);

            services.AddDbContext<SeguridadContext>(options =>
          options.UseMySQL(Configuration.GetConnectionString("MySQLConnectionSeguridad")));


           //Code firts
            //services.AddDbContext<ApplicationDbContext>(options =>
            //options.UseMySQL(
            //    Configuration.GetConnectionString("MySQLConnectionSefuridad")));
            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();

          //  services.AddDbContext<SeguridadContext>(options =>
          //options.UseMySQL(Configuration.GetConnectionString("MySQLConnectionSefuridad")));




            //Aplicacion 
            services.AddScoped<IUsuariosAplicacionServicio, UsuarioAplicacionServicio>();
            services.AddScoped<IMenusAplicacionServicio, MenuAplicacionServicio>();
            services.AddScoped<IEmpleadosAplicacionServicio, EmpleadosAplicacionServicio>();



            //Repositorios Dominios Servicios Implementacions Domino Negocios Servicios
            services.AddScoped<IUsuarioDominioServicio, UsuariosDominioServicio>();
            services.AddScoped<IAspMenusDominioServicios, MenusDominioServicio>();
            services.AddScoped<IEmpleadosDominioServicios, EmpleadosDominioServicio>();



            //Repositorios Dominios Implementacion Repositorios Infraestructura
            services.AddScoped<IUsuariosDominioRepositorio, UsuariosRepositorio>();
            services.AddScoped<IAspMenuDominioRepositorio, AspMenusRepositorio>();
            services.AddScoped<IEmpleadosDominioRepositorio, EmpleadosRepositorio>();






            // Unidades de Trabajos
            services.AddScoped<IUnidadTrabajoRRHH, UnidadTrabajoRRHH>();
            services.AddScoped<IUnidadTrabajoADMIN, UnidadTrabajoADMIN>();
            

            //seguridad
            services.AddScoped<ISeguridad, Seguridad>();

            services.BuildServiceProvider();


            services.AddControllersWithViews();
            services.AddIdentity<Aspnetusers, Aspnetroles>(options =>
            {
                options.Stores.MaxLengthForKeys = 128;
                options.Password.RequiredLength = 6;

                options.Lockout.AllowedForNewUsers = true;

        services.Configure<PasswordHasherOptions>(options =>
    options.CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV2);

                options.Stores.MaxLengthForKeys = 128;
                options.Password.RequiredLength = 6;
                 options.User.AllowedUserNameCharacters = null;
                options.User.RequireUniqueEmail = false;
                options.User.RequireUniqueEmail = false;
                options.SignIn.RequireConfirmedEmail = false;

            })
                .AddEntityFrameworkStores<SeguridadContext>()
          .AddDefaultTokenProviders();

            services.AddDistributedMemoryCache();
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(1);//You can set Time   
             
            });
            services.AddMvc();
         



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
               
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
           app.UseAuthentication();
            
            app.UseMvc();

            //Enable Session.
            app.UseSession();

            app.UseMvc(routes =>
            {

                
             

                routes.MapRoute(
                name: "RRHH",
                template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

              
                    routes.MapRoute(
                      name: "SEGURIDAD",
                      template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                    );
              

                routes.MapRoute(
                name: "default",
                template: "{controller=Inicio}/{action=Login}/{id?}");


            });



        }
    }
}
