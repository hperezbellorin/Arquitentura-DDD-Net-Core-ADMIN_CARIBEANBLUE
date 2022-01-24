using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Dominio.Entidades.ADMIN;
using Infraestructura.DBContext;
using Infraestructura.DBContext.Seguridad;
using InfraestructuraTransversal.General;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MVC_presentacion.Models;
using Ubiety.Dns.Core;

namespace MVC_presentacion.Controllers
{
    public class InicioController : Controller
    {

        private readonly ISeguridad _seguridad;
        private readonly UserManager<Aspnetusers> _userManager;

        private UserManager<Aspnetusers> _userManager2;
        private readonly SignInManager<Aspnetusers> _signInManager;
        private readonly SeguridadContext _contexto;




        public InicioController(UserManager<Aspnetusers> userManager, SignInManager<Aspnetusers> signInManager, ISeguridad seguridad, SeguridadContext contexto, UserManager<Aspnetusers> userManager2)
        {
            this._userManager = userManager;
            this._userManager2 = userManager2;
            this._signInManager = signInManager;
            this._seguridad = seguridad;
            _contexto = contexto;



        }


        [HttpGet]
        public ActionResult Login()
        {
            var resul = User.Identity.Name;
            ViewBag.Logeado = resul;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(ModelLogin usuario, string returnUrl)

        {

          
            var message = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {


                    //var user = new Aspnetusers();
                    //user = await _userManager.FindByNameAsync(usuario.Login);
                    //await _signInManager.SignInAsync(user, isPersistent: false);
                    // returnUrl = returnUrl == null ? "/" : returnUrl;
                    // return RedirectToLocal(returnUrl);





                    //var usuarios = await _userManager.FindByNameAsync(usuario.Login);


                    // string email = "hperez@dgi.com.ni".TrimEnd();
                    // var usuario1 = await _userManager.FindByEmailAsync(email);
                
                    var result1 = await _signInManager.PasswordSignInAsync (usuario.Login, usuario.Password.TrimEnd()  , false, false);
                    
                    if (result1.Succeeded)
                    {
                     
                        var userIdentity = new ClaimsIdentity("Custom");
                        Response.StatusCode = (int)HttpStatusCode.OK;
                        ViewBag.Correo = "hperezBellorin@dgi.gob.ni";
                       return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        ModelState.AddModelError(nameof(usuario.Email), "Invalid user or password");
                     
                    }
                }
                else
                {
                    Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    message = "Complete todos los campos!";
                    ModelState.AddModelError(nameof(usuario.Email), "Invalid user or password");
                    return View(usuario);
                }
            }
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                string mensaje = string.Empty;
                switch (err.Number)
                {
                    case 109:
                        mensaje = "Problemas con insert"; break;
                    case 110:
                        mensaje = "Más problemas con insert"; break;
                    case 113:
                        mensaje = "Problemas con comentarios"; break;
                    case 156:
                        mensaje = "Error de sintaxis"; break;


                }
            }
            return View(usuario);
            //return Json(new { message });
        }

