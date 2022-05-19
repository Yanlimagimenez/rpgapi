using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RpgApi.Migrations
{
    public partial class MigracaoUmParaUm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonagemId",
                table: "Armas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Armas",
                columns: new[] { "Id", "Dano", "Nome", "PersonagemId" },
                values: new object[,]
                {
                    { 1, 35, "Arco e Flecha", 1 },
                    { 2, 33, "Espada", 2 },
                    { 3, 31, "Machado", 3 }
                });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 231, 234, 197, 86, 94, 200, 94, 11, 49, 182, 57, 2, 131, 2, 237, 106, 77, 208, 135, 248, 165, 84, 28, 212, 239, 183, 4, 107, 131, 76, 215, 12, 136, 67, 119, 25, 134, 126, 130, 86, 1, 38, 40, 106, 60, 129, 206, 203, 255, 110, 49, 1, 212, 141, 45, 218, 215, 195, 108, 240, 216, 153, 238, 70 }, new byte[] { 55, 200, 224, 137, 160, 145, 223, 240, 84, 155, 197, 195, 27, 243, 96, 187, 164, 30, 92, 108, 170, 103, 66, 61, 88, 11, 203, 103, 252, 39, 58, 118, 69, 50, 41, 194, 88, 242, 107, 160, 227, 148, 114, 95, 89, 158, 20, 106, 35, 71, 123, 188, 79, 51, 220, 43, 35, 28, 70, 26, 12, 23, 226, 39, 251, 244, 73, 176, 136, 88, 64, 192, 70, 62, 75, 113, 192, 42, 240, 188, 180, 69, 200, 109, 52, 74, 245, 40, 43, 112, 42, 102, 66, 175, 142, 138, 49, 208, 82, 44, 176, 203, 247, 188, 129, 238, 36, 246, 232, 79, 220, 235, 82, 165, 79, 221, 161, 232, 63, 193, 112, 216, 115, 33, 85, 177, 129, 170 } });

            migrationBuilder.CreateIndex(
                name: "IX_Armas_PersonagemId",
                table: "Armas",
                column: "PersonagemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Armas_Personagens_PersonagemId",
                table: "Armas",
                column: "PersonagemId",
                principalTable: "Personagens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Armas_Personagens_PersonagemId",
                table: "Armas");

            migrationBuilder.DropIndex(
                name: "IX_Armas_PersonagemId",
                table: "Armas");

            migrationBuilder.DeleteData(
                table: "Armas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Armas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Armas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "PersonagemId",
                table: "Armas");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 181, 137, 151, 241, 79, 61, 246, 31, 112, 180, 35, 113, 238, 95, 88, 38, 106, 116, 97, 246, 174, 1, 108, 235, 78, 77, 104, 209, 38, 192, 134, 42, 99, 139, 59, 98, 203, 80, 121, 255, 226, 102, 191, 96, 128, 55, 131, 180, 231, 234, 30, 67, 217, 122, 19, 179, 223, 24, 54, 165, 253, 191, 145, 117 }, new byte[] { 59, 99, 25, 244, 72, 167, 169, 73, 160, 120, 192, 98, 117, 239, 134, 46, 60, 49, 3, 134, 243, 25, 57, 103, 70, 155, 65, 118, 108, 210, 15, 177, 201, 171, 194, 122, 18, 243, 176, 145, 134, 55, 135, 168, 23, 182, 173, 96, 22, 88, 38, 128, 196, 117, 114, 35, 157, 215, 201, 124, 33, 7, 46, 89, 47, 217, 22, 85, 98, 42, 106, 173, 42, 78, 156, 33, 27, 78, 150, 39, 135, 124, 163, 102, 154, 64, 47, 167, 171, 165, 13, 208, 165, 67, 203, 241, 222, 178, 113, 181, 25, 248, 226, 8, 219, 115, 90, 252, 45, 132, 223, 11, 128, 74, 129, 9, 29, 17, 54, 58, 104, 32, 160, 98, 58, 60, 177, 137 } });
        }
    }
}
