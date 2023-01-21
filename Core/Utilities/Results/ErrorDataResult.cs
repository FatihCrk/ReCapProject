using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        //Data ve Mesaj
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {

        }

        //Sadece data 
        public ErrorDataResult(T data) : base(data, false)
        {

        }

        //Sadece mesaj default data tipi neyse onu gönderir.
        public ErrorDataResult(string message) : base(default, false, message)
        {

        }
        //Hiçbirşey vermeden de kullanılabilir
        public ErrorDataResult() : base(default, false)
        {

        }
    }
}
