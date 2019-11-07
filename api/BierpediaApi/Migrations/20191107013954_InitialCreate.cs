using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Bierpedia.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "bierpedia");

            migrationBuilder.CreateTable(
                name: "beer_types",
                schema: "bierpedia",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(nullable: false),
                    slug = table.Column<string>(nullable: false),
                    description = table.Column<string>(nullable: false),
                    parent_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_beer_types", x => x.id);
                    table.ForeignKey(
                        name: "FK_beer_types_beer_types_parent_id",
                        column: x => x.parent_id,
                        principalSchema: "bierpedia",
                        principalTable: "beer_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "beers",
                schema: "bierpedia",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(nullable: false),
                    slug = table.Column<string>(nullable: false),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_beers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "countries",
                schema: "bierpedia",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(nullable: false),
                    slug = table.Column<string>(nullable: false),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countries", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "beer_beer_types",
                schema: "bierpedia",
                columns: table => new
                {
                    beer_id = table.Column<int>(nullable: false),
                    beer_type_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_beer_beer_types", x => new { x.beer_id, x.beer_type_id });
                    table.ForeignKey(
                        name: "FK_beer_beer_types_beers_beer_id",
                        column: x => x.beer_id,
                        principalSchema: "bierpedia",
                        principalTable: "beers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_beer_beer_types_beer_types_beer_type_id",
                        column: x => x.beer_type_id,
                        principalSchema: "bierpedia",
                        principalTable: "beer_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ratings",
                schema: "bierpedia",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    beer_id = table.Column<int>(nullable: true),
                    grade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ratings", x => x.id);
                    table.ForeignKey(
                        name: "FK_ratings_beers_beer_id",
                        column: x => x.beer_id,
                        principalSchema: "bierpedia",
                        principalTable: "beers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "breweries",
                schema: "bierpedia",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(nullable: false),
                    slug = table.Column<string>(nullable: false),
                    country_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_breweries", x => x.id);
                    table.ForeignKey(
                        name: "FK_breweries_countries_country_id",
                        column: x => x.country_id,
                        principalSchema: "bierpedia",
                        principalTable: "countries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "beer_breweries",
                schema: "bierpedia",
                columns: table => new
                {
                    beer_id = table.Column<int>(nullable: false),
                    brewery_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_beer_breweries", x => new { x.beer_id, x.brewery_id });
                    table.ForeignKey(
                        name: "FK_beer_breweries_beers_beer_id",
                        column: x => x.beer_id,
                        principalSchema: "bierpedia",
                        principalTable: "beers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_beer_breweries_breweries_brewery_id",
                        column: x => x.brewery_id,
                        principalSchema: "bierpedia",
                        principalTable: "breweries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_beer_beer_types_beer_type_id",
                schema: "bierpedia",
                table: "beer_beer_types",
                column: "beer_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_beer_breweries_brewery_id",
                schema: "bierpedia",
                table: "beer_breweries",
                column: "brewery_id");

            migrationBuilder.CreateIndex(
                name: "IX_beer_types_parent_id",
                schema: "bierpedia",
                table: "beer_types",
                column: "parent_id");

            migrationBuilder.CreateIndex(
                name: "IX_breweries_country_id",
                schema: "bierpedia",
                table: "breweries",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "IX_ratings_beer_id",
                schema: "bierpedia",
                table: "ratings",
                column: "beer_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "beer_beer_types",
                schema: "bierpedia");

            migrationBuilder.DropTable(
                name: "beer_breweries",
                schema: "bierpedia");

            migrationBuilder.DropTable(
                name: "ratings",
                schema: "bierpedia");

            migrationBuilder.DropTable(
                name: "beer_types",
                schema: "bierpedia");

            migrationBuilder.DropTable(
                name: "breweries",
                schema: "bierpedia");

            migrationBuilder.DropTable(
                name: "beers",
                schema: "bierpedia");

            migrationBuilder.DropTable(
                name: "countries",
                schema: "bierpedia");
        }
    }
}
