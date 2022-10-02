using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StaffManagementSystem.Data.Migrations
{
    public partial class removeeb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_by",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "created_datetime",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "updated_by",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "updated_datetime",
                table: "Staff");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "created_by",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_datetime",
                table: "Staff",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "updated_by",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_datetime",
                table: "Staff",
                type: "datetime2",
                nullable: true);
        }
    }
}
