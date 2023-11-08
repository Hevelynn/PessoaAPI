using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PessoaAPI.Migrations
{
    /// <inheritdoc />
    public partial class DataBaseTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CaracteristicasFisicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Altura = table.Column<float>(type: "real", nullable: false),
                    Peso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaracteristicasFisicas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DadosPessoais",
                columns: table => new
                {
                    CPF = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    RG = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Signo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadosPessoais", x => x.CPF);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CEP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Filiacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mae = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pai = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filiacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Online",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Online", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Outros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoSanguineo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorFavorita = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Outros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Telefones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TelefoneFixo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DadosPessoaisCPF = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EnderecoId = table.Column<int>(type: "int", nullable: false),
                    FiliacaoId = table.Column<int>(type: "int", nullable: false),
                    OnlineId = table.Column<int>(type: "int", nullable: false),
                    OutrosId = table.Column<int>(type: "int", nullable: false),
                    TelefonesId = table.Column<int>(type: "int", nullable: false),
                    CaracteristicasFisicasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pessoas_CaracteristicasFisicas_CaracteristicasFisicasId",
                        column: x => x.CaracteristicasFisicasId,
                        principalTable: "CaracteristicasFisicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pessoas_DadosPessoais_DadosPessoaisCPF",
                        column: x => x.DadosPessoaisCPF,
                        principalTable: "DadosPessoais",
                        principalColumn: "CPF",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pessoas_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pessoas_Filiacao_FiliacaoId",
                        column: x => x.FiliacaoId,
                        principalTable: "Filiacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pessoas_Online_OnlineId",
                        column: x => x.OnlineId,
                        principalTable: "Online",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pessoas_Outros_OutrosId",
                        column: x => x.OutrosId,
                        principalTable: "Outros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pessoas_Telefones_TelefonesId",
                        column: x => x.TelefonesId,
                        principalTable: "Telefones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_CaracteristicasFisicasId",
                table: "Pessoas",
                column: "CaracteristicasFisicasId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_DadosPessoaisCPF",
                table: "Pessoas",
                column: "DadosPessoaisCPF");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_EnderecoId",
                table: "Pessoas",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_FiliacaoId",
                table: "Pessoas",
                column: "FiliacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_OnlineId",
                table: "Pessoas",
                column: "OnlineId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_OutrosId",
                table: "Pessoas",
                column: "OutrosId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_TelefonesId",
                table: "Pessoas",
                column: "TelefonesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pessoas");

            migrationBuilder.DropTable(
                name: "CaracteristicasFisicas");

            migrationBuilder.DropTable(
                name: "DadosPessoais");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Filiacao");

            migrationBuilder.DropTable(
                name: "Online");

            migrationBuilder.DropTable(
                name: "Outros");

            migrationBuilder.DropTable(
                name: "Telefones");
        }
    }
}
