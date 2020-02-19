using System;
using Bierpedia.Api.GraphQL;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.ResponseCaching;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;


namespace Bierpedia.Api {
	public class Startup {
		public Startup(IConfiguration configuration) {
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services) {
			services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
			services.AddCors();
			services.AddResponseCaching();
			services.AddResponseCompression();
			services.AddControllers();
			services.AddApiVersioning();
			services.AddDbContext<ApiContext>();

			// newtonsoft json, because System.Text.Json does not has ReferenceLoopHandling
			services.AddControllers().AddNewtonsoftJson(options => {
				options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
			});

			services.Configure<KestrelServerOptions>(options => {
				options.AllowSynchronousIO = true;
			});

			services.AddGraphQL(SchemaBuilder.New().AddQueryType<QueryType>());
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
			if (env.IsDevelopment()) {
				app.UseDeveloperExceptionPage();
			}

			app.UseCors(
				options => options.WithOrigins("http://localhost:8080", "http://localhost:5000").AllowAnyMethod().AllowAnyHeader()
			);
			app.UseResponseCaching();
			app.Use(async (context, next) => {
				context.Response.GetTypedHeaders().CacheControl =
					new Microsoft.Net.Http.Headers.CacheControlHeaderValue() {
						Public = true,
						MaxAge = TimeSpan.FromSeconds(600)
					};
				context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.Vary] =
					new string[] { "Accept-Encoding" };
				var responseCachingFeature = context.Features.Get<IResponseCachingFeature>();
				if (responseCachingFeature != null) {
					responseCachingFeature.VaryByQueryKeys = new[] { "page", "perPage" };
				}
				await next();
			});

			app.UseResponseCompression();
			app.UseRouting();
			app.UseAuthorization();
			
			app.UseEndpoints(endpoints => {
				endpoints.MapControllers();
			});

			app.UseGraphQL();
			app.UsePlayground();
		}
	}
}
