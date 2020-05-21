using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ThirdPersonDemoIMGsInfrasturcture.Migrations
{
    public partial class ImgUserGuidMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Images",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 20, 23, 46, 22, 835, DateTimeKind.Local).AddTicks(8580),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 20, 0, 25, 50, 727, DateTimeKind.Local).AddTicks(6850));

            migrationBuilder.AddColumn<Guid>(
                name: "UserGuid",
                table: "Images",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserGuid",
                table: "Images");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Images",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 20, 0, 25, 50, 727, DateTimeKind.Local).AddTicks(6850),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 20, 23, 46, 22, 835, DateTimeKind.Local).AddTicks(8580));
        }
    }
}
