using System;
using System.Collections.Generic;



namespace Dominio.Entidades.RRHH
{
    public partial class Tprivilegio
    {
        public int Id { get; set; }
        public int IdRol { get; set; }
        public int IdMenu { get; set; }
        public int IdSubmenu { get; set; }
    }
}
