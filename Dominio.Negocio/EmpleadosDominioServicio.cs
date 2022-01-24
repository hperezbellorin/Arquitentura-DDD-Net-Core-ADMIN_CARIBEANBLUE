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
    public class EmpleadosDominioServicio : IEmpleadosDominioServicios
    {
        private readonly IUnidadTrabajoRRHH unidadTrabajoRRHH;

        public EmpleadosDominioServicio(IUnidadTrabajoRRHH _unidadTrabajoRRHH)
        {
            this.unidadTrabajoRRHH = _unidadTrabajoRRHH;
        }
        public Task<Empleados> buscarPaisporId(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Create(Empleados probabilidades)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Edit(Empleados probabilidades)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Empleados>> GetEmployeesList()
        {
            return unidadTrabajoRRHH.EmpleadosDB.Lista().ToList();
            
        }
    }
}
