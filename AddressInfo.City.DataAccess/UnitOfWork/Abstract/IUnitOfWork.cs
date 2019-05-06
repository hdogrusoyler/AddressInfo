using AddressInfo.City.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddressInfo.City.DataAccess.UnitOfWork.Abstract
{
    public interface IUnitOfWork : Core.DataAccess.IUnitOfWork
    {
        ICityDal cityDal { get; set; }
    }
}
