using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyFastProject.Core;
using MyFastProject.Core.Behaviour;
using MyFastProject.Core.Mappers;
using MyFastProject.DataAccess.DatabaseContext;
using MyFastProject.Repositories.Concrete;
using MyFastProject.Repositories.Interfaces;

namespace MyFastProject.IoC.Configuration;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection MapCore(this IServiceCollection services,IConfiguration configuration)
	{
		services.AddDbContext<ApplicationDbContext>(optins => optins.UseSqlServer(configuration.GetConnectionString("ConnString")));
		services.AddAutoMapper(typeof(StudentMappersProfile).Assembly);
		services.AddTransient<IStudentRepository, StudentRepository>();
		services.AddTransient<IProductRepository, ProductRepository>();
		services.AddMediatR(options => options.RegisterServicesFromAssemblies(typeof(ICore).Assembly));
		services.AddValidatorsFromAssembly(typeof(ICore).Assembly);
		services.AddMediatR(cfg =>
		{
			cfg.RegisterServicesFromAssemblies(typeof(ICore).Assembly);
			cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
		});
		return services;
	}
}
