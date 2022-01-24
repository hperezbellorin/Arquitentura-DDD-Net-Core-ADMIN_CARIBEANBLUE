using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Dominio.Entidades.ADMIN
{
    public partial class Aspnetroles : IdentityRole<string>
    {
        public Aspnetroles()
        {
            Aspnetroleclaims = new HashSet<Aspnetroleclaims>();
            Aspnetuserroles = new HashSet<Aspnetuserroles>();
        }

       

        public virtual ICollection<Aspnetroleclaims> Aspnetroleclaims { get; set; }
        public virtual ICollection<Aspnetuserroles> Aspnetuserroles { get; set; }
    }
}
