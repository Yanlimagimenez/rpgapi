﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RpgApi.Migrations
{
    public partial class scriptFinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 28, 215, 215, 61, 127, 103, 206, 197, 192, 140, 107, 193, 218, 24, 61, 3, 59, 7, 92, 237, 141, 241, 171, 171, 147, 190, 49, 74, 221, 242, 202, 203, 86, 107, 141, 238, 179, 85, 0, 60, 17, 226, 188, 223, 226, 135, 231, 9, 109, 29, 50, 217, 124, 2, 73, 98, 184, 116, 2, 244, 239, 59, 157, 147 }, new byte[] { 5, 220, 55, 88, 49, 245, 162, 229, 164, 2, 149, 195, 7, 228, 145, 182, 49, 102, 61, 255, 195, 219, 191, 126, 95, 146, 187, 156, 77, 59, 92, 182, 166, 24, 139, 66, 93, 36, 148, 197, 78, 162, 44, 241, 133, 120, 81, 35, 166, 255, 169, 220, 129, 197, 220, 74, 84, 91, 211, 194, 195, 56, 161, 67, 107, 252, 47, 178, 22, 180, 164, 187, 183, 209, 91, 13, 168, 54, 114, 31, 158, 136, 62, 193, 20, 155, 40, 176, 189, 153, 101, 97, 117, 180, 208, 71, 206, 1, 213, 35, 125, 6, 176, 34, 50, 179, 219, 54, 22, 251, 113, 144, 48, 254, 31, 78, 160, 74, 204, 170, 238, 6, 138, 172, 200, 47, 101, 2 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 70, 48, 168, 166, 71, 252, 130, 99, 115, 44, 178, 239, 225, 15, 205, 110, 191, 98, 205, 78, 81, 143, 162, 128, 178, 28, 35, 33, 12, 82, 107, 141, 172, 51, 213, 93, 235, 121, 9, 246, 179, 86, 120, 42, 182, 229, 96, 175, 216, 234, 233, 105, 209, 14, 221, 107, 110, 8, 154, 27, 118, 191, 182, 184 }, new byte[] { 14, 0, 59, 132, 1, 53, 25, 21, 131, 225, 146, 235, 120, 116, 123, 40, 72, 195, 122, 196, 48, 191, 18, 24, 74, 94, 207, 20, 123, 225, 205, 129, 233, 42, 142, 193, 7, 181, 70, 86, 139, 28, 116, 63, 213, 62, 227, 6, 14, 41, 23, 20, 120, 30, 171, 182, 187, 101, 25, 225, 238, 139, 181, 183, 139, 38, 31, 252, 79, 62, 221, 199, 154, 103, 250, 4, 194, 71, 158, 113, 236, 43, 147, 130, 129, 64, 9, 193, 216, 162, 169, 58, 124, 198, 129, 90, 73, 0, 245, 161, 105, 230, 249, 10, 0, 22, 119, 19, 157, 17, 253, 201, 70, 195, 67, 181, 208, 200, 10, 101, 104, 21, 162, 183, 193, 99, 180, 181 } });
        }
    }
}
