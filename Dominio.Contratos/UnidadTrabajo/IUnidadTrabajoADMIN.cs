using Dominio.Contratos.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Contratos.UnidadTrabajo
{
   public interface IUnidadTrabajoADMIN : IDisposable
    {
        IAspMenuDominioRepositorio MenusDB { get; }

        IAspMiembrosDominioRepositorio MiembrosDB { get; }

        IPrivilegioDominioRepositorio PrivilegiosDB { get; }

        void commit();
        void RollBack();
        void Disposable();
    }
}
