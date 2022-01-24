using Dominio.Entidades.ADMIN;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servicios
{
   public  interface IAspMenusDominioServicios
    {
        Task<List<Aspetmenus>> GetMenusList();
        Task<bool> Create(Aspetmenus probabilidades);

        Task<bool> Edit(Aspetmenus probabilidades);

        Task<bool> Eliminar(int Id);
        Task<Aspetmenus> buscarPaisporId(int Id);
    }
}
