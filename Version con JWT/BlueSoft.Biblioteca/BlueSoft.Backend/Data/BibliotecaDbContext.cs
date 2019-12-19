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
            //Clave sha256 : B1u3s0ft2019
            modelBuilder.Entity<Usuario>().HasData(
                   new Usuario { Nombre="Roberto", Apellidos="Madera", Email="robertomadera@gmail.com", Password= "f2c8de2abd774eeaff6466a0f6a306982ab7c21432afe2979082469f773098ef" }
                 );
        }

        public DbSet<BlueSoft.Backend.Models.Autor> Autor { get; set; }

        public DbSet<BlueSoft.Backend.Models.Categoria> Categoria { get; set; }

        public DbSet<BlueSoft.Backend.Models.Libro> Libro { get; set; }
        public DbSet<BlueSoft.Backend.Models.Usuario> Usuario { get; set; }

    }
}
