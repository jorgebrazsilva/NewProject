using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Scouter.Infrastructure.Migrations
{
    public partial class Ajustes_tabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Usuario",
                newName: "UsuarioId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "Position",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "Position",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "Level",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "Level",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "Position");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Position");

            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "Level");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Level");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Usuario",
                newName: "Id");
        }
    }
}
