using System;
using System.Collections.Generic;



namespace Dominio.Entidades.RRHH
{
    public partial class Tmenu
    {
        public int Idm { get; set; }
        public int IdMenu { get; set; }
        public string Descripcion { get; set; }
        public int? PadreId { get; set; }
        public int? Idwebform { get; set; }
        public string NameWebform { get; set; }
        public int? Posicion { get; set; }
        public string Url { get; set; }
        public int? TipoMenu { get; set; }
        public int? ShowItem { get; set; }
        public string Modulo { get; set; }
        public bool? Estado { get; set; }
        public int? IdUsuarioModificacion { get; set; }
    }
}
