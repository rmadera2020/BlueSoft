
namespace Biblioteca.WebApi.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;


    public class Autor
    {

        [Key]
        public int IdAutor { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(100,ErrorMessage = "The field lenght {0} is exceded, is between {2} and {1}", MinimumLength =3)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(100, ErrorMessage = "The field lenght {0} is exceded, is between {2} and {1}", MinimumLength = 3)]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(12, ErrorMessage = "The field lenght {0} is exceded, is between {2} and {1}", MinimumLength = 3)]
        public string FechaNac { get; set; }

        public virtual ICollection<Libro> Libros { get; set; }

    }
}
