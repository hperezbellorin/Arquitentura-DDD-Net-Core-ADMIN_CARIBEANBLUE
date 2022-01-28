
using Dominio.Contratos.Repositorios;
using Dominio.Contratos.UnidadTrabajo;
using Infraestructura.DBContext.RRHH;
using Infraestructura.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
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

        private readonly RRHHContext contextoDB1;


        public UnidadTrabajoRRHH(RRHHContext _contextoDB1)
        {
         this.contextoDB1 = _contextoDB1;
        }
        
        public IUsuariosDominioRepositorio UsuariosDB
        {// Repositorio Entidad Porbabilidades de Ries
            get
            {
                usuariosRepositorio = new UsuariosRepositorio(contextoDB1);
                return usuariosRepositorio;
            }
        }

        public IEmpleadosDominioRepositorio EmpleadosDB
        {// Repositorio Entidad Porbabilidades de Ries
            get
            {
                empleadosRepositorio = new EmpleadosRepositorio(contextoDB1);
                return empleadosRepositorio;
            }
        }


        public IMarcacionesDominioRepositorio MarcacionesDB
        {
            get
            {
                marcacionesRepositorio = new MarcacionesRepositorios(contextoDB1);
                return marcacionesRepositorio;
            }
        }
    public IRelojes RelosDB
        {
            get
            {
                relojes = new RelojRepositorio(contextoDB1);
                return relojes;
            }
        }




        //public IMenu MenuDB => throw new NotImplementedException();

        //public IPrivilegio PrivilegioDB => throw new NotImplementedException();


        
        public  void commit()
        {
            try
            {
                if (disposed == true)
                {
                    

                }
              

                contextoDB1.SaveChanges();
                if (contextoDB1.Database.CurrentTransaction != null)
                {
                    contextoDB1.Database.CurrentTransaction.Commit();
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
               

                throw ex;
            }
            catch (RetryLimitExceededException ex)
            {
                Console.WriteLine(ex);

               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

                throw ex;
            }
        }

        public void RollBack()
        {
            contextoDB1.Database.CurrentTransaction.Rollback();
        }

        public void Disposable()
        {
            GC.KeepAlive(this);
            contextoDB1.Dispose();
        }


        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    contextoDB1.Dispose();
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
