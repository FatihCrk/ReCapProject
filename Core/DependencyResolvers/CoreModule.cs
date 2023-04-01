using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {//Kullanacağımız modülleri buraya ekliyoruz.
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            //MemoryCacheManager'daki injection(_memoryCache)'in çalışabilmesi için.
            serviceCollection.AddMemoryCache();

            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();

            //Kronometre
            serviceCollection.AddSingleton<Stopwatch>();


        }
    }
}
