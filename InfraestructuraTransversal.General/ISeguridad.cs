
using Dominio.Entidades.ADMIN;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace InfraestructuraTransversal.General
{
    public interface ISeguridad
    {
        List<SelectListItem> ListaRoles(int idtipoidentificacion = 0);
        List<Aspnetusers> ListaUsuario();
        Task<bool> ActualizarEmailConfirmacionAync(Aspnetusers usuario);
        Task<IdentityResult> ActualizarPasswordUsuarioAync(Aspnetusers usuario, string newPasword);
        Task<bool> EliminarUsuario(Aspnetusers usuario);
        Task<bool> CrearRoles(Aspnetroles roles);
        bool CrearUsuarioRoles(Aspnetuserroles roles);
        ////UsuariosRoles RolUsuario(Guid userid);

    }
}
