using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Configuration
{
    public static class Inject
    {
        private static IServiceProvider _serviceProvider = null;

        public static TServiceInjection GetService<TServiceInjection>()
        {
            return (TServiceInjection)_serviceProvider.GetService(typeof(TServiceInjection));
        }
        public static void SetProvider(IServiceCollection serviceCollection)
        {
            if (_serviceProvider is not null)
                throw new Exception("não deve ser instaciado mais de uma vez");
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}
