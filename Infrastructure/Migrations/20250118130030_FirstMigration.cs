using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Regioes",
                columns: table => new
                {
                    DDD = table.Column<int>(type: "INT", maxLength: 2, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Regiao = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: true),
                    UF = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regioes", x => x.DDD);
                });

            migrationBuilder.CreateTable(
                name: "Contato",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    DDD = table.Column<int>(type: "INT", maxLength: 2, nullable: false),
                    Telefone = table.Column<int>(type: "INT", maxLength: 9, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contato", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contato_Regioes_DDD",
                        column: x => x.DDD,
                        principalTable: "Regioes",
                        principalColumn: "DDD",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Regioes",
                columns: new[] { "DDD", "Regiao", "UF" },
                values: new object[,]
                {
                    { 11, "Sudeste", "SP" },
                    { 12, "Sudeste", "SP" },
                    { 13, "Sudeste", "SP" },
                    { 14, "Sudeste", "SP" },
                    { 15, "Sudeste", "SP" },
                    { 16, "Sudeste", "SP" },
                    { 17, "Sudeste", "SP" },
                    { 18, "Sudeste", "SP" },
                    { 19, "Sudeste", "SP" },
                    { 21, "Sudeste", "RJ" },
                    { 22, "Sudeste", "RJ" },
                    { 24, "Sudeste", "RJ" },
                    { 27, "Sudeste", "ES" },
                    { 28, "Sudeste", "ES" },
                    { 31, "Sudeste", "MG" },
                    { 32, "Sudeste", "MG" },
                    { 33, "Sudeste", "MG" },
                    { 34, "Sudeste", "MG" },
                    { 35, "Sudeste", "MG" },
                    { 37, "Sudeste", "MG" },
                    { 41, "Sul", "PR" },
                    { 42, "Sul", "SC" },
                    { 43, "Sul", "RS" },
                    { 44, "Centro-Oeste", "PR" },
                    { 45, "Centro-Oeste", "PR" },
                    { 46, "Centro-Oeste", "PR" },
                    { 47, "Sul", "SC" },
                    { 48, "Sul", "SC" },
                    { 49, "Sul", "SC" },
                    { 51, "Sul", "RS" },
                    { 52, "Centro-Oeste", "MS" },
                    { 53, "Centro-Oeste", "MS" },
                    { 61, "Centro-Oeste", "DF" },
                    { 62, "Centro-Oeste", "GO" },
                    { 63, "Centro-Oeste", "TO" },
                    { 64, "Nordeste", "TO" },
                    { 65, "Centro-Oeste", "MT" },
                    { 66, "Centro-Oeste", "MT" },
                    { 67, "Centro-Oeste", "MS" },
                    { 68, "Norte", "AC" },
                    { 69, "Norte", "AM" },
                    { 71, "Nordeste", "BA" },
                    { 73, "Nordeste", "BA" },
                    { 74, "Nordeste", "PA" },
                    { 75, "Nordeste", "BA" },
                    { 77, "Nordeste", "BA" },
                    { 79, "Nordeste", "SE" },
                    { 81, "Nordeste", "PE" },
                    { 82, "Nordeste", "AL" },
                    { 83, "Nordeste", "PB" },
                    { 84, "Nordeste", "RN" },
                    { 85, "Nordeste", "CE" },
                    { 86, "Nordeste", "PI" },
                    { 87, "Nordeste", "PE" },
                    { 88, "Nordeste", "CE" },
                    { 89, "Nordeste", "PI" },
                    { 91, "Norte", "PA" },
                    { 92, "Norte", "AM" },
                    { 93, "Norte", "PA" },
                    { 94, "Norte", "PA" },
                    { 95, "Norte", "RR" },
                    { 96, "Norte", "AP" },
                    { 97, "Norte", "AM" },
                    { 98, "Nordeste", "MA" },
                    { 99, "Nordeste", "MA" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contato_DDD",
                table: "Contato",
                column: "DDD");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contato");

            migrationBuilder.DropTable(
                name: "Regioes");
        }
    }
}
