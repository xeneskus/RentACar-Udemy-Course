using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class ApplicationServiceRegistration
    {//extension method static olmalı, neyi extension ediyoruz this ile belirtiyoruz
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());//git bütün assembly tara orada command handler bul onları birbirileriyle eşleştir listlee koy yarın bir gün send yaparsak onu çalıştır
            });
            return services;
        }
    }
}
