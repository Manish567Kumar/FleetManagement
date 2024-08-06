using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FleetManagement.Migrations
{
    /// <inheritdoc />
    public partial class FleetManagementModelsFleetManagementContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    VehicleId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChassisId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChassisSeries = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChassisNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    PassengersCount = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.VehicleId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_ChassisId",
                table: "Vehicle",
                column: "ChassisId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicle");
        }
    }
}
