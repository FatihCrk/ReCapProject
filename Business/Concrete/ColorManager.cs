using Business.Abstract;
using Business.Constants;
using Core.Aspects.Caching;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {

        IColorDal _colordal;

        public ColorManager(IColorDal colordal)
        {
            _colordal = colordal;
        }

        public IResult Add(Color color)
        {
            _colordal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Delete(Color color)
        {
            _colordal.Delete(color);

            return new SuccessResult(Messages.CarDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colordal.GetAll(), Messages.ColorsListed);
        }

        public IDataResult<List<Color>> GetAllByColorName(string colorName)
        {
            return new SuccessDataResult<List<Color>>(_colordal.GetAll(c => c.ColorName == colorName));
        }

        public IDataResult<Color> GetByColorId(int Id)
        {
            return new SuccessDataResult<Color>(_colordal.Get(c => c.ColorId == Id));
        }

        public IResult Update(Color color)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {

                if (color.ColorName.Length >= 2)
                {
                    var updatedCarname = context.Entry(color);
                    updatedCarname.State = EntityState.Modified;

                }
                throw new Exception("Renk adı min 2 karakter olmalıdır.");
            }
        }
    }
}
