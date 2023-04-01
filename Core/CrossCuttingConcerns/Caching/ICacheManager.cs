using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching
{
    //Chache işlemleri için oluşturduğumuz interface. Redis Cache, Elastic Sourch LogStash için de kullanılabilir.
    public interface ICacheManager
    {
        T Get<T>(string key);

        //Tip dönüşümlü olarak tanımlama)
        object Get(string key);

        //duration saat dakika cinsinden ne kadar duracağını belirlemek için tanımladık.
        void Add(string key, object value, int duration);
        bool IsAdd(string key);
        void Remove(string key);


        //içerisinde get category vb... olanları uçursun. Sistem güvenliği için.
        void RemoveByPattern(string pattern);

    }
}
