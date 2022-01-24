using System;
using System.Collections.Generic;

namespace Dominio.Entidades.ADMIN
{
    public partial class Aspnetmiembros
    {
        public string MiembroId { get; set; }
        public string UsuarioId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public bool? Estado { get; set; }
        public string RoleId { get; set; }
        public string Cedula { get; set; }
        public string Direccion { get; set; }
        public int? Telefono { get; set; }
        public string Correo { get; set; }
    }
}
