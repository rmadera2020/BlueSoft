using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlueSoft.Backend.Migrations
{
    public partial class MigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autor",
                columns: table => new
                {
                    IdAutor = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    Apellidos = table.Column<string>(maxLength: 100, nullable: false),
                    FechaNac = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autor", x => x.IdAutor);
                });

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    IdCategoria = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    Apellidos = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Password = table.Column<string>(maxLength: 5000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Libro",
                columns: table => new
                {
                    IdLibro = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    IdAutor = table.Column<Guid>(nullable: false),
                    IdCategoria = table.Column<Guid>(nullable: false),
                    ISBN = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libro", x => x.IdLibro);
                    table.ForeignKey(
                        name: "FK_Libro_Autor_IdAutor",
                        column: x => x.IdAutor,
                        principalTable: "Autor",
                        principalColumn: "IdAutor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Libro_Categoria_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "Categoria",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Autor",
                columns: new[] { "IdAutor", "Apellidos", "FechaNac", "Nombre" },
                values: new object[,]
                {
                    { new Guid("7faf24d1-820a-488d-8bcc-eede72bb0768"), "García Marquéz", new DateTime(2019, 12, 19, 17, 24, 39, 428, DateTimeKind.Local).AddTicks(743), "Gabriel" },
                    { new Guid("7ae9692a-1ff8-4353-8a9d-8cc26c086bcc"), "Coelho", new DateTime(2019, 12, 19, 17, 24, 39, 428, DateTimeKind.Local).AddTicks(3566), "Paolo" },
                    { new Guid("0c0c6c64-2340-4047-bdc2-89872d799563"), "Madera González", new DateTime(2019, 12, 19, 17, 24, 39, 428, DateTimeKind.Local).AddTicks(3579), "Roberto" }
                });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "IdCategoria", "Descripcion", "Nombre" },
                values: new object[,]
                {
                    { new Guid("ec300df7-a067-45ca-b3ae-ceee50baec87"), "Novelas hechas televisión", "Novela" },
                    { new Guid("d23b9a45-1098-4f68-9fa7-07cea02a3c47"), "Novelas Dramáticas", "Drama" }
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "IdUsuario", "Apellidos", "Email", "Nombre", "Password" },
                values: new object[] { new Guid("90fa2679-2828-43e9-9131-73c726d3f8f0"), "Madera", "robertomadera@gmail.com", "Roberto", "lEtCeLbSeLaAM7eolqFuRDBXikElcjcLp15vfR78/e8=" });

            migrationBuilder.CreateIndex(
                name: "IX_Libro_IdAutor",
                table: "Libro",
                column: "IdAutor");

            migrationBuilder.CreateIndex(
                name: "IX_Libro_IdCategoria",
                table: "Libro",
                column: "IdCategoria");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Libro");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Autor");

            migrationBuilder.DropTable(
                name: "Categoria");
        }
    }
}
