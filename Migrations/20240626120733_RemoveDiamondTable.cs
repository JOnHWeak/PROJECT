using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SWPApp.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDiamondTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Diamonds_DiamondId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_Diamonds_DiamondId",
                table: "Results");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Diamonds");

            migrationBuilder.DropIndex(
                name: "IX_Results_DiamondId",
                table: "Results");

            migrationBuilder.DropIndex(
                name: "IX_Requests_DiamondId",
                table: "Requests");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDCard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Bookings_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Diamonds",
                columns: table => new
                {
                    DiamondId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaratWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Shape = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diamonds", x => x.DiamondId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Results_DiamondId",
                table: "Results",
                column: "DiamondId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_DiamondId",
                table: "Requests",
                column: "DiamondId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ServiceId",
                table: "Bookings",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Diamonds_DiamondId",
                table: "Requests",
                column: "DiamondId",
                principalTable: "Diamonds",
                principalColumn: "DiamondId");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Diamonds_DiamondId",
                table: "Results",
                column: "DiamondId",
                principalTable: "Diamonds",
                principalColumn: "DiamondId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
