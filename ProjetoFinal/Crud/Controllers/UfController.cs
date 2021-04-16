using Crud.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Controllers
{
    public class UfController : Controller
    {
        private readonly IUf _uf;
        public UfController(IUf uf)
        {
            _uf = uf;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var ufs = _uf.GetAll();
            
            return Ok(ufs);
        }
    }
}
