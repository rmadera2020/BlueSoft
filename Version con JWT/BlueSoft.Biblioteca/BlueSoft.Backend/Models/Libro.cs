

namespace BlueSoft.Backend.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class Libro
    {

        public Libro()
        {
            this.IdLibro = Guid.NewGuid();
        }


        [Key]
        public Guid IdLibro { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(100, ErrorMessage = "The field lenght {0} is exceded, is between {2} and {1}", MinimumLength = 3)]
        [Display(Name = "Libro")]
        public string Nombre { get; set; }

        public Guid IdAutor { get; set; }
        public Autor Autor { get; set; }

        public Guid IdCategoria { get; set; }
        public Categoria Categoria { get; set; }

        public string ISBN { get; set; }

    }
}
