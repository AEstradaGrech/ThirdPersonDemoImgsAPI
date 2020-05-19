using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ThirdPersonDemoIMGsInfrasturcture.Migrations
{
    public partial class EntityCategoryToIntMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Images",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 19, 23, 48, 57, 92, DateTimeKind.Local).AddTicks(710),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 13, 18, 36, 32, 234, DateTimeKind.Local).AddTicks(6710));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Images",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 13, 18, 36, 32, 234, DateTimeKind.Local).AddTicks(6710),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 19, 23, 48, 57, 92, DateTimeKind.Local).AddTicks(710));
        }
    }
}
