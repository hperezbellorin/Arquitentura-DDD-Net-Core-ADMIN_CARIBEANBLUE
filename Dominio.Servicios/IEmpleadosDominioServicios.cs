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
        Task<bool> Create(Empleados empleado);

        Task<bool> Edit(Empleados empleados);

        Task<bool> Eliminar(int Id);
        Task<Empleados> buscarEmpleadosporId(int Id);
    }
}
