using Aplicacion.Contratos;
using Aplicacion.EntidadesDto;
using Dominio.Servicios;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Servicio
{
    public class MenuAplicacionServicio : IMenusAplicacionServicio
    {

        private IAspMenusDominioServicios _menusDominioServicio;
        public MenuAplicacionServicio(IAspMenusDominioServicios menusDominioServicio)
        {
            this._menusDominioServicio = menusDominioServicio;
        }

        public async  Task<List<MenusDto>> GeMenusList()
        {
            var menusList = await _menusDominioServicio.GetMenusList();
            List<MenusDto> menusListDto = new List<MenusDto>();

          

            foreach (var item in menusList)
            {
                MenusDto menusdto = new MenusDto();
                menusdto.MenuId = item.MenuId;
                menusdto.PadreId = item.PadreId;
                menusdto.Nombre = item.Nombre;
                menusdto.Controlador = item.Controlador;
                menusdto.ControlId = item.ControlId;
                menusdto.Descripcion = item.Descripcion;
                menusListDto.Add(menusdto);
            }

            return menusListDto;
        }
    }
}
