using AddressInfo.City.Entities.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddressInfo.City.BusinessLogic.Abstract
{
    public interface ICityService
    {
        RHand<Entities.Concrete.City> GetById(int Id);
        ResHand<Entities.Concrete.City, ReturnType> GetAll();
        void Add(Entities.Concrete.City entity);
        void Update(Entities.Concrete.City entity);
        void Delete(Entities.Concrete.City entity);
    }
}
