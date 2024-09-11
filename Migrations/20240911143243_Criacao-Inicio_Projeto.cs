using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoVacina.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoInicio_Projeto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FrequenciaVacina",
                columns: table => new
                {
                    FrequenciaVacinaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FrequenciaVacinaDescricao = table.Column<string>(name: "FrequenciaVacinaDescricao ", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrequenciaVacina", x => x.FrequenciaVacinaId);
                });

            migrationBuilder.CreateTable(
                name: "IndicacaoGenero",
                columns: table => new
                {
                    IndicacaoGeneroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IndicacaoGeneroDescricao = table.Column<string>(name: "IndicacaoGeneroDescricao ", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndicacaoGenero", x => x.IndicacaoGeneroId);
                });

            migrationBuilder.CreateTable(
                name: "IndicacaoIdade",
                columns: table => new
                {
                    IndicacaoIdadeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IndicacaoIdadeDescricao = table.Column<string>(name: "IndicacaoIdadeDescricao ", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndicacaoIdade", x => x.IndicacaoIdadeId);
                });

            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    LoginId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoginEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoginSenha = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.LoginId);
                });

            migrationBuilder.CreateTable(
                name: "Cadastro",
                columns: table => new
                {
                    CadastroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CadastroCpf = table.Column<int>(type: "int", nullable: false),
                    CadastroEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CadastroSenha = table.Column<int>(type: "int", nullable: false),
                    CadastroGenero = table.Column<int>(type: "int", nullable: false),
                    CadastroDiaNascimento = table.Column<int>(type: "int", nullable: false),
                    CadastroMesNascimento = table.Column<int>(type: "int", nullable: false),
                    CadastroAnoNascimento = table.Column<int>(type: "int", nullable: false),
                    FrequenciaVacinaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cadastro", x => x.CadastroId);
                    table.ForeignKey(
                        name: "FK_Cadastro_FrequenciaVacina_FrequenciaVacinaId",
                        column: x => x.FrequenciaVacinaId,
                        principalTable: "FrequenciaVacina",
                        principalColumn: "FrequenciaVacinaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vacina",
                columns: table => new
                {
                    VacinaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VacinaNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VacinaDescricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IndicacaoGeneroId = table.Column<int>(type: "int", nullable: false),
                    IndicacaoIdadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacina", x => x.VacinaId);
                    table.ForeignKey(
                        name: "FK_Vacina_IndicacaoGenero_IndicacaoGeneroId",
                        column: x => x.IndicacaoGeneroId,
                        principalTable: "IndicacaoGenero",
                        principalColumn: "IndicacaoGeneroId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vacina_IndicacaoIdade_IndicacaoIdadeId",
                        column: x => x.IndicacaoIdadeId,
                        principalTable: "IndicacaoIdade",
                        principalColumn: "IndicacaoIdadeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cadastro_FrequenciaVacinaId",
                table: "Cadastro",
                column: "FrequenciaVacinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacina_IndicacaoGeneroId",
                table: "Vacina",
                column: "IndicacaoGeneroId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacina_IndicacaoIdadeId",
                table: "Vacina",
                column: "IndicacaoIdadeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cadastro");

            migrationBuilder.DropTable(
                name: "Login");

            migrationBuilder.DropTable(
                name: "Vacina");

            migrationBuilder.DropTable(
                name: "FrequenciaVacina");

            migrationBuilder.DropTable(
                name: "IndicacaoGenero");

            migrationBuilder.DropTable(
                name: "IndicacaoIdade");
        }
    }
}
