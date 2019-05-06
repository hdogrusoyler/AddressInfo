using AddressInfo.City.DataAccess.Abstract;
using AddressInfo.Core.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddressInfo.City.DataAccess.Concrete.EntityFramework
{
    public class EfCityDal : EfEntityRepositoryBase<Entities.Concrete.City, DataContext>, ICityDal
    {
        public EfCityDal(DataContext dbContext) : base(dbContext)
        {

        }
    }
}
