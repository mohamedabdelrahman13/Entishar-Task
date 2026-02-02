using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Users_CRUD.Migrations
{
    /// <inheritdoc />
    public partial class addCreationDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "users",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "SYSDATETIME()");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "users");
        }
    }
}
