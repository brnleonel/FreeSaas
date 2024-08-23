using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FreeSaas.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoInicialFreeSaas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banco",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "character varying", maxLength: 3, nullable: false),
                    Descricao = table.Column<string>(type: "character varying", maxLength: 200, nullable: false),
                    Site = table.Column<string>(type: "character varying", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banco", x => x.Codigo);
                },
                comment: "Febrabran");

            migrationBuilder.CreateTable(
                name: "Cbo",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "character varying", maxLength: 6, nullable: false),
                    Descricao = table.Column<string>(type: "character varying", maxLength: 200, nullable: false),
                    Aplicacao = table.Column<string>(type: "character varying", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cbo", x => x.Codigo);
                },
                comment: "Cadastro Brasileiro de Ocupação");

            migrationBuilder.CreateTable(
                name: "Cep",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "character varying", maxLength: 8, nullable: false),
                    Conteudo = table.Column<string>(type: "character varying", maxLength: 5000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cep", x => x.Codigo);
                },
                comment: "Cep");

            migrationBuilder.CreateTable(
                name: "Cest",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "character varying", maxLength: 7, nullable: false),
                    Ncmsh = table.Column<string>(type: "character varying", maxLength: 8, nullable: false),
                    Descricao = table.Column<string>(type: "character varying", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cest", x => x.Codigo);
                },
                comment: "Cest");

            migrationBuilder.CreateTable(
                name: "Cfop",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying", maxLength: 200, nullable: false),
                    Aplicacao = table.Column<string>(type: "character varying", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cfop", x => x.Codigo);
                },
                comment: "Cfop");

            migrationBuilder.CreateTable(
                name: "Cnae",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cnae", x => x.Codigo);
                },
                comment: "Cnae");

            migrationBuilder.CreateTable(
                name: "Ibge",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ibge", x => x.Codigo);
                },
                comment: "Ibge");

            migrationBuilder.CreateTable(
                name: "Ncm",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ncm", x => x.Codigo);
                },
                comment: "NCM/SH");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Banco");

            migrationBuilder.DropTable(
                name: "Cbo");

            migrationBuilder.DropTable(
                name: "Cep");

            migrationBuilder.DropTable(
                name: "Cest");

            migrationBuilder.DropTable(
                name: "Cfop");

            migrationBuilder.DropTable(
                name: "Cnae");

            migrationBuilder.DropTable(
                name: "Ibge");

            migrationBuilder.DropTable(
                name: "Ncm");
        }
    }
}
