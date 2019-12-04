using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class imc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Treino");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Treino");

            migrationBuilder.AddColumn<double>(
                name: "Altura",
                table: "Clientes",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Imc",
                table: "Clientes",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Peso",
                table: "Clientes",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Altura",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Imc",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Peso",
                table: "Clientes");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Treino",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Treino",
                nullable: true);
        }
    }
}
