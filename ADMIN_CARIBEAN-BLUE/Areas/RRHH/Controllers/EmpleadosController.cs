using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Aplicacion.Contratos;
using Aplicacion.EntidadesDto;
using Dominio.Entidades.RRHH;

using Microsoft.AspNetCore.Mvc;

namespace ADMIN_CARIBEANBLUE.Areas.RRHH.Controllers
{
    [Area("RRHH")]
    public class EmpleadosController : Controller
    {
        private readonly IEmpleadosAplicacionServicio _empleadosAplicacionServicio;
      
        public EmpleadosController(IEmpleadosAplicacionServicio empleadosAplicacionServicio)
        {
            this._empleadosAplicacionServicio = empleadosAplicacionServicio;
          
        }
        public async Task<IActionResult> Index()
                {

                try
                {
                var data = await _empleadosAplicacionServicio.GetEmleadosList();
                ViewBag.Datos = data;
                // ViewBag.Idprobabilidad = _ProbalilidadAplicacionServicio.ObteneerTodos().Result.FirstOrDefault().Idprobabilidad;
                return View(data);
                }
                catch (Exception e)
                {

                throw e;
                }
          
                }
       
        public  IActionResult Create()
        {

            return View();
        }
        public async Task<IActionResult> Edit(int Id)
        {
            var empleado = await _empleadosAplicacionServicio.buscarempleadoporId(Id);
            if (empleado != null)
            {
                return View(empleado);
            }
            else
            {
                return RedirectToAction(nameof(Index));

            }

            
        }

        [HttpPost]
        public async Task<IActionResult> Editar(EmpleadosDto empleadosModel)
        {
            try
            {

           
            bool aanswer = false;
            aanswer = await _empleadosAplicacionServicio.actualizarEmpleado(empleadosModel);
          
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                throw ex;
            }

            

        }


        [HttpPost]
        public async Task<IActionResult> Create(EmpleadosDto empleadosModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   
                    var data = await _empleadosAplicacionServicio.guardarEmpleado(empleadosModel); 
                    return RedirectToAction(nameof(Index));

                }
                else {
                    Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                   
                   // ModelState.AddModelError(nameof(usuario.Email), "Invalid user or password");
                    return View(empleadosModel);
                }

            }
            catch (Exception)
            {

                throw;
            }

            
        }
    }
}
