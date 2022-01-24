using System;
using System.Collections.Generic;

namespace Dominio.Entidades.RRHH
{
    public partial class Marcaciones
    {
        public int Id { get; set; }
        public int IdEmpleado { get; set; }
        public int IdReloj { get; set; }
    }
}
