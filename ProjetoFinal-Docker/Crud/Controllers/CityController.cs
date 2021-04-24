using Crud.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Controllers
{
    public class CityController : Controller
    {
        private readonly ICity _city;
        public CityController(ICity city)
        {
            _city = city;
        }
        public IActionResult GetByIdUf(int id)
        {
            var cities = _city.GetByIdUf(id);
            
            return Ok(cities);
        }
    }
}
