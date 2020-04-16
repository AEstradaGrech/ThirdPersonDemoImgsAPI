using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ThirdPersonDemoIMGsInfrasturcture.Migrations
{
    public partial class ImgEntityUpdateMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Images",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 16, 22, 24, 35, 263, DateTimeKind.Local).AddTicks(6320));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Images",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Images_Name",
                table: "Images",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Images_Name",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Images");
        }
    }
}
