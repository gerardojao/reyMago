using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReyMagoAPI.Migrations
{
    /// <inheritdoc />
    public partial class addGrimorioByDefault : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Grimorios",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 7, "No Asignado", "No Asignado" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Grimorios",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
