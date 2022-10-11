using Application.Services;
using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
                                                               IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options =>
                                                     options.UseSqlServer(
                                                         configuration.GetConnectionString("KodlamaioDevsConnectionString")));

            services.AddScoped<IProgrammingLanguagesRepository, ProgrammingLanguagesRepository>();
            services.AddScoped<ILanguageTechRepository, LanguageTechRepository>();
            services.AddScoped<ISocialMediaRepository, SocialMediaRepository>();

            return services;
        }
    }
}
