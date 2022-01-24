using Aplicacion.Contratos;
using Aplicacion.Servicio;
using Dominio.Contratos.Repositorios;
using Dominio.Contratos.UnidadTrabajo;
using Dominio.Negocio;
using Dominio.Servicios;
using Infraestructura.Repositorios;
using Infraestructura.UoW;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructura.IooC
{
    public static class ServiciosIoC
    {
        public static void Servicios(IServiceCollection services)
        {



            services.AddScoped<IUsuariosAplicacionServicio, UsuariosAplicacionServico>();


            services.AddScoped<IUsuariosDominioRepositorio, UsuariosRepositorio>();
            services.AddScoped<IUsuarioDominioServicio, UsuariosDominioServicio>();
            services.AddScoped<IUnidadTrabajoRRHH, UnidadTrabajoRRHH>();



            services.BuildServiceProvider();

        }
    }
}
