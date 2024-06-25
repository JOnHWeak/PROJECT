using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SWPApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBillRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "ServicePrice",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "ServiceType",
                table: "Bills");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Bills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PaymentMethod",
                table: "Bills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ServiceId",
                table: "Bills",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_CustomerId",
                table: "Bills",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_ServiceId",
                table: "Bills",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Customers_CustomerId",
                table: "Bills",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Services_ServiceId",
                table: "Bills",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Customers_CustomerId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Services_ServiceId",
                table: "Bills");

            migrationBuilder.DropIndex(
                name: "IX_Bills_CustomerId",
                table: "Bills");

            migrationBuilder.DropIndex(
                name: "IX_Bills_ServiceId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Bills");

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "Bills",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Bills",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "ServicePrice",
                table: "Bills",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ServiceType",
                table: "Bills",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
