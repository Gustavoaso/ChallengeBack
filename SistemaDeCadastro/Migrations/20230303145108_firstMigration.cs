using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeCadastro.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "empregados",
                columns: table => new
                {
                    IdEmpregado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrimeiroNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UltimoNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empregados", x => x.IdEmpregado);
                });

            migrationBuilder.CreateTable(
                name: "projetos",
                columns: table => new
                {
                    IdProjeto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeProjeto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataTermino = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GerenteId = table.Column<int>(type: "int", nullable: false),
                    EmpregadoIdEmpregado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projetos", x => x.IdProjeto);
                    table.ForeignKey(
                        name: "FK_projetos_empregados_EmpregadoIdEmpregado",
                        column: x => x.EmpregadoIdEmpregado,
                        principalTable: "empregados",
                        principalColumn: "IdEmpregado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_projetos_EmpregadoIdEmpregado",
                table: "projetos",
                column: "EmpregadoIdEmpregado");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "projetos");

            migrationBuilder.DropTable(
                name: "empregados");
        }
    }
}
