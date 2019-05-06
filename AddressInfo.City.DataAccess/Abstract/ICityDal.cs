using AddressInfo.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddressInfo.City.DataAccess.Abstract
{
    public interface ICityDal : IEntityRepository<Entities.Concrete.City>
    {
        //custom operations
    }
}
