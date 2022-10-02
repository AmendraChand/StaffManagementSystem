using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StaffManagementSystem.Data.Migrations
{
    public partial class removeEntityBaseFromGenderQualification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_by",
                table: "Qualification");

            migrationBuilder.DropColumn(
                name: "created_datetime",
                table: "Qualification");

            migrationBuilder.DropColumn(
                name: "updated_by",
                table: "Qualification");

            migrationBuilder.DropColumn(
                name: "updated_datetime",
                table: "Qualification");

            migrationBuilder.DropColumn(
                name: "created_by",
                table: "Gender");

            migrationBuilder.DropColumn(
                name: "created_datetime",
                table: "Gender");

            migrationBuilder.DropColumn(
                name: "updated_by",
                table: "Gender");

            migrationBuilder.DropColumn(
                name: "updated_datetime",
                table: "Gender");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "created_by",
                table: "Qualification",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_datetime",
                table: "Qualification",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "updated_by",
                table: "Qualification",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_datetime",
                table: "Qualification",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "created_by",
                table: "Gender",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_datetime",
                table: "Gender",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "updated_by",
                table: "Gender",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_datetime",
                table: "Gender",
                type: "datetime2",
                nullable: true);
        }
    }
}
