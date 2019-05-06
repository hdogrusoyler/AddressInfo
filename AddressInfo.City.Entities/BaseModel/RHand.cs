using System;
using System.Collections.Generic;
using System.Text;

namespace AddressInfo.City.Entities.BaseModel
{
    public class RHand<TEntity> : ResHandBase
        where TEntity : class, new() //, IEntity
    {
        public TEntity Return { get; set; }
    }
}
