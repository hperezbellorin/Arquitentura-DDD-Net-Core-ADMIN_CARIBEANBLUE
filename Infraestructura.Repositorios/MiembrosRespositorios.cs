using Dominio.Contratos.Repositorios;
using Dominio.Entidades.ADMIN;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructura.Repositorios
{
   public class MiembrosRespositorios : BaseRepositorio<Aspnetmiembros>, IAspMiembrosDominioRepositorio
    {
        public MiembrosRespositorios(DbContext contexto) : base(contexto)
        {

        }
    }
}
