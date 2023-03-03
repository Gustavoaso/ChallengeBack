using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeCadastro.Migrations
{
    public partial class VinculoProjetoEmpregado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_projetos_empregados_EmpregadoIdEmpregado",
                table: "projetos");

            migrationBuilder.DropIndex(
                name: "IX_projetos_EmpregadoIdEmpregado",
                table: "projetos");

            migrationBuilder.DropColumn(
                name: "EmpregadoIdEmpregado",
                table: "projetos");

            migrationBuilder.CreateIndex(
                name: "IX_projetos_GerenteId",
                table: "projetos",
                column: "GerenteId");

            migrationBuilder.AddForeignKey(
                name: "FK_projetos_empregados_GerenteId",
                table: "projetos",
                column: "GerenteId",
                principalTable: "empregados",
                principalColumn: "IdEmpregado",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_projetos_empregados_GerenteId",
                table: "projetos");

            migrationBuilder.DropIndex(
                name: "IX_projetos_GerenteId",
                table: "projetos");

            migrationBuilder.AddColumn<int>(
                name: "EmpregadoIdEmpregado",
                table: "projetos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_projetos_EmpregadoIdEmpregado",
                table: "projetos",
                column: "EmpregadoIdEmpregado");

            migrationBuilder.AddForeignKey(
                name: "FK_projetos_empregados_EmpregadoIdEmpregado",
                table: "projetos",
                column: "EmpregadoIdEmpregado",
                principalTable: "empregados",
                principalColumn: "IdEmpregado",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
