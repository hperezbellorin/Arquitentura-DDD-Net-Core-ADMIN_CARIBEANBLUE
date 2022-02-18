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

        public async  Task<List<MenusDto>> GeMenusList(int IdPadre)
        {
            var menusList = await _menusDominioServicio.GetMenusList(IdPadre); 
            List<MenusDto> menusListDto = new List<MenusDto>();

          

            foreach (var item in menusList)
            {
                MenusDto mmnus = new MenusDto();
                mmnus.Area = item.Area;
                mmnus.PadreId = item.PadreId;
                mmnus.ControlId = item.ControlId;
                mmnus.Controlador = item.Controlador;
                mmnus.Accion = item.Accion;
                mmnus.Descripcion = item.Descripcion;
                mmnus.Nombre = item.Nombre.TrimEnd();
                menusListDto.Add(mmnus);
            }

            return menusListDto;
        }
    }
}
