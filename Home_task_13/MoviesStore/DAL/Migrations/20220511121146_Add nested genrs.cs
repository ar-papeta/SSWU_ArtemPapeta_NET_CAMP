using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Addnestedgenrs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ParentGenreId",
                table: "Genres",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                column: "ReleaseDate",
                value: new DateTime(2022, 5, 11, 15, 11, 45, 566, DateTimeKind.Local).AddTicks(1485));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentGenreId",
                table: "Genres");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                column: "ReleaseDate",
                value: new DateTime(2022, 5, 9, 20, 52, 25, 484, DateTimeKind.Local).AddTicks(1531));
        }
    }
}
