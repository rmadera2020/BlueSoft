
namespace Biblioteca.WebApi.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(100, ErrorMessage = "The field lenght {0} is exceded, is between {2} and {1}", MinimumLength = 3)]
        [Display(Name ="Categoria")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(100, ErrorMessage = "The field lenght {0} is exceded, is between {2} and {1}", MinimumLength = 3)]
        public string Descripcion { get; set; }

        public virtual ICollection<Libro> Libros { get; set; }

    }
}
