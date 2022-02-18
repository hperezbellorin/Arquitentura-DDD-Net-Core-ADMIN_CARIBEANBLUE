using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Contratos;
using Aplicacion.Servicio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MVC_presentacion.Areas.RRHH.Controllers
{
    [Area("RRHH")]
    public class HomeController : Controller
    {
         private readonly IUsuariosAplicacionServicio _usuariosAplicacionServicio;
       
    
        const string SessionIdMenu = "_IdMenu";
        public HomeController(IUsuariosAplicacionServicio UsuarioAplicacionServicio)
        {
          
               
          
            this._usuariosAplicacionServicio = UsuarioAplicacionServicio;
        }

       
        public async Task<IActionResult> Index()
        {


            try
            {
                HttpContext.Session.SetInt32(SessionIdMenu, 1);

                var data = await _usuariosAplicacionServicio.GetUsuariosList();
                ViewBag.Datos = data;
                // ViewBag.Idprobabilidad = _ProbalilidadAplicacionServicio.ObteneerTodos().Result.FirstOrDefault().Idprobabilidad;
                return View(data);
            }
            catch (Exception e)
            {

                throw e;
            }


        }
    }
}
