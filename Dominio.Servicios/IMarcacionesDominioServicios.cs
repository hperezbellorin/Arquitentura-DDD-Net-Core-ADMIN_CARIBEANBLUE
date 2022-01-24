using Dominio.Entidades.RRHH;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servicios
{
    public interface IMarcacionesDominioServicios
    {
        Task<List<Marcaciones>> GetMenuList();
        Task<bool> Create(Marcaciones probabilidades);

        Task<bool> Edit(Marcaciones probabilidades);

        Task<bool> Eliminar(int Id);
        Task<Marcaciones> buscarPaisporId(int Id);
    }
}
