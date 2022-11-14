using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReyMagoAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estudiantes_Afinidades_AfinidadId",
                table: "Estudiantes");

            migrationBuilder.DropForeignKey(
                name: "FK_Estudiantes_Grimorios_GrimorioId",
                table: "Estudiantes");

            migrationBuilder.InsertData(
                table: "Afinidades",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Oscuridad" },
                    { 2, "Luz" },
                    { 3, "Fuego" },
                    { 4, "Agua" },
                    { 5, "Viento" },
                    { 6, "Tierra" }
                });

            migrationBuilder.InsertData(
                table: "Grimorios",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Trébol de 1 hoja", "Sinceridad" },
                    { 2, "Trébol de 2 hoja", "Esperanza" },
                    { 3, "Trébol de 3 hoja", "Amor" },
                    { 4, "Trébol de 4 hoja", "Buena Fortuna" },
                    { 5, "Trébol de 5 hoja", "Desesperación" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Estudiantes_Afinidades_AfinidadId",
                table: "Estudiantes",
                column: "AfinidadId",
                principalTable: "Afinidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Estudiantes_Grimorios_GrimorioId",
                table: "Estudiantes",
                column: "GrimorioId",
                principalTable: "Grimorios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estudiantes_Afinidades_AfinidadId",
                table: "Estudiantes");

            migrationBuilder.DropForeignKey(
                name: "FK_Estudiantes_Grimorios_GrimorioId",
                table: "Estudiantes");

            migrationBuilder.DeleteData(
                table: "Afinidades",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Afinidades",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Afinidades",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Afinidades",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Afinidades",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Afinidades",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Grimorios",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Grimorios",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Grimorios",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Grimorios",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Grimorios",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AddForeignKey(
                name: "FK_Estudiantes_Afinidades_AfinidadId",
                table: "Estudiantes",
                column: "AfinidadId",
                principalTable: "Afinidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Estudiantes_Grimorios_GrimorioId",
                table: "Estudiantes",
                column: "GrimorioId",
                principalTable: "Grimorios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
