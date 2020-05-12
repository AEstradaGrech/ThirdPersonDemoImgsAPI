using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ThirdPersonDemoIMGsInfrasturcture.Migrations
{
    public partial class IdSetterAndCategoryId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Images",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20) CHARACTER SET utf8mb4",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Images",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 12, 17, 10, 32, 264, DateTimeKind.Local).AddTicks(6510),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2020, 4, 16, 22, 24, 35, 263, DateTimeKind.Local).AddTicks(6320));

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Images",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Images");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Images",
                type: "varchar(20) CHARACTER SET utf8mb4",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Images",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 16, 22, 24, 35, 263, DateTimeKind.Local).AddTicks(6320),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 12, 17, 10, 32, 264, DateTimeKind.Local).AddTicks(6510));
        }
    }
}
