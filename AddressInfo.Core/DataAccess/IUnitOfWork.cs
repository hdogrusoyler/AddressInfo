using System;
using System.Collections.Generic;
using System.Text;

namespace AddressInfo.Core.DataAccess
{
    public interface IUnitOfWork
    {
        void Save();
    }
}
