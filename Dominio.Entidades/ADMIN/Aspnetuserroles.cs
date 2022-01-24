using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Dominio.Entidades.ADMIN
{
    public partial class Aspnetuserroles : IdentityUserRole<string>
    {
      

        public virtual Aspnetroles Role { get; set; }
        public virtual Aspnetusers User { get; set; }
    }
}
