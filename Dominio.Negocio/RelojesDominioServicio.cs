using Dominio.Contratos.UnidadTrabajo;
using Dominio.Entidades.RRHH;
using Dominio.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Negocio
{
    public class RelojesDominioServicio : IRelojesDominioServicios
    {
        private readonly IUnidadTrabajoRRHH unidadTrabajoRRHH;
        public Task<Relojes> buscarPaisporId(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Create(Relojes probabilidades)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Edit(Relojes probabilidades)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Relojes>> GetInfoList()
        {
            return unidadTrabajoRRHH.RelosDB .Lista().ToList();
        }
    }
}
