using System;
using System.Collections.Generic;

namespace Dominio.Entidades.ADMIN
{
    public partial class Aspnetprivilegios
    {
        public int Id { get; set; }
        public int IdRol { get; set; }
        public int IdMenu { get; set; }
        public int IdSubmenu { get; set; }
    }
}
