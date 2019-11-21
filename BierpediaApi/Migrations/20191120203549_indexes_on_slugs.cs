using Microsoft.EntityFrameworkCore.Migrations;

namespace Bierpedia.Api.Migrations
{
    public partial class indexes_on_slugs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_countries_slug",
                schema: "bierpedia",
                table: "countries",
                column: "slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_breweries_slug",
                schema: "bierpedia",
                table: "breweries",
                column: "slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_beers_slug",
                schema: "bierpedia",
                table: "beers",
                column: "slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_beer_types_slug",
                schema: "bierpedia",
                table: "beer_types",
                column: "slug",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_countries_slug",
                schema: "bierpedia",
                table: "countries");

            migrationBuilder.DropIndex(
                name: "IX_breweries_slug",
                schema: "bierpedia",
                table: "breweries");

            migrationBuilder.DropIndex(
                name: "IX_beers_slug",
                schema: "bierpedia",
                table: "beers");

            migrationBuilder.DropIndex(
                name: "IX_beer_types_slug",
                schema: "bierpedia",
                table: "beer_types");
        }
    }
}
