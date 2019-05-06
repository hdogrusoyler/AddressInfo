using System;
using System.Collections.Generic;
using System.Text;

namespace AddressInfo.City.Entities.BaseModel
{
    public class ResHandBase
    {
        public bool isSuccess { get; set; }
        public ReturnType resultId { get; set; }
        public string resultRemark { get; set; }
    }
}
