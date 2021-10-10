using Microsoft.Extensions.Configuration;
using Contact.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contact.Application.Contracts.Persistence;
using Contact.Infrastructure.Repositories;

namespace Contact.Infrastructure
{
	public static class InfrastructureServiceRegistration
	{
		public static IServiceCollection AddInfrastructureServices(this IServiceCollection Services,
																	IConfiguration Configuration)
		{
			Services.AddDbContext<ContactContext>(options =>
			{
				options.UseSqlServer(Configuration.GetConnectionString("ContactConnectionString"));
			});

			Services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
			Services.AddScoped<IContactRepository, ContactRepositroy>();
			return Services;
		}
	}
}
