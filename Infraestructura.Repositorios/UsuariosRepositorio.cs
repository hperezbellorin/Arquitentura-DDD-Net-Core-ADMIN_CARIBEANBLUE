


using Dominio.Contratos.Repositorios;
using Dominio.Entidades.RRHH;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructura.Repositorios
{
   public class UsuariosRepositorio : BaseRepositorio<Tusuarios>, IUsuariosDominioRepositorio
    {
        public UsuariosRepositorio(DbContext contexto) : base(contexto)
        {

        }
    }
}
