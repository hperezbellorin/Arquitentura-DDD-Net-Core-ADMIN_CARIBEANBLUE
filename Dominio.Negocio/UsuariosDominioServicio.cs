using Dominio.Contratos.UnidadTrabajo;
using Dominio.Entidades.RRHH;
using Dominio.Servicios;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Dominio.Negocio
{
    public class UsuariosDominioServicio : IUsuarioDominioServicio
    {
        private readonly IUnidadTrabajoRRHH unidadTrabajoRRHH;

        public UsuariosDominioServicio(IUnidadTrabajoRRHH _unidadTrabajoRRHH)
        {
            this.unidadTrabajoRRHH = _unidadTrabajoRRHH;
        }


        public Task<Tusuarios> buscarPaisporId(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Create(Tusuarios probabilidades)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Edit(Tusuarios probabilidades)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Tusuarios>> GetMenuList()
        {
            return unidadTrabajoRRHH.UsuariosDB.Lista().ToList();

        }
    }
}
