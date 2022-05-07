using Analyzer.DB.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Analyzer.DB
{
	public static class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build()
				.MigrateDbContext<AnalyzerContext>()
				.Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}
