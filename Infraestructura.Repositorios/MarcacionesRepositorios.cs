using Dominio.Contratos.Repositorios;
using Dominio.Entidades.RRHH;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructura.Repositorios
{
  public  class MarcacionesRepositorios : BaseRepositorio<Marcaciones>, IMarcacionesDominioRepositorio
    {
        public MarcacionesRepositorios(DbContext contexto) : base(contexto)
        {

        }
    }
}
