﻿using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICustomerDal : IEntityRepository<Customer>
    {

        List<CustomerDetailDto> GetCustomerDetails(Expression<Func<Customer, bool>> filter = null);

        CustomerDetailDto GetByEmail(Expression<Func<CustomerDetailDto, bool>> filter = null);
    }
}
