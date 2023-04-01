using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;

        public CacheAspect(int duration = 60)
        {
            //Key değeri default olarak 60 dk tanımladık. 1 dk sonrasında cache silinir.
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {

            //ReflectedType Metodun namespace'ini getir. Fullname(metodu) i getirir. Çağırılan Metotdun ismini getirir.
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");

            //metodun argumanlarını listele.
            var arguments = invocation.Arguments.ToList();


            // metodun argumanlarını virgülle ayır. yoksa null döndürdük. sonra onları key'e atadık. Not: ?? varsa soldakini yoksa sağdakini ekler (işlemi yapar)
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
            if (_cacheManager.IsAdd(key))
            {//Eğer chache de değer varsa değerleri burada geri döndürüyoruz.
                invocation.ReturnValue = _cacheManager.Get(key);
                return;
            }

            //yoksa işleme devam ettirirdik.
            invocation.Proceed();

            //Key değerini ise duration ile birlikte cache'e ekledik..
            _cacheManager.Add(key, invocation.ReturnValue, _duration);
        }
    }
}
