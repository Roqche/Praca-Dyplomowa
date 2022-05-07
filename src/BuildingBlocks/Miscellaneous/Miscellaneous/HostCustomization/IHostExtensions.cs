using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Polly;
using System;

namespace Microsoft.Extensions.Hosting
{
	public static class IHostExtensions
	{
		public static IHost MigrateDbContext<TContext>(this IHost host) where TContext : DbContext
		{
			using (var scope = host.Services.CreateScope())
			{
				var services = scope.ServiceProvider;
				var logger = services.GetRequiredService<ILogger<TContext>>();
				var context = services.GetService<TContext>();

				var retries = 10;
				var retry = Policy.Handle<SqlException>().WaitAndRetry(
					retryCount: 1,
					sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
					onRetry: (exception, timeSpan, retry, ctx) =>
					{
						logger.LogWarning(exception, "[{prefix}] Exception {ExceptionType} with message {Message} detected on attempt {retry} of {retries}", nameof(TContext), exception.GetType().Name, exception.Message, retry, retries);
					});

				try
				{
					retry.Execute(() => context.Database.Migrate());
				}
				catch (Exception ex)
				{
					logger.LogError(ex, "An error occurred while migrating the database used on context {DbContextName}", typeof(TContext).Name);
				}
			}

			return host;
		}
	}
}
