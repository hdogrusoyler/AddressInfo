using AddressInfo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddressInfo.City.Entities.Concrete
{
    public class City : IEntity
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public int CityCode { get; set; }
        public string DistrictName { get; set; }
        public int ZipCode { get; set; }
    }
}
