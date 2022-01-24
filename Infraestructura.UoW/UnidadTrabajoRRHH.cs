
using Dominio.Contratos.Repositorios;
using Dominio.Contratos.UnidadTrabajo;
using Infraestructura.DBContext.RRHH;
using Infraestructura.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructura.UoW
{
    public class UnidadTrabajoRRHH : IUnidadTrabajoRRHH
    {
        private bool disposed = false;
       
        private IUsuariosDominioRepositorio usuariosRepositorio;
        private IEmpleadosDominioRepositorio empleadosRepositorio;
        private IMarcacionesDominioRepositorio marcacionesRepositorio;
        private IRelojes relojes;

        private readonly RRHHContext contextoDB;


        public UnidadTrabajoRRHH(RRHHContext _contextoDB)
        {
            this.contextoDB = _contextoDB;
        }

        public IUsuariosDominioRepositorio UsuariosDB
        {// Repositorio Entidad Porbabilidades de Ries
            get
            {
                usuariosRepositorio = new UsuariosRepositorio(contextoDB);
                return usuariosRepositorio;
            }
        }

        public IEmpleadosDominioRepositorio EmpleadosDB
        {// Repositorio Entidad Porbabilidades de Ries
            get
            {
                empleadosRepositorio = new EmpleadosRepositorio(contextoDB);
                return empleadosRepositorio;
            }
        }


        public IMarcacionesDominioRepositorio MarcacionesDB
        {
            get
            {
                marcacionesRepositorio = new MarcacionesRepositorios(contextoDB);
                return marcacionesRepositorio;
            }
        }
    public IRelojes RelosDB
        {
            get
            {
                relojes = new RelojRepositorio(contextoDB);
                return relojes;
            }
        }




        //public IMenu MenuDB => throw new NotImplementedException();

        //public IPrivilegio PrivilegioDB => throw new NotImplementedException();



        public void commit()
        {
            contextoDB.SaveChanges();
            if (contextoDB.Database.CurrentTransaction != null)
            {
                contextoDB.Database.CurrentTransaction.Commit();
            }
        }

        public void RollBack()
        {
            contextoDB.Database.CurrentTransaction.Rollback();
        }

        public void Disposable()
        {
            GC.KeepAlive(this);
            contextoDB.Dispose();
        }

        public void Dispose(bool disposing)
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
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
