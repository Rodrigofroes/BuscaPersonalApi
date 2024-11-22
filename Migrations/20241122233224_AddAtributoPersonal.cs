using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuscaPersonalApi.Migrations
{
    /// <inheritdoc />
    public partial class AddAtributoPersonal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "Per_data_nascimento",
                table: "Personal",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Per_data_nascimento",
                table: "Personal");
        }
    }
}
