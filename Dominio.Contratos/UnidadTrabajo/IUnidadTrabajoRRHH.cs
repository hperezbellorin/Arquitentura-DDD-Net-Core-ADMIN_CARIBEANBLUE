using Dominio.Contratos.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Contratos.UnidadTrabajo
{
    public interface IUnidadTrabajoRRHH : IDisposable
    {
        //IMenu MenuDB { get; }
        //IPrivilegio PrivilegioDB { get; }

        IUsuariosDominioRepositorio UsuariosDB { get; }

        IEmpleadosDominioRepositorio EmpleadosDB { get; }

        IMarcacionesDominioRepositorio MarcacionesDB { get; }

        IRelojes RelosDB { get; }

      

        void commit();
        void RollBack();
        void Disposable();
    }
}
