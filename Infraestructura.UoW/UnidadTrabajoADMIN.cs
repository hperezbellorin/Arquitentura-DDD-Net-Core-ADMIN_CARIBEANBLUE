using Dominio.Contratos.Repositorios;
using Dominio.Contratos.UnidadTrabajo;
using Infraestructura.DBContext.Seguridad;
using Infraestructura.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructura.UoW
{
    public class UnidadTrabajoADMIN : IUnidadTrabajoADMIN
    {
        private bool disposed = false;
        private IAspMenuDominioRepositorio MenusRepositorio;
        private IAspMiembrosDominioRepositorio AspMiembrosRepositorios;
        private IPrivilegioDominioRepositorio AspPrivilegioRepositorio;

        private readonly SeguridadContext contextoDB;
        public UnidadTrabajoADMIN(SeguridadContext _contextoDB)
        {
            this.contextoDB = _contextoDB;
        }

        private IUsuariosDominioRepositorio usuariosRepositorio;
        private bool disposing;

        public IAspMenuDominioRepositorio MenusDB
        {// Repositorio Entidad Porbabilidades de Ries
            get
            {
                MenusRepositorio = new AspMenusRepositorio(contextoDB);
                return MenusRepositorio;
            }
        }

        public IAspMiembrosDominioRepositorio MiembrosDB
        {// Repositorio Entidad Porbabilidades de Ries
            get
            {
                AspMiembrosRepositorios = new MiembrosRespositorios(contextoDB);
                return AspMiembrosRepositorios;
            }
        }

        public IPrivilegioDominioRepositorio PrivilegiosDB
        {// Repositorio Entidad Porbabilidades de Ries
            get
            {
                AspPrivilegioRepositorio = new PrivilegioRepositorio(contextoDB);
                return AspPrivilegioRepositorio;
            }
        }

        public void commit()
        {
            contextoDB.SaveChanges();
            if (contextoDB.Database.CurrentTransaction != null)
            {
                contextoDB.Database.CurrentTransaction.Commit();
            }
        }

        public void Disposable()
        {
            contextoDB.Database.CurrentTransaction.Rollback();
        }

        public void Dispose(bool v)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    contextoDB.Dispose();
                }
            }

            this.disposed = true;
        }

        public void RollBack()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
