using Aplicacion.Contratos;
using Aplicacion.Servicio;

using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructura.IoC
{
    public static class ServiciosIoC
    {
        public static void Servicios(IServiceCollection services)
        {

            services.AddScoped<IUsuariosAplicacionServicio, UsuariosAplicacionServico>();





            services.BuildServiceProvider();

        }
    }
}
