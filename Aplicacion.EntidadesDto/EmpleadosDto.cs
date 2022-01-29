using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Aplicacion.EntidadesDto
{
   public class EmpleadosDto
    {
        public int Id { get; set; }
        public string Estado { get; set; }
        [Required(ErrorMessage = "El campo Nombre no puede estar vacio")]
        public string Nombres { get; set; }

        public string NombreCompleto { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        [Required(ErrorMessage = "El campo Cedula no puede estar vacio")]

        [StringLength(14, MinimumLength = 14)]
        public string Cedula { get; set; }

        public string FechaIngreso { get; set; }
       
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Required(ErrorMessage = "El campo correo no puede estar vacio")]
        public string Correo { get; set; }
        public string EstadoCivil { get; set; }
        public string Direccion { get; set; }
        public string Cargo { get; set; }
        public bool IsActive { get; set; }

    }
}
