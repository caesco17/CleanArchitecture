using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Data.Migrations
{
    /// <inheritdoc />
    public partial class Migration_002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Videos",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Streamers",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Director",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Actor",
                newName: "CreatedDate");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "VideoActor",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "VideoActor",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "VideoActor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "VideoActor",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "VideoActor",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "VideoActor");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "VideoActor");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "VideoActor");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "VideoActor");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "VideoActor");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Videos",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Streamers",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Director",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Actor",
                newName: "DateCreated");
        }
    }
}
