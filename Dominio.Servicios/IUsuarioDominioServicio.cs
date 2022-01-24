using Dominio.Entidades.RRHH;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servicios
{
    public interface IUsuarioDominioServicio
    {

        Task<List<Tusuarios>> GetMenuList();
        Task<bool> Create(Tusuarios probabilidades);

        Task<bool> Edit(Tusuarios probabilidades);

        Task<bool> Eliminar(int Id);
        Task<Tusuarios> buscarPaisporId(int Id);
    }
}
