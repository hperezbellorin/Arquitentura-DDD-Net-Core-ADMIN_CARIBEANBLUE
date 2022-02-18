using Dominio.Contratos.UnidadTrabajo;
using Dominio.Entidades.ADMIN;
using Dominio.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Negocio
{
    public class MenusDominioServicio : IAspMenusDominioServicios
    {
        private readonly IUnidadTrabajoADMIN _unidadTrabajoADMIN;
        public MenusDominioServicio(IUnidadTrabajoADMIN unidadTrabajoADMIN)
        {
            this._unidadTrabajoADMIN = unidadTrabajoADMIN;
        }
        public Task<Aspetmenus> buscarPaisporId(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Create(Aspetmenus probabilidades)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Edit(Aspetmenus probabilidades)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Aspetmenus>> GetMenusList(int IdPadre)
        {
            return _unidadTrabajoADMIN.MenusDB.Lista().Where(x => x.PadreId == IdPadre).ToList();
          
        }
    }
}
