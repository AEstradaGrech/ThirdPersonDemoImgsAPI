using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ThirdPersonDemoIMGsInfrasturcture.Migrations
{
    public partial class GameStudioNameMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Images",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 13, 18, 36, 32, 234, DateTimeKind.Local).AddTicks(6710),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 12, 17, 10, 32, 264, DateTimeKind.Local).AddTicks(6510));

            migrationBuilder.AddColumn<string>(
                name: "GameStudioName",
                table: "Images",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GameStudioName",
                table: "Images");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Images",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 12, 17, 10, 32, 264, DateTimeKind.Local).AddTicks(6510),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 13, 18, 36, 32, 234, DateTimeKind.Local).AddTicks(6710));
        }
    }
}
