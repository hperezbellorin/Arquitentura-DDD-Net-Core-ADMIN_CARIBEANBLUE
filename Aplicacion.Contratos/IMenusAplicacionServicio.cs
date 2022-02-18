using Aplicacion.EntidadesDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Contratos
{
   public interface IMenusAplicacionServicio
    {
        Task<List<MenusDto>> GeMenusList(int IdPadre);
    }
}
