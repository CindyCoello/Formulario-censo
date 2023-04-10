
using FormCenso.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace FormCenso.DataAccess
{
    public static class ServiceConfiguration
    {
        public static void AddDataAcces(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<CensoRepository>();

            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>()
                .AddScoped<IUrlHelper>(x => x
                .GetRequiredService<IUrlHelperFactory>()
                .GetUrlHelper(x.GetRequiredService<IActionContextAccessor>().ActionContext));
            FormCensoDbContext.BuildConnectionString(connectionString);
        }
    }
}
