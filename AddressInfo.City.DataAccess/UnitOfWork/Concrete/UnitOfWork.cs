using AddressInfo.City.DataAccess.Abstract;
using AddressInfo.City.DataAccess.Concrete.EntityFramework;
using AddressInfo.City.DataAccess.UnitOfWork.Abstract;
using AddressInfo.Core.DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddressInfo.City.DataAccess.UnitOfWork.Concrete
{
    public class UnitOfWork : UnitOfWorkBase<DataContext>, IUnitOfWork
    {
        public ICityDal cityDal { get; set; }

        public UnitOfWork(DataContext context, ICityDal _cityDal) : base(context)
        {
            cityDal = _cityDal;
        }

    }
}
