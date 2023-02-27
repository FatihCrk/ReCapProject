using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        //Asp .Net'in API tarafında token doğrulama yapabilmesi için hangi anahtarı ve algoritmayı kullanacağını bildiriyoruz. API Kapı kilidi oluşturduk diyebiliriz.
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

        }
    }
}
