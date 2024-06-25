using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SWPApp.Migrations
{
    /// <inheritdoc />
    public partial class AddBillTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerEmail",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "ServiceDate",
                table: "Bills");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Bills",
                newName: "Email");

            migrationBuilder.AddColumn<decimal>(
                name: "ServicePrice",
                table: "Bills",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServicePrice",
                table: "Bills");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Bills",
                newName: "Status");

            migrationBuilder.AddColumn<string>(
                name: "CustomerEmail",
                table: "Bills",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ServiceDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
