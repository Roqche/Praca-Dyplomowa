using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using RCP.DB.Infrastructure;

namespace RCP.DB
{
	public static class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build()
				.MigrateDbContext<RcpContext>()
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
