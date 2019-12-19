using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlueSoft.Backend.Models;

namespace BlueSoft.Backend.Data
{
    public class BibliotecaDbContext : DbContext
    {
        public BibliotecaDbContext (DbContextOptions<BibliotecaDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                base.OnModelCreating(modelBuilder);
                modelBuilder.Entity<Autor>().HasData(
                new Autor { Nombre = "Gabriel", Apellidos="García Marquéz", FechaNac=DateTime.Now},
                new Autor { Nombre = "Paolo", Apellidos = "Coelho", FechaNac = DateTime.Now },
                new Autor { Nombre = "Roberto", Apellidos = "Madera González", FechaNac = DateTime.Now }
                 );
                modelBuilder.Entity<Categoria>().HasData(
                new Categoria { Nombre = "Novela", Descripcion = "Novelas hechas televisión"},
                new Categoria { Nombre = "Drama", Descripcion  = "Novelas Dramáticas" }                
                 );
                 modelBuilder.Entity<Libro>().HasData(
                 new Libro { Nombre = "El Coronel no tiene quien le escriba",  IdAutor=1, IdCategoria=1, ISBN="123"},
                  new Libro { Nombre = "El General en su laberinto", IdAutor = 1, IdCategoria = 1, ISBN = "123" }
                 );


        }

        public DbSet<BlueSoft.Backend.Models.Autor> Autor { get; set; }

        public DbSet<BlueSoft.Backend.Models.Categoria> Categoria { get; set; }

        public DbSet<BlueSoft.Backend.Models.Libro> Libro { get; set; }
    }
}
