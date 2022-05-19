using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RpgApi.Migrations
{
    public partial class MigracaoUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Armas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Foto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataAcesso = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personagens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PontosVida = table.Column<int>(type: "int", nullable: false),
                    Forca = table.Column<int>(type: "int", nullable: false),
                    Defesa = table.Column<int>(type: "int", nullable: false),
                    Inteligencia = table.Column<int>(type: "int", nullable: false),
                    Classe = table.Column<int>(type: "int", nullable: false),
                    FotoPersonagem = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    usuarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personagens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personagens_Usuarios_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Personagens",
                columns: new[] { "Id", "Classe", "Defesa", "Forca", "FotoPersonagem", "Inteligencia", "Nome", "PontosVida", "usuarioId" },
                values: new object[,]
                {
                    { 1, 1, 23, 17, null, 33, "Frodo", 100, null },
                    { 2, 1, 25, 15, null, 30, "Sam", 100, null },
                    { 3, 3, 21, 18, null, 35, "Galadriel", 100, null },
                    { 4, 2, 18, 18, null, 37, "Gandalf", 100, null },
                    { 5, 1, 17, 20, null, 31, "Hobbit", 100, null },
                    { 6, 3, 13, 21, null, 34, "Celeborn", 100, null },
                    { 7, 2, 11, 25, null, 35, "Radagast", 100, null }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "DataAcesso", "Foto", "Latitude", "Longitude", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { 1, null, null, null, null, new byte[] { 181, 137, 151, 241, 79, 61, 246, 31, 112, 180, 35, 113, 238, 95, 88, 38, 106, 116, 97, 246, 174, 1, 108, 235, 78, 77, 104, 209, 38, 192, 134, 42, 99, 139, 59, 98, 203, 80, 121, 255, 226, 102, 191, 96, 128, 55, 131, 180, 231, 234, 30, 67, 217, 122, 19, 179, 223, 24, 54, 165, 253, 191, 145, 117 }, new byte[] { 59, 99, 25, 244, 72, 167, 169, 73, 160, 120, 192, 98, 117, 239, 134, 46, 60, 49, 3, 134, 243, 25, 57, 103, 70, 155, 65, 118, 108, 210, 15, 177, 201, 171, 194, 122, 18, 243, 176, 145, 134, 55, 135, 168, 23, 182, 173, 96, 22, 88, 38, 128, 196, 117, 114, 35, 157, 215, 201, 124, 33, 7, 46, 89, 47, 217, 22, 85, 98, 42, 106, 173, 42, 78, 156, 33, 27, 78, 150, 39, 135, 124, 163, 102, 154, 64, 47, 167, 171, 165, 13, 208, 165, 67, 203, 241, 222, 178, 113, 181, 25, 248, 226, 8, 219, 115, 90, 252, 45, 132, 223, 11, 128, 74, 129, 9, 29, 17, 54, 58, 104, 32, 160, 98, 58, 60, 177, 137 }, "UsuarioAdmin" });

            migrationBuilder.CreateIndex(
                name: "IX_Personagens_usuarioId",
                table: "Personagens",
                column: "usuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Armas");

            migrationBuilder.DropTable(
                name: "Personagens");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
