using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_presentacion.Models
{
    public class ModelUsuario
    {
       
        
    }
    public class ModelLogin
    {

        [Required(ErrorMessage = "El campo Login no puede estar vacio")]
        public string Login { get; set; }
        [Required(ErrorMessage = "El campo Password no puede estar vacio")]
        public string Password { get; set; }
        public string Email { get; set; }
    }



    public class CreateModel
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }

}
