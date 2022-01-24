using Dominio.Entidades.ADMIN;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servicios
{
   public  interface IAspMiembrosDominioServicios
    {
        Task<List<Aspnetmiembros>> GetMiembrosList();
        Task<bool> Create(Aspnetmiembros probabilidades);

        Task<bool> Edit(Aspnetmiembros probabilidades);

        Task<bool> Eliminar(int Id);
        Task<Aspnetmiembros> buscarPaisporId(int Id);
    }
}
