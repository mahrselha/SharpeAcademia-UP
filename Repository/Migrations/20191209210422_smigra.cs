using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class smigra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Treino_Clientes_ClienteId",
                table: "Treino");

            migrationBuilder.DropForeignKey(
                name: "FK_Treino_Exercicios_ExercicioId",
                table: "Treino");

            migrationBuilder.DropForeignKey(
                name: "FK_Treino_Professor_ProfessorId",
                table: "Treino");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Treino",
                table: "Treino");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Professor",
                table: "Professor");

            migrationBuilder.RenameTable(
                name: "Treino",
                newName: "Treinos");

            migrationBuilder.RenameTable(
                name: "Professor",
                newName: "Professores");

            migrationBuilder.RenameIndex(
                name: "IX_Treino_ProfessorId",
                table: "Treinos",
                newName: "IX_Treinos_ProfessorId");

            migrationBuilder.RenameIndex(
                name: "IX_Treino_ExercicioId",
                table: "Treinos",
                newName: "IX_Treinos_ExercicioId");

            migrationBuilder.RenameIndex(
                name: "IX_Treino_ClienteId",
                table: "Treinos",
                newName: "IX_Treinos_ClienteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Treinos",
                table: "Treinos",
                column: "TreinoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Professores",
                table: "Professores",
                column: "ProfessorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Treinos_Clientes_ClienteId",
                table: "Treinos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Treinos_Exercicios_ExercicioId",
                table: "Treinos",
                column: "ExercicioId",
                principalTable: "Exercicios",
                principalColumn: "ExercicioId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Treinos_Professores_ProfessorId",
                table: "Treinos",
                column: "ProfessorId",
                principalTable: "Professores",
                principalColumn: "ProfessorId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Treinos_Clientes_ClienteId",
                table: "Treinos");

            migrationBuilder.DropForeignKey(
                name: "FK_Treinos_Exercicios_ExercicioId",
                table: "Treinos");

            migrationBuilder.DropForeignKey(
                name: "FK_Treinos_Professores_ProfessorId",
                table: "Treinos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Treinos",
                table: "Treinos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Professores",
                table: "Professores");

            migrationBuilder.RenameTable(
                name: "Treinos",
                newName: "Treino");

            migrationBuilder.RenameTable(
                name: "Professores",
                newName: "Professor");

            migrationBuilder.RenameIndex(
                name: "IX_Treinos_ProfessorId",
                table: "Treino",
                newName: "IX_Treino_ProfessorId");

            migrationBuilder.RenameIndex(
                name: "IX_Treinos_ExercicioId",
                table: "Treino",
                newName: "IX_Treino_ExercicioId");

            migrationBuilder.RenameIndex(
                name: "IX_Treinos_ClienteId",
                table: "Treino",
                newName: "IX_Treino_ClienteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Treino",
                table: "Treino",
                column: "TreinoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Professor",
                table: "Professor",
                column: "ProfessorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Treino_Clientes_ClienteId",
                table: "Treino",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Treino_Exercicios_ExercicioId",
                table: "Treino",
                column: "ExercicioId",
                principalTable: "Exercicios",
                principalColumn: "ExercicioId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Treino_Professor_ProfessorId",
                table: "Treino",
                column: "ProfessorId",
                principalTable: "Professor",
                principalColumn: "ProfessorId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
