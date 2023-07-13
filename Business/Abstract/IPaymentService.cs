using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPaymentService
    {
        IDataResult<List<Payment>> GetByCardNumber(string cardNumber);
        IResult VerifyCard(Payment creditCard);
        IDataResult<List<Payment>> GetAll();
        IDataResult<Payment> GetById(int cardId);
        IDataResult<List<Payment>> GetByCustomerId(int id);
        //IResult IsCardExist(Payment payment);
        IResult Add(Payment payment);
        IResult Delete(Payment payment);
        IResult Update(Payment payment);
    }
}
