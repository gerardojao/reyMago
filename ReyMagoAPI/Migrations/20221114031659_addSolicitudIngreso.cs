using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReyMagoAPI.Migrations
{
    /// <inheritdoc />
    public partial class addSolicitudIngreso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estudiantes");

            migrationBuilder.CreateTable(
                name: "SolicitudIngresos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Identificacion = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Edad = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    AfinidadId = table.Column<int>(name: "Afinidad_Id", type: "int", nullable: false),
                    GrimorioId = table.Column<int>(name: "Grimorio_Id", type: "int", nullable: false),
                    Estatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitudIngresos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolicitudIngresos_Afinidades_Afinidad_Id",
                        column: x => x.AfinidadId,
                        principalTable: "Afinidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SolicitudIngresos_Grimorios_Grimorio_Id",
                        column: x => x.GrimorioId,
                        principalTable: "Grimorios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudIngresos_Afinidad_Id",
                table: "SolicitudIngresos",
                column: "Afinidad_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudIngresos_Grimorio_Id",
                table: "SolicitudIngresos",
                column: "Grimorio_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SolicitudIngresos");

            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AfinidadId = table.Column<int>(type: "int", nullable: false),
                    GrimorioId = table.Column<int>(type: "int", nullable: false),
                    Afinidadid = table.Column<int>(name: "Afinidad_id", type: "int", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Edad = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    Estatus = table.Column<bool>(type: "bit", nullable: false),
                    Grimorioid = table.Column<int>(name: "Grimorio_id", type: "int", nullable: false),
                    Identificacion = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estudiantes_Afinidades_AfinidadId",
                        column: x => x.AfinidadId,
                        principalTable: "Afinidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Estudiantes_Grimorios_GrimorioId",
                        column: x => x.GrimorioId,
                        principalTable: "Grimorios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estudiantes_AfinidadId",
                table: "Estudiantes",
                column: "AfinidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Estudiantes_GrimorioId",
                table: "Estudiantes",
                column: "GrimorioId");
        }
    }
}
