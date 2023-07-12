using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Addadmintousers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                column: "ReleaseDate",
                value: new DateTime(2022, 5, 9, 20, 52, 25, 484, DateTimeKind.Local).AddTicks(1531));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "EMail", "Name", "Password", "Role" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), "artem@gmail.com", "Artem", "Owve1iNLlEKKrO3hQplQLBNN3TfIkzMEXwF8EkikVN4=", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                column: "ReleaseDate",
                value: new DateTime(2022, 5, 9, 16, 42, 10, 93, DateTimeKind.Local).AddTicks(5946));
        }
    }
}
