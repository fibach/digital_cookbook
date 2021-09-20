using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapters.GoogleCV
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddGoogleCV(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddTransient<ICloudVisionOcr, CloudVisionOcr>();
        }
    }
}
