using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RpgApi.Migrations
{
    public partial class MigracaoDisputas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personagens_Usuarios_usuarioId",
                table: "Personagens");

            migrationBuilder.DropIndex(
                name: "IX_Armas_PersonagemId",
                table: "Armas");

            migrationBuilder.RenameColumn(
                name: "usuarioId",
                table: "Personagens",
                newName: "UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Personagens_usuarioId",
                table: "Personagens",
                newName: "IX_Personagens_UsuarioId");

            migrationBuilder.AddColumn<int>(
                name: "Derrotas",
                table: "Personagens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Disputa",
                table: "Personagens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Vitorias",
                table: "Personagens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Disputas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataDisputa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AtacanteId = table.Column<int>(type: "int", nullable: false),
                    OponenteId = table.Column<int>(type: "int", nullable: false),
                    Narracao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disputas", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Personagens",
                keyColumn: "Id",
                keyValue: 1,
                column: "Nome",
                value: "yan");

            migrationBuilder.UpdateData(
                table: "Personagens",
                keyColumn: "Id",
                keyValue: 2,
                column: "Nome",
                value: "dainel");

            migrationBuilder.UpdateData(
                table: "Personagens",
                keyColumn: "Id",
                keyValue: 3,
                column: "Nome",
                value: "hiague");

            migrationBuilder.UpdateData(
                table: "Personagens",
                keyColumn: "Id",
                keyValue: 4,
                column: "Nome",
                value: "brune");

            migrationBuilder.UpdateData(
                table: "Personagens",
                keyColumn: "Id",
                keyValue: 5,
                column: "Nome",
                value: "aalaina");

            migrationBuilder.UpdateData(
                table: "Personagens",
                keyColumn: "Id",
                keyValue: 6,
                column: "Nome",
                value: "coiah");

            migrationBuilder.UpdateData(
                table: "Personagens",
                keyColumn: "Id",
                keyValue: 7,
                column: "Nome",
                value: "ga");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 70, 48, 168, 166, 71, 252, 130, 99, 115, 44, 178, 239, 225, 15, 205, 110, 191, 98, 205, 78, 81, 143, 162, 128, 178, 28, 35, 33, 12, 82, 107, 141, 172, 51, 213, 93, 235, 121, 9, 246, 179, 86, 120, 42, 182, 229, 96, 175, 216, 234, 233, 105, 209, 14, 221, 107, 110, 8, 154, 27, 118, 191, 182, 184 }, new byte[] { 14, 0, 59, 132, 1, 53, 25, 21, 131, 225, 146, 235, 120, 116, 123, 40, 72, 195, 122, 196, 48, 191, 18, 24, 74, 94, 207, 20, 123, 225, 205, 129, 233, 42, 142, 193, 7, 181, 70, 86, 139, 28, 116, 63, 213, 62, 227, 6, 14, 41, 23, 20, 120, 30, 171, 182, 187, 101, 25, 225, 238, 139, 181, 183, 139, 38, 31, 252, 79, 62, 221, 199, 154, 103, 250, 4, 194, 71, 158, 113, 236, 43, 147, 130, 129, 64, 9, 193, 216, 162, 169, 58, 124, 198, 129, 90, 73, 0, 245, 161, 105, 230, 249, 10, 0, 22, 119, 19, 157, 17, 253, 201, 70, 195, 67, 181, 208, 200, 10, 101, 104, 21, 162, 183, 193, 99, 180, 181 } });

            migrationBuilder.CreateIndex(
                name: "IX_Armas_PersonagemId",
                table: "Armas",
                column: "PersonagemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Personagens_Usuarios_UsuarioId",
                table: "Personagens",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personagens_Usuarios_UsuarioId",
                table: "Personagens");

            migrationBuilder.DropTable(
                name: "Disputas");

            migrationBuilder.DropIndex(
                name: "IX_Armas_PersonagemId",
                table: "Armas");

            migrationBuilder.DropColumn(
                name: "Derrotas",
                table: "Personagens");

            migrationBuilder.DropColumn(
                name: "Disputa",
                table: "Personagens");

            migrationBuilder.DropColumn(
                name: "Vitorias",
                table: "Personagens");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Personagens",
                newName: "usuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Personagens_UsuarioId",
                table: "Personagens",
                newName: "IX_Personagens_usuarioId");

            migrationBuilder.UpdateData(
                table: "Personagens",
                keyColumn: "Id",
                keyValue: 1,
                column: "Nome",
                value: "Frodo");

            migrationBuilder.UpdateData(
                table: "Personagens",
                keyColumn: "Id",
                keyValue: 2,
                column: "Nome",
                value: "Sam");

            migrationBuilder.UpdateData(
                table: "Personagens",
                keyColumn: "Id",
                keyValue: 3,
                column: "Nome",
                value: "Galadriel");

            migrationBuilder.UpdateData(
                table: "Personagens",
                keyColumn: "Id",
                keyValue: 4,
                column: "Nome",
                value: "Gandalf");

            migrationBuilder.UpdateData(
                table: "Personagens",
                keyColumn: "Id",
                keyValue: 5,
                column: "Nome",
                value: "Hobbit");

            migrationBuilder.UpdateData(
                table: "Personagens",
                keyColumn: "Id",
                keyValue: 6,
                column: "Nome",
                value: "Celeborn");

            migrationBuilder.UpdateData(
                table: "Personagens",
                keyColumn: "Id",
                keyValue: 7,
                column: "Nome",
                value: "Radagast");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 197, 189, 45, 90, 129, 19, 139, 150, 209, 166, 124, 192, 51, 233, 232, 47, 99, 177, 255, 117, 132, 75, 23, 36, 118, 182, 73, 134, 155, 115, 253, 33, 131, 141, 153, 109, 215, 220, 188, 175, 42, 24, 61, 228, 86, 201, 252, 98, 199, 250, 219, 57, 20, 230, 151, 204, 108, 37, 177, 231, 175, 12, 200, 228 }, new byte[] { 93, 141, 221, 208, 46, 225, 200, 216, 227, 210, 41, 33, 190, 57, 19, 113, 101, 16, 253, 26, 181, 135, 58, 6, 87, 192, 210, 190, 164, 56, 48, 25, 226, 4, 159, 82, 181, 115, 50, 144, 203, 9, 245, 128, 125, 149, 33, 132, 226, 70, 126, 126, 139, 186, 241, 119, 147, 125, 237, 229, 36, 42, 187, 239, 216, 164, 96, 178, 166, 228, 75, 209, 72, 50, 144, 24, 168, 211, 63, 135, 45, 193, 209, 212, 84, 185, 56, 218, 186, 27, 240, 47, 230, 116, 180, 32, 36, 36, 53, 84, 95, 195, 52, 100, 51, 227, 160, 50, 67, 202, 145, 242, 63, 41, 204, 76, 56, 150, 80, 77, 162, 115, 175, 252, 44, 215, 10, 115 } });

            migrationBuilder.CreateIndex(
                name: "IX_Armas_PersonagemId",
                table: "Armas",
                column: "PersonagemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personagens_Usuarios_usuarioId",
                table: "Personagens",
                column: "usuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
