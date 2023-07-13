using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class UserForUpdateDto : UserForRegisterDto, IDto
    {
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public int FindexPoint { get; set; }
    }
}
