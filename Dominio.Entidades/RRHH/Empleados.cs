using System;
using System.Collections.Generic;

namespace Dominio.Entidades.RRHH
{
    public partial class Empleados
    {
        public int Id { get; set; }
        public string Estado { get; set; }
        public string Nombres { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Cedula { get; set; }
        public string Correo { get; set; }
        public string EstadoCivil { get; set; }
        public string Direccion { get; set; }
        public string Cargo { get; set; }
        public string Departamento { get; set; }
        public string NameImage { get; set; }
        public string Image { get; set; }
        public string FechaIngreso { get; set; }
        public string FechaModificacion { get; set; }
        public bool? IsActive { get; set; }
    }
}
