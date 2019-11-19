using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Bierpedia.Api {
	public class Startup {
		public Startup(IConfiguration configuration) {
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services) {
			services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

			services.AddControllers();
			services.AddApiVersioning();
			services.AddDbContext<ApiContext>();

			// newtonsoft json, because System.Text.Json does not has ReferenceLoopHandling
			services.AddControllers().AddNewtonsoftJson(options => {
				options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
			});
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
			if (env.IsDevelopment()) {
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();
			app.UseAuthorization();
			
			app.UseEndpoints(endpoints => {
				endpoints.MapControllers();
			});
		}
	}
}
