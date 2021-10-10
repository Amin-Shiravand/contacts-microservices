using Microsoft.Extensions.DependencyInjection;
using Contact.API.Extensions;
using Contact.Infrastructure.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Contact.API
{
	public class Program
	{
		public static void Main(string[] args)
		{
			IHost host = CreateHostBuilder(args).Build();
			host.MigrateDatabase<ContactContext>((context, services) =>
			{
				ILogger<ContactContextSeed> logger = services.GetService<ILogger<ContactContextSeed>>();
				ContactContextSeed.SeedAsync(context, logger).Wait();
			});
			host.Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}
