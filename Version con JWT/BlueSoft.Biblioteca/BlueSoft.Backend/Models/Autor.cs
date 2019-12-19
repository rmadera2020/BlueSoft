

namespace BlueSoft.Backend.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class Autor
    {
        public Autor()
        {
            this.IdAutor = Guid.NewGuid();
        }

        [Key]
        public Guid IdAutor { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(100, ErrorMessage = "The field lenght {0} is exceded, is between {2} and {1}", MinimumLength = 3)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(100, ErrorMessage = "The field lenght {0} is exceded, is between {2} and {1}", MinimumLength = 3)]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]        
        public DateTime FechaNac { get; set; }

        public virtual ICollection<Libro> Libros { get; set; }


    }
}
