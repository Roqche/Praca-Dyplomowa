using Analyzer.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

namespace Analyzer.API
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services
				.AddHttpClient()
				.AddTransient<IAnalyzerService, AnalyzerService>()
				.AddTransient<IRcpService, RcpService>();

			services
				.AddCustomMVC(Configuration)
				.AddSwagger();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
			}

			app.UseSwagger()
				.UseSwaggerUI(c =>
				{
					c.SwaggerEndpoint("/swagger/v1/swagger.json", "API");
				});

			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapDefaultControllerRoute();
				endpoints.MapControllers();
			});
		}
	}

	public static class CustomExtensionMethods
	{
		public static IServiceCollection AddCustomMVC(this IServiceCollection services, IConfiguration configuration)
		{
			services
				.AddOptions()
				.Configure<AppSettings>(configuration)
				.AddControllers()
				.AddJsonOptions(options =>
				{
					options.JsonSerializerOptions.WriteIndented = true;
					options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
				});

			return services;
		}

		public static IServiceCollection AddSwagger(this IServiceCollection services)
		{
			services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc("v1", new OpenApiInfo
				{
					Title = "Analyzer - API",
					Version = "v1",
					Description = "The Analyzer API Microservice."
				});
			});

			return services;
		}
	}
}
