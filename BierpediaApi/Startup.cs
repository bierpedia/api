using System;
using Bierpedia.Api.GraphQL;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bierpedia.Api {
	public class Startup {
		public Startup(IConfiguration configuration) {
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services) {
			services.AddCors();
			services.AddResponseCompression();
			services.AddDbContext<ApiContext>();

			services.AddGraphQL(SchemaBuilder.New()
				.AddQueryType<QueryType>()
				.AddType(new PaginationAmountType(20)));

			services.AddErrorFilter<ErrorFilter>();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApiContext apiContext) {
			app.UseCors(
				options => options.WithOrigins("http://localhost:8080", "http://localhost:5000").AllowAnyMethod().AllowAnyHeader()
			);
			
			app.UseResponseCompression();

			app.UseGraphQL("/graphql");
			app.UsePlayground("/graphql");

			// automatically migrate database on startup
			apiContext.Database.Migrate();
		}
	}
}
