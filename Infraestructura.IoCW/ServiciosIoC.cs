using Aplicacion.Contratos;
using Aplicacion.Servicio;
using Dominio.Contratos.Repositorios;
using Dominio.Contratos.UnidadTrabajo;
using Dominio.Negocio;
using Dominio.Servicios;

using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructura.IoCW
{
    public static class ServiciosIoC
    {
        public static void Servicios(IServiceCollection services)

        {
            services.AddScoped<IUsuariosAplicacionServicio, UsuarioAplicacionServicio>();


           


            services.BuildServiceProvider();

        }
    }
}
