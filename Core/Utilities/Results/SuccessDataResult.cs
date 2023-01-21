using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        //Data ve Mesaj
        public SuccessDataResult(T data, string message):base(data, true, message)
        {

        }

        //Sadece data 
        public SuccessDataResult(T data):base(data,true)
        {

        }

        //Sadece mesaj default data tipi neyse onu gönderir.
        public SuccessDataResult(string message) : base(default,true,message)
        {

        }
        //Hiçbirşey vermeden de kullanılabilir
        public SuccessDataResult() : base(default, true)
        {

        }
    }
}
