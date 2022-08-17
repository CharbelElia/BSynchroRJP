using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BSynchro.DataAccess.Migrations
{
    public partial class AddAccountType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountType",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "CustomerId", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 8, 17, 12, 20, 44, 428, DateTimeKind.Utc).AddTicks(8433), "7c14ce8d-10f7-4667-930b-dd899005b686", new DateTime(2022, 8, 17, 12, 20, 44, 428, DateTimeKind.Utc).AddTicks(8434) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountType",
                table: "Account");

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "CustomerId", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 8, 17, 11, 32, 46, 18, DateTimeKind.Utc).AddTicks(6244), "fa456977-760e-4265-8692-8456242b3461", new DateTime(2022, 8, 17, 11, 32, 46, 18, DateTimeKind.Utc).AddTicks(6245) });
        }
    }
}
