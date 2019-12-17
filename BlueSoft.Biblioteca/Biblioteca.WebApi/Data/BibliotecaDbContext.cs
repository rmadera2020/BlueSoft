using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Biblioteca.WebApi.Entidades;

namespace Biblioteca.WebApi.Data
{
    public class BibliotecaDbContext : DbContext
    {
        public BibliotecaDbContext (DbContextOptions<BibliotecaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Biblioteca.WebApi.Entidades.Autor> Autor { get; set; }

        public DbSet<Biblioteca.WebApi.Entidades.Categoria> Categoria { get; set; }

        public DbSet<Biblioteca.WebApi.Entidades.Libro> Libro { get; set; }
    }
}
