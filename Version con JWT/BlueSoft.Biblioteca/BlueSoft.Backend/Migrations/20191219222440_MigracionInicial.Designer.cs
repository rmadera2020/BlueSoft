﻿// <auto-generated />
using System;
using BlueSoft.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BlueSoft.Backend.Migrations
{
    [DbContext(typeof(BibliotecaDbContext))]
    [Migration("20191219222440_MigracionInicial")]
    partial class MigracionInicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BlueSoft.Backend.Models.Autor", b =>
                {
                    b.Property<Guid>("IdAutor")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("FechaNac");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("IdAutor");

                    b.ToTable("Autor");

                    b.HasData(
                        new
                        {
                            IdAutor = new Guid("7faf24d1-820a-488d-8bcc-eede72bb0768"),
                            Apellidos = "García Marquéz",
                            FechaNac = new DateTime(2019, 12, 19, 17, 24, 39, 428, DateTimeKind.Local).AddTicks(743),
                            Nombre = "Gabriel"
                        },
                        new
                        {
                            IdAutor = new Guid("7ae9692a-1ff8-4353-8a9d-8cc26c086bcc"),
                            Apellidos = "Coelho",
                            FechaNac = new DateTime(2019, 12, 19, 17, 24, 39, 428, DateTimeKind.Local).AddTicks(3566),
                            Nombre = "Paolo"
                        },
                        new
                        {
                            IdAutor = new Guid("0c0c6c64-2340-4047-bdc2-89872d799563"),
                            Apellidos = "Madera González",
                            FechaNac = new DateTime(2019, 12, 19, 17, 24, 39, 428, DateTimeKind.Local).AddTicks(3579),
                            Nombre = "Roberto"
                        });
                });

            modelBuilder.Entity("BlueSoft.Backend.Models.Categoria", b =>
                {
                    b.Property<Guid>("IdCategoria")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("IdCategoria");

                    b.ToTable("Categoria");

                    b.HasData(
                        new
                        {
                            IdCategoria = new Guid("ec300df7-a067-45ca-b3ae-ceee50baec87"),
                            Descripcion = "Novelas hechas televisión",
                            Nombre = "Novela"
                        },
                        new
                        {
                            IdCategoria = new Guid("d23b9a45-1098-4f68-9fa7-07cea02a3c47"),
                            Descripcion = "Novelas Dramáticas",
                            Nombre = "Drama"
                        });
                });

            modelBuilder.Entity("BlueSoft.Backend.Models.Libro", b =>
                {
                    b.Property<Guid>("IdLibro")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ISBN");

                    b.Property<Guid>("IdAutor");

                    b.Property<Guid>("IdCategoria");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("IdLibro");

                    b.HasIndex("IdAutor");

                    b.HasIndex("IdCategoria");

                    b.ToTable("Libro");
                });

            modelBuilder.Entity("BlueSoft.Backend.Models.Usuario", b =>
                {
                    b.Property<Guid>("IdUsuario")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(5000);

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuario");

                    b.HasData(
                        new
                        {
                            IdUsuario = new Guid("90fa2679-2828-43e9-9131-73c726d3f8f0"),
                            Apellidos = "Madera",
                            Email = "robertomadera@gmail.com",
                            Nombre = "Roberto",
                            Password = "lEtCeLbSeLaAM7eolqFuRDBXikElcjcLp15vfR78/e8="
                        });
                });

            modelBuilder.Entity("BlueSoft.Backend.Models.Libro", b =>
                {
                    b.HasOne("BlueSoft.Backend.Models.Autor", "Autor")
                        .WithMany("Libros")
                        .HasForeignKey("IdAutor")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BlueSoft.Backend.Models.Categoria", "Categoria")
                        .WithMany("Libros")
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
