using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIBootcamp.API.Migrations
{
    public partial class mig4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "YummyEventId",
                table: "YummyEvents",
                newName: "Id");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "YummyEvents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "YummyEvents",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "YummyEvents",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "YummyEventStatus",
                table: "YummyEvents",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "YummyEvents");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "YummyEvents");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "YummyEvents");

            migrationBuilder.DropColumn(
                name: "YummyEventStatus",
                table: "YummyEvents");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "YummyEvents",
                newName: "YummyEventId");
        }
    }
}
