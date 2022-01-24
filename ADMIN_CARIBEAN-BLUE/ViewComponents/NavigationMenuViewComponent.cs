using Aplicacion.Contratos;
using Aplicacion.EntidadesDto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_presentacion.ViewComponents
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IMenusAplicacionServicio _menuAplicacionServicio;
        public NavigationMenuViewComponent(IMenusAplicacionServicio menuAplicacionServicio)
        {
            this._menuAplicacionServicio = menuAplicacionServicio;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await _menuAplicacionServicio.GeMenusList();

            List<MenusDto> menuList = new List<MenusDto>();
            ArrayList menus = new ArrayList();
            foreach (var item in items)
            {
                MenusDto mmnus = new MenusDto();
                if (!menus.Contains(item.PadreId))
                {
                    menus.Add(item.PadreId);
                    mmnus.Area = item.Area;
                    mmnus.PadreId = item.PadreId;
                    mmnus.ControlId = item.ControlId;
                    mmnus.Controlador = item.Controlador;
                    mmnus.Accion = item.Accion;
                    mmnus.Descripcion = item.Descripcion;
                    mmnus.Nombre = item.Nombre.TrimEnd();
                    menuList.Add(mmnus);

                }

            }
            ViewBag.data = items; // llenar WiewBag para obtner los submenus

            return View(menuList);
        }
    }
}
