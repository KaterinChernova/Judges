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
                .AddTransient<IServiceCollection, ServiceCollection>();

            return serviceCollection;
        }
    }
}
