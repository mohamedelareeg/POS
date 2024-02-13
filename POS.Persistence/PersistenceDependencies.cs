using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using POS.Persistence.Context;
using POS.Persistence.Helpers.Filters;

namespace POS.Persistence
{
    public static class PersistenceDependencies
    {
        public static IServiceCollection AddPersistenceDependencies(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>();

            // Ensure the database is created and apply any pending migrations
            using (var serviceProvider = services.BuildServiceProvider())
            {
                using (var context = serviceProvider.GetRequiredService<AppDbContext>())
                {
                    context.Database.EnsureCreated();
                }
            }



            ////////////////////////////////////////////////////////Authorization//////////////////////////////////////////
            services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();//one instance
            services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
            ////////////////////////////////////////////////////////END//////////////////////////////////////////////////////
            return services;
        }
    }
}
