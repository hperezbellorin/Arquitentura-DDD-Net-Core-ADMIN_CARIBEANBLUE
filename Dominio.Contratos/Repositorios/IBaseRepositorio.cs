using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Contratos.Repositorios
{
    public interface IBaseRepositorio<T> where T : class
    {
        bool Add(T Entidad);
        bool Update(T Entidad);
        IEnumerable<T> Lista();

        Task<IQueryable<T>> ObtenerTodo();
        /// <summary>
        /// Obtiene todos los lementos del tipo de entidad segun el predicado
        /// </summary>
        /// <param name="pericado">expression labda</param>
        /// <returns></returns>
        Task<IQueryable<T>> ObtenerTodo(Expression<Func<T, bool>> predicado);
        /// <summary>
        /// Consulta a la base de datos por medio de query
        /// </summary>
        /// <returns></returns>
        ///   /// <summary>
        /// Consulta de busqueda de una entidad
        /// </summary>
        /// <param name="Identidad">Id de la entidad</param>
        /// <returns></returns>
        Task<T> Buscar(object Identidad);

        Task<bool> Eliminar(T entidad);


    }
}
