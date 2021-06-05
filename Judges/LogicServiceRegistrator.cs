using Judges.Data.Models;
using Judges.Services;
using Judges.Utils.Cache;
using Judges.Utils.Cache.Redis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Judges
{
    public static class LogicServiceRegistrator
    {
        public static IServiceCollection RegisterLogicServices(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddTransient<IMemoryCahceService<Sport>, SportsMemoryCache>()
                .AddTransient<IRedisCache<Sport>, SportsRedisCache>()
                .AddTransient<IJudgeService, JudgeService>()
                .AddTransient<ISportService, SportService>()
                .AddHttpClient<IEventService, EventService>();

            return serviceCollection;
        }
    }
}
