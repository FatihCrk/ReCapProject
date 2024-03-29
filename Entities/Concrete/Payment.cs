﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Payment : IEntity
    {
        public int PaymentId { get; set; }
        public int CustomerId { get; set; }
        public string CardNameSurname { get; set; }
        public string CardNumber { get; set; }
        public string CardCvv { get; set; }
        public string CardExpiryDate { get; set; }
    }
}
