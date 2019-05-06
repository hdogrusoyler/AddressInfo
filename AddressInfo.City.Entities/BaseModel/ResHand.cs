using System;
using System.Collections.Generic;
using System.Text;

namespace AddressInfo.City.Entities.BaseModel
{
    public class ResHand<TEntity, TReturnType> : ResHandBase
        where TEntity : class, new() //, IEntity
        //where TReturnType : IReturnType
    {
        public List<TEntity> ReturnList { get; set; }

        public ResHand()
        {
            ReturnList = new List<TEntity>();
        }
    }
}
