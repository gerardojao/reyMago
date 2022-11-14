using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReyMagoAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Afinidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Afinidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grimorios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grimorios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Identificacion = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Edad = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    Afinidadid = table.Column<int>(name: "Afinidad_id", type: "int", nullable: false),
                    Grimorioid = table.Column<int>(name: "Grimorio_id", type: "int", nullable: false),
                    Estatus = table.Column<bool>(type: "bit", nullable: false),
                    AfinidadId = table.Column<int>(type: "int", nullable: false),
                    GrimorioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estudiantes_Afinidades_AfinidadId",
                        column: x => x.AfinidadId,
                        principalTable: "Afinidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Estudiantes_Grimorios_GrimorioId",
                        column: x => x.GrimorioId,
                        principalTable: "Grimorios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estudiantes");

            migrationBuilder.DropTable(
                name: "Afinidades");

            migrationBuilder.DropTable(
                name: "Grimorios");
        }
    }
}
