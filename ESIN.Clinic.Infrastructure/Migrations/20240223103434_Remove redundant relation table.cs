using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ESIN.Clinic.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Removeredundantrelationtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipmentAccesses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EquipmentAccesses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    EquipmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentAccesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentAccesses_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EquipmentAccesses_Equipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentAccesses_EmployeeId",
                table: "EquipmentAccesses",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentAccesses_EquipmentId",
                table: "EquipmentAccesses",
                column: "EquipmentId");
        }
    }
}
