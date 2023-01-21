using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

    

        public IResult Add(Rental rental)
        {
            if ( rental.ReturnDate == null || DateTime.Now < rental.ReturnDate )
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalSuccess);
            }
            else
            {
                return new ErrorResult(Messages.RentalNotAdded);
            }
          
        }

        public IResult Delete(Rental rental)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Rental>> GetRentalsByCustomerId(int customerId)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Rental rental)
        {
            throw new NotImplementedException();
        }
    }
}
