using Microsoft.AspNetCore.Builder;
using System;

namespace Arslan.Net
{
    public static class ServiceExtensions
    {
        public static IApplicationBuilder UseServiceInjection(this IApplicationBuilder app) {
            if (app == null) 
                throw new ArgumentNullException(nameof(app));

            Service.Configure(type => app.ApplicationServices.GetService(type));
            return app;
        }
    }
}
