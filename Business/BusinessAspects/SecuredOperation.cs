using Business.Constants;
using Castle.DynamicProxy;

using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Core.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessAspects
{
    //JWT için.
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;

        public SecuredOperation(string roles)
        { //metinleri virgülle ayırıp Array'e atmak için.
            _roles = roles.Split(',');

            //windows formda kullanmak için.
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        protected override void OnBefore(IInvocation invocation)
        {//Kullanıcı rollerini bul
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {//Kullanıcı claimlerini gez eğer içerisinde ilgili rol var ise metotdu çalıştırmaya devam et.
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }

            //yoksa hata dön.
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
