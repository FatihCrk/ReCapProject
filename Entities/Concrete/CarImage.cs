using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CarImage:IEntity
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string ImagePath { get; set; } = string.Empty; //Path Boş olarak ayarlıyoruz. Sonra set ettiğim için.
        public DateTime AddedDate { get; set; }
    
    }
}
