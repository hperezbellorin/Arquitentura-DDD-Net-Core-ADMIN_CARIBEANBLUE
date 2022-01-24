using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Dominio.Entidades.ADMIN
{
    public partial class Aspnetuserclaims : IdentityUserClaim<string>
    {
     

        public virtual Aspnetusers User { get; set; }


    }
}
