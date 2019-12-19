using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlueSoft.Backend.Models
{
    public class Usuario
    {
        public Usuario()
        {
            this.IdUsuario = Guid.NewGuid();
        }


        [Key]
        public Guid IdUsuario { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(100, ErrorMessage = "The field lenght {0} is exceded, is between {2} and {1}", MinimumLength = 3)]
        [Display(Name = "Nombre")]
        
        public string Nombre { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(100, ErrorMessage = "The field lenght {0} is exceded, is between {2} and {1}", MinimumLength = 3)]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(100, ErrorMessage = "The field lenght {0} is exceded, is between {2} and {1}", MinimumLength = 3)]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "The Email field is not a valid e-mail address.")]        
        public string Email { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(5000, ErrorMessage = "The field lenght {0} is exceded, is between {2} and {1}", MinimumLength = 8)]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }




    }
}
