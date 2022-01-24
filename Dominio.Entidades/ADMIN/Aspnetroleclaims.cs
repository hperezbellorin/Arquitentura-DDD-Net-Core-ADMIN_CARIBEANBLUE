using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Dominio.Entidades.ADMIN
{
    public partial class Aspnetroleclaims :IdentityRoleClaim<string>
    {
      
        public virtual Aspnetroles Role { get; set; }
    }
}
