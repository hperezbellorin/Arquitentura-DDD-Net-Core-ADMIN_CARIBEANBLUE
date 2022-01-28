
using Dominio.Contratos.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Repositorios
{
    public class BaseRepositorio<T> : IBaseRepositorio<T> where T : class
    {
        protected readonly DbContext BaseDatosContexto;


        protected readonly DbSet<T> BaseDatosColeccion;

        public BaseRepositorio(DbContext contexto)
        {
            this.BaseDatosContexto = contexto;
            this.BaseDatosColeccion = contexto.Set<T>();
        }


        public bool Add(T Entidad)
        {
          
            BaseDatosColeccion.Add(Entidad);
            
            return true;
        }

        public async Task<T> Buscar(object Identidad)
        {
            try
            {
                return await BaseDatosColeccion.FindAsync(Identidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public async Task<bool> Eliminar(T entidad)
        {
            if (BaseDatosContexto.Entry(entidad).State == EntityState.Detached)
            {
                BaseDatosColeccion.Attach(entidad);
            }

            BaseDatosColeccion.Remove(entidad);
            return true;
        }




        public IEnumerable<T> Lista()
        {
            return BaseDatosColeccion.ToList();
        }

        public async Task<IQueryable<T>> ObtenerTodo()
        {
            var query = await BaseDatosColeccion.ToListAsync();
            return query.AsQueryable();
        }

        public async Task<IQueryable<T>> ObtenerTodo(Expression<Func<T, bool>> predicado)
        {
            var query = await BaseDatosColeccion.Where(predicado).ToListAsync();
            return query.AsQueryable();
        }



        public bool Update(T Entidad)
        {
            BaseDatosColeccion.Attach(Entidad);
            BaseDatosContexto.Entry(Entidad).State = EntityState.Modified;
            return true;
        }
    }
}
