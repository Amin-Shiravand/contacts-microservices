using System;
using MediatR;
using FluentValidation;
using System.Reflection;
using Contact.Application.Behaviors;
using Microsoft.Extensions.DependencyInjection;


namespace Contact.Application
{
	public static class ApplicationServiceRegisteration
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection Services)
		{
			Assembly assembly = Assembly.GetExecutingAssembly();
			Type iPipeLineBehavior = typeof(IPipelineBehavior<,>);
			Services.AddAutoMapper(assembly);
			Services.AddValidatorsFromAssembly(assembly);
			Services.AddMediatR(assembly);
			Services.AddTransient(iPipeLineBehavior,typeof(UnhandledExceptionBehavior<,>));
			Services.AddTransient(iPipeLineBehavior, typeof(ValidationBehavior<,>));
			return Services;
		}
	}
}
