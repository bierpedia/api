using Bierpedia.Api.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Bierpedia.Api {
	public class ApiContext : DbContext {

		private readonly IConfiguration configuration;

		public ApiContext(IConfiguration configuration) {
			this.configuration = configuration;
		}
		public DbSet<Beer> Beers { get; set; }

		public DbSet<Model.Style> Styles { get; set; }

		public DbSet<Brewery> Breweries { get; set; }

		public DbSet<Country> Countries { get; set; }

		public DbSet<Rating> Ratings { get; set; }

		public DbSet<Concern> Concerns { get; set; }

		public DbSet<BeerStyle> BeerStyles { get; set; }

		public DbSet<BeerBrewery> BeerBreweries { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
			optionsBuilder.UseNpgsql(configuration.GetConnectionString("Postgres"))
				.UseSnakeCaseNamingConvention()
				.UseLazyLoadingProxies();

		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			modelBuilder.HasDefaultSchema("bierpedia");

			// configure keys for many-to-many relationship tables
			modelBuilder.Entity<BeerStyle>().HasKey(bbt => new { bbt.BeerId, bbt.StyleId });
			modelBuilder.Entity<BeerBrewery>().HasKey(bb => new { bb.BeerId, bb.BreweryId });

			modelBuilder.Entity<Brewery>().HasIndex(b => b.Slug).IsUnique();
			modelBuilder.Entity<Model.Style>().HasIndex(b => b.Slug).IsUnique();
			modelBuilder.Entity<Beer>().HasIndex(b => b.Slug).IsUnique();
			modelBuilder.Entity<Country>().HasIndex(c => c.Slug).IsUnique();
		}
	}
}
