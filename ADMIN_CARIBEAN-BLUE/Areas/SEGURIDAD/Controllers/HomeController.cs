using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ADMIN_CARIBEANBLUE.Areas.SEGURIDAD.Controllers
{
    [Area("SEGURIDAD")]
    public class HomeController : Controller
{
        const string SessionIdMenu = "_IdMenu";
        public IActionResult Index()
    {
            HttpContext.Session.SetInt32(SessionIdMenu, 3);
            return View();
    }
}
}
