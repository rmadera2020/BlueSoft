using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlueSoft.Backend.Models
{
    public class Categoria
    {
        public Categoria()
        {
            this.IdCategoria = Guid.NewGuid();
        }

        [Key]
        public Guid IdCategoria { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(100, ErrorMessage = "The field lenght {0} is exceded, is between {2} and {1}", MinimumLength = 3)]
        [Display(Name = "Categoria")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(100, ErrorMessage = "The field lenght {0} is exceded, is between {2} and {1}", MinimumLength = 3)]
        public string Descripcion { get; set; }

        public virtual ICollection<Libro> Libros { get; set; }

    }
}
