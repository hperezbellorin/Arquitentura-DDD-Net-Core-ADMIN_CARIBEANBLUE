using System;
using System.Collections.Generic;

namespace Dominio.Entidades.ADMIN
{
    public partial class Aspetmenus
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
