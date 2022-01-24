

using Dominio.Entidades.ADMIN;
using Infraestructura.DBContext;
using Infraestructura.DBContext.Seguridad;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InfraestructuraTransversal.General
{
    public class Seguridad : ISeguridad
    {

        private readonly UserManager<Aspnetusers> _userManager;
        private readonly SignInManager<Aspnetusers> _signInManager;
        private readonly SeguridadContext _contexto;
        private readonly RoleManager<Aspnetroles> _roleManager;
        public Seguridad(UserManager<Aspnetusers> userManager, SignInManager<Aspnetusers> signInManager, SeguridadContext contexto, RoleManager<Aspnetroles> roleManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._contexto = contexto;
            this._roleManager = roleManager;
        }
        public Task<bool> ActualizarEmailConfirmacionAync(Aspnetusers usuario)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> ActualizarPasswordUsuarioAync(Aspnetusers usuario, string newPasword)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CrearRoles(Aspnetroles roles)
        {
            var actualizado = false;
            try
            {



                var RoleManager = await _roleManager.CreateAsync(roles);

                actualizado = RoleManager.Succeeded;


            }
            catch (Exception ex)
            {

                throw ex;
            }
            return actualizado;
        }

        public bool CrearUsuarioRoles(Aspnetusers roles)
        {
            throw new NotImplementedException();
        }

        public bool CrearUsuarioRoles(Aspnetuserroles roles)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EliminarUsuario(Aspnetusers usuario)
        {
            throw new NotImplementedException();
        }

        public List<SelectListItem> ListaRoles(int idtipoidentificacion = 0)
        {
            var itemidentificacion = new List<SelectListItem>();
            try
            {

                ///Invocamos operacion de la capa de Dominio.
                var ListRoles = _contexto.Aspnetroles.ToList();
                itemidentificacion.Add(new SelectListItem
                {
                    Text = "--Seleccione una Opcion--",
                    Value = null
                });
                ///Si devuelve registros los vaciamos a un DTO.
                if (ListRoles != null && ListRoles.Count > 0)
                {
                    itemidentificacion.AddRange((from t in ListRoles
                                                 select new SelectListItem
                                                 {
                                                     Text = t.Name,
                                                     Value = t.Id.ToString(),
                                                     Selected = (t.Id.Equals(idtipoidentificacion))
                                                 }).ToList());

                }
                if (itemidentificacion.Where(x => x.Selected).Count() == 0)
                {
                    itemidentificacion.Where(x => x.Text == "--Seleccione un Rol--").ToList().ForEach(z => z.Selected = true);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return itemidentificacion;
        }

        public List<Aspnetusers> ListaUsuario()
        {
            throw new NotImplementedException();
        }

        //public UsuariosRoles RolUsuario(Guid userid)
        //{
        //    return _contexto.UserRoles.Where(x => x.UserId.ToString() == userid.ToString()).FirstOrDefault();
        //}
    }

}
