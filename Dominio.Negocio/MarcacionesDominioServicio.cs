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
    public class MarcacionesDominioServicio : IMarcacionesDominioServicios
    {
        private readonly IUnidadTrabajoRRHH unidadTrabajoRRHH;
        public Task<Marcaciones> buscarPaisporId(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Create(Marcaciones probabilidades)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Edit(Marcaciones probabilidades)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int Id)
        {
            throw new NotImplementedException();
        }

        public async  Task<List<Marcaciones>> GetMenuList()
        {
            return unidadTrabajoRRHH.MarcacionesDB.Lista().ToList();
        }
    }
}
