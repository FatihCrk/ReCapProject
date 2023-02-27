using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Hashing
{

    public class HashingHelper
    {
        //Verilen pw'ün hash'ini oluşturacak. out ise dışarı verilen hash ve password.
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }

        }


        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {

            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                //Gönderilen Hashin her bir byte'ını dön.
                for (int i = 0; i < computedHash.Length; i++)
                {

                    //Gönderilen hash ile Db'deki passwordHash'in her bir byte'ını karşılaştır. Yanlışsa false doğru ise true dön.
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }


                return true;

            }
        }
    }
}
