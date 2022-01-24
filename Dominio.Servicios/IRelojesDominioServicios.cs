using Dominio.Entidades.RRHH;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servicios
{
    public interface IRelojesDominioServicios
    {
        Task<List<Relojes>> GetInfoList();
        Task<bool> Create(Relojes probabilidades);

        Task<bool> Edit(Relojes probabilidades);

        Task<bool> Eliminar(int Id);
        Task<Relojes> buscarPaisporId(int Id);
    }
}
