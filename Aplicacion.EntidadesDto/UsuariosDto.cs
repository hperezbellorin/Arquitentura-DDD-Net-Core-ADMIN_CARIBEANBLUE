using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.EntidadesDto
{
   public class UsuariosDto
    {
        public int Iduser { get; set; }
        public string Nombres { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int? IdRol { get; set; }
        public string Ubicacion { get; set; }
        public string Email { get; set; }
        public int? Estado { get; set; }
        public string FechaInactivo { get; set; }
        public string Ip { get; set; }
        public int? TipoUser { get; set; }
        public string Sexo { get; set; }
        public int? TelefonoDomicilio { get; set; }
        public int? TelefoCelular { get; set; }
        public string Cedula { get; set; }
        public string EstadoCivil { get; set; }
        public string Direccion { get; set; }
        public int? Ciudad { get; set; }
        public int? Departamento { get; set; }
    }
}
