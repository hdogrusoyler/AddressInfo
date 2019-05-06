using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddressInfo.City.BusinessLogic.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AddressInfo.City.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private ICityService _cityService;

        public ValuesController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        public ActionResult<List<Entities.Concrete.City>> Get()
        {
            return Ok(_cityService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Entities.Concrete.City> Get(int id)
        {
            return Ok(_cityService.GetById(id));
        }

        [HttpPost]
        [Route("add")]
        public ActionResult Add([FromBody] Entities.Concrete.City city)
        {
            _cityService.Add(city);

            return Ok(city);
        }

        [HttpPost]
        [Route("update")]
        public ActionResult Update([FromBody] Entities.Concrete.City city)
        {
            _cityService.Update(city);

            return Ok(city);
        }

        [HttpPost]
        [Route("delete")]
        public ActionResult Delete(int id)
        {
            var city = _cityService.GetById(id);
            _cityService.Delete(city.Return);
            return Ok(city);
        }

    }
}
