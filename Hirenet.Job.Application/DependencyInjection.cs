using Hirenet.Job.Application.Interfaces;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Job.Application;
public static class DependencyInjection {
	public static IServiceCollection AddApplication(this IServiceCollection services) {
		services.AddMapster();
		services.AddMediator(options => options.ServiceLifetime = ServiceLifetime.Scoped);
		return services;
	}
}
