using Dominio.Entidades.RRHH;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servicios
{
    public interface IEmpleadosDominioServicios
    {
        Task<List<Empleados>> GetEmployeesList();
        Task<bool> Create(Empleados probabilidades);

        Task<bool> Edit(Empleados probabilidades);

        Task<bool> Eliminar(int Id);
        Task<Empleados> buscarPaisporId(int Id);
    }
}
