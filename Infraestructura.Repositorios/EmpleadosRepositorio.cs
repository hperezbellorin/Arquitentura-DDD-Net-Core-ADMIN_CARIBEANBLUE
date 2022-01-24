using Dominio.Contratos.Repositorios;
using Dominio.Entidades.RRHH;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructura.Repositorios
{
   public  class EmpleadosRepositorio : BaseRepositorio<Empleados>, IEmpleadosDominioRepositorio
    {
        public EmpleadosRepositorio(DbContext contexto) : base(contexto)
        {

        }
    }
}
