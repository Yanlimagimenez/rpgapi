using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RpgApi.Migrations
{
    public partial class MigracaoMuitosParaMuitos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Habilidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habilidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonagemHabilidades",
                columns: table => new
                {
                    PersonagemId = table.Column<int>(type: "int", nullable: false),
                    HabilidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonagemHabilidades", x => new { x.PersonagemId, x.HabilidadeId });
                    table.ForeignKey(
                        name: "FK_PersonagemHabilidades_Habilidades_HabilidadeId",
                        column: x => x.HabilidadeId,
                        principalTable: "Habilidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonagemHabilidades_Personagens_PersonagemId",
                        column: x => x.PersonagemId,
                        principalTable: "Personagens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Habilidades",
                columns: new[] { "Id", "Dano", "Nome" },
                values: new object[,]
                {
                    { 1, 39, "Adormecer" },
                    { 2, 41, "Congelar" },
                    { 3, 37, "Hipnotizar" }
                });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 197, 189, 45, 90, 129, 19, 139, 150, 209, 166, 124, 192, 51, 233, 232, 47, 99, 177, 255, 117, 132, 75, 23, 36, 118, 182, 73, 134, 155, 115, 253, 33, 131, 141, 153, 109, 215, 220, 188, 175, 42, 24, 61, 228, 86, 201, 252, 98, 199, 250, 219, 57, 20, 230, 151, 204, 108, 37, 177, 231, 175, 12, 200, 228 }, new byte[] { 93, 141, 221, 208, 46, 225, 200, 216, 227, 210, 41, 33, 190, 57, 19, 113, 101, 16, 253, 26, 181, 135, 58, 6, 87, 192, 210, 190, 164, 56, 48, 25, 226, 4, 159, 82, 181, 115, 50, 144, 203, 9, 245, 128, 125, 149, 33, 132, 226, 70, 126, 126, 139, 186, 241, 119, 147, 125, 237, 229, 36, 42, 187, 239, 216, 164, 96, 178, 166, 228, 75, 209, 72, 50, 144, 24, 168, 211, 63, 135, 45, 193, 209, 212, 84, 185, 56, 218, 186, 27, 240, 47, 230, 116, 180, 32, 36, 36, 53, 84, 95, 195, 52, 100, 51, 227, 160, 50, 67, 202, 145, 242, 63, 41, 204, 76, 56, 150, 80, 77, 162, 115, 175, 252, 44, 215, 10, 115 } });

            migrationBuilder.InsertData(
                table: "PersonagemHabilidades",
                columns: new[] { "HabilidadeId", "PersonagemId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 5 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 6 },
                    { 3, 3 },
                    { 3, 4 },
                    { 3, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonagemHabilidades_HabilidadeId",
                table: "PersonagemHabilidades",
                column: "HabilidadeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonagemHabilidades");

            migrationBuilder.DropTable(
                name: "Habilidades");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 231, 234, 197, 86, 94, 200, 94, 11, 49, 182, 57, 2, 131, 2, 237, 106, 77, 208, 135, 248, 165, 84, 28, 212, 239, 183, 4, 107, 131, 76, 215, 12, 136, 67, 119, 25, 134, 126, 130, 86, 1, 38, 40, 106, 60, 129, 206, 203, 255, 110, 49, 1, 212, 141, 45, 218, 215, 195, 108, 240, 216, 153, 238, 70 }, new byte[] { 55, 200, 224, 137, 160, 145, 223, 240, 84, 155, 197, 195, 27, 243, 96, 187, 164, 30, 92, 108, 170, 103, 66, 61, 88, 11, 203, 103, 252, 39, 58, 118, 69, 50, 41, 194, 88, 242, 107, 160, 227, 148, 114, 95, 89, 158, 20, 106, 35, 71, 123, 188, 79, 51, 220, 43, 35, 28, 70, 26, 12, 23, 226, 39, 251, 244, 73, 176, 136, 88, 64, 192, 70, 62, 75, 113, 192, 42, 240, 188, 180, 69, 200, 109, 52, 74, 245, 40, 43, 112, 42, 102, 66, 175, 142, 138, 49, 208, 82, 44, 176, 203, 247, 188, 129, 238, 36, 246, 232, 79, 220, 235, 82, 165, 79, 221, 161, 232, 63, 193, 112, 216, 115, 33, 85, 177, 129, 170 } });
        }
    }
}
