using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Biblioteca.WebApi.Entidades
{
    public class Libro
    {
        [Key]
        public int IdLibro { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(100, ErrorMessage = "The field lenght {0} is exceded, is between {2} and {1}", MinimumLength = 3)]
        [Display(Name = "Libro")]
        public string Nombre { get; set; }

        public int IdAutor { get; set; }
        public Autor Autor { get; set; }

        public int IdCategoria { get; set; }
        public Categoria Categoria { get; set; }

        public string ISBN { get; set; }

    }
}