        [HttpGet]
        public ActionResult Nuevo()
        {
            // ViewBag.Roles = seguridad.ListaRoles();

            //ViewBag.CargoId=seguridad
            return View();
        }
        public async Task<ActionResult> Nuevo(CreateModel usuario)
        {
            try
            {


                var message = string.Empty;

                if (ModelState.IsValid)
                {
                    var userCheck = await _userManager.FindByEmailAsync(usuario.Email);


                    if (userCheck == null)
                    {

                        var user = new Aspnetusers() { UserName = usuario.Login, Email = usuario.Email, PasswordHash = usuario.Password };


                        user.Id = Guid.NewGuid().ToString();
                        var result = await _userManager.CreateAsync(user, user.PasswordHash);
                        if (result.Succeeded)
                        {
                            return RedirectToAction("Login");
                        }
                        else
                        {
                            if (result.Errors.Count() > 0)
                            {
                                foreach (var error in result.Errors)
                                {
                                    ModelState.AddModelError("", error.Description);
                                }
                            }
                            return View(usuario);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("message", "Email already exists.");
                        return View(usuario);
                    }
                }
                else {
                    Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                  
                    ModelState.AddModelError(nameof(usuario.Email), "Complete todos los campos!");
                    return View(usuario);
                }

               




                //  ModelState.Remove("Password");
                //if (ModelState.IsValid)
                //{
                //    var user = new Users
                //    {

                //        UserName = usuario.Login,

                //        PasswordHash = usuario.Password,
                //        Email = usuario.Email,
                //        EmailConfirmed = false,
                //        PhoneNumberConfirmed = true,
                //        LockoutEnabled = false,

                //        AccessFailedCount = 0,
                //    };

                //    //  _userManager2.UserValidators = new UserValidator<Users>(_userManager2) { AllowOnlyAlphanumericUserNames = false }



                //    var result = await _userManager.CreateAsync(user, "Gedgonz791*");
                //    // var result = await _userManager.CreateAsync(user, user.PasswordHash);

                //    if (result.Succeeded)
                //    {

                //    }

                //    else
                //    {
                //        var errors = string.Join(",", result.Errors);
                //        ModelState.AddModelError("", errors);

                //        Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                //        message = errors;
                //         return Json(new { message });
                //        //return View(usuario);
                //    }
                //    //var Guid = user.Id;
                //    //var Mensaje = string.Format(Mensajes.RecuperarContraseña, Guid);
                //    //var Model = new { Titulo = "Contraseña de usuario", Cuerpo = Mensaje, Anio = DateTime.Now.Year };
                //    //if (result.Succeeded)
                //    //{
                //    //    var resultemail = await corrreo.EnvioCorreo(user.Email, "Email", "contraseña de usuario", Model);

                //    //    var miembro = new Miembrodto
                //    //    {
                //    //        Apellido = usuario.Apellido,
                //    //        CargoId = usuario.CargoId,
                //    //        EsBorrado = false,
                //    //        Nombre = usuario.Nombre,
                //    //        UsuarioId = user.Id

                //    //    };
                //    //    await _miembroAplicacionServicio.guardarMiembro(miembro);
                //    //    var userrol = new UsuarioRol
                //    //    {
                //    //        EsBorrado = false,
                //    //        RoleId = usuario.RoleId,
                //    //        UserId = user.Id
                //    //    };
                //    //    seguridad.CrearUsuarioRoles(userrol);
                //    // Response.StatusCode = (int)HttpStatusCode.OK;
                //    // message = resultemail ? "Se le ha enviado un correo electronico para la para la confirmación de Contraseña!" : "Ocurrio un problema de envio de correo!";
                //    // return RedirectToAction("Index", "Home");
                //    //}
                //    //else
                //    //{
                //    //    ModelState.AddModelError(string.Empty, "Login Failed");
                //    //    return View(usuario);
                //    //}

                //}
                //else
                //{

                //    Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                //    message = "Favor verifique todos los campos!";
                //}
                //// return Json(new { message });
                //return View();
            }
            catch (Exception exc)
            {
                // Logger.LogError(exc, $"{nameof(SaveChanges)} db update error: {exc?.InnerException?.Message}");
                //throw exc;

                exc.InnerException.ToString();
                throw exc;
            }
        }

        [Authorize]
        public async Task<IActionResult> Logout()

        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Inicio");
        }


        //[HttpGet]
        //public ActionResult RoleManager() // Obtener litado de Roles desde Base de datos 
        //{
        //    var ListRoles = _contexto.Roles.ToList();
        //    if (ListRoles != null)
        //    {

        //        List<RolesDto> ListRolesto = _mapper.Map<List<RolesDto>>(ListRoles);


        //        RolesDto modelRol = new RolesDto();

        //        var states = _seguridad.ListaRoles(0);
        //        modelRol.Roles = states;
        //        ViewBag.Roles = ListRolesto;

        //        return View(modelRol);
        //    }

        //    else
        //    {
        //        return View();
        //    }
        //}
        //public IActionResult Index()
        //{
        //    return View();
        //}
        //}
    }

}
