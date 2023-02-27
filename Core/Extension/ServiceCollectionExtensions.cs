using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extension
{
    //Program.cs için Birden fazla modul eklediğimizde modüllerimizi çözümleyebilmemiz için ekledik.
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection servicesCollection, ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(servicesCollection);
            }
            //Tüm extra modülleri oluştur.
            return ServiceTool.Create(servicesCollection);
        }
    }
}
