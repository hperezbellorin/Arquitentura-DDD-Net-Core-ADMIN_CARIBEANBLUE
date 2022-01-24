using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.EntidadesDto
{
  public   class MenusDto
    {
        public int MenuId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Area { get; set; }
        public string Controlador { get; set; }
        public string Accion { get; set; }
        public string Icono { get; set; }
        public int? PadreId { get; set; }
        public int? ControlId { get; set; }
        public int? Orden { get; set; }
        public int? TipoMenu { get; set; }
        public int? ShowItem { get; set; }
        public string Modulo { get; set; }
        public bool? Estado { get; set; }
        public int? IdUsuarioModificacion { get; set; }

    }
}
