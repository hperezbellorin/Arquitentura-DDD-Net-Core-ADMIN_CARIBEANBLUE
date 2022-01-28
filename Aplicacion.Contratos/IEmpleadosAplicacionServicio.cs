using Aplicacion.EntidadesDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Contratos
{
    public interface IEmpleadosAplicacionServicio
    {
         Task<List<EmpleadosDto>> GetEmleadosList();
        Task<bool> guardarEmpleado(EmpleadosDto empleado);

        Task<bool> eliminarEmpleado(string id);
        Task<bool> actualizarEmpleado(EmpleadosDto empleado);
        Task<EmpleadosDto> buscarempleadoporId(int Id);
    }
}
